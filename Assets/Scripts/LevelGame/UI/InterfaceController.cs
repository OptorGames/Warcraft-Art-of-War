using System.Collections.Generic;
using ForUnit;
using LevelGame.Unit;
using TMPro;
using Unit.ForUnit;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelGame.UI
{
    public class InterfaceController : MonoBehaviour
    {
        private UnitsContainer _unitsContainer;

        [SerializeField] private Transform _transformForCell;
        [SerializeField] private CellControl _cellForUnit;
        [SerializeField] private TMP_Text _enemyUnitCountText;
        [SerializeField] private TMP_Text _ourUnitCountText;
        [SerializeField] private GameObject _pausePanel;
        public List<CellControl> _cellsContainer;
        private const int CountCell = 49;

        private void Start()
        {
            _unitsContainer = UnitsContainer.Instance;
            _cellsContainer=new List<CellControl>();
            for (int i = 0; i < CountCell; i++)
            {
                _cellsContainer.Add(Instantiate(_cellForUnit, _transformForCell));
            }

            _enemyUnitCountText.text = _unitsContainer.EnemyUnits.Count.ToString();
            _ourUnitCountText.text = _unitsContainer.OurUnits.Count.ToString();
        }

        private void Update()
        {
            _enemyUnitCountText.text = _unitsContainer.EnemyUnits.Count.ToString();
            _ourUnitCountText.text = _unitsContainer.OurUnits.Count.ToString();
        }

        public void MenuButton()
        {
            SceneManager.LoadScene("Menu");
            Time.timeScale = 1;
        }

        public void PauseButton()
        {
            Time.timeScale = 0;
            _pausePanel.SetActive(true);
        }

        public void ContinueButton()
        {
            Time.timeScale = 1;   
            _pausePanel.SetActive(false);
        }

        public void X3CoinButton()
        {
            
        }
    }
}