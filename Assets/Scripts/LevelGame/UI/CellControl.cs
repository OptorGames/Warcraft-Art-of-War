using UnityEngine;
using UnityEngine.UI;

namespace LevelGame.UI
{
    public class CellControl : MonoBehaviour
    {
        public bool Available { get; private set; } = true;
        [SerializeField] private GameObject _plus;
        [SerializeField] private Image _backCell;
        private Color _startBackCellColor;

        private void Start()
        {
            _startBackCellColor = _backCell.color;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("OurUnit"))
            {
                Available = false;
                _plus.SetActive(false);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("OurUnit"))
            {
                Available = true;
                _plus.SetActive(true);
            }
        }

        private void OnMouseEnter()
        {
            if (MovingUnitsAcrossCells.HaveObject && Available)
            {
                _backCell.color = new Color(0, 0.5f, 1);
            }
        }

        private void OnMouseExit()
        {
            _backCell.color = _startBackCellColor;
        }
    }
}