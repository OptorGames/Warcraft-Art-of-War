using System;
using System.Collections.Generic;
using ForUnit;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelGame.UI
{
    public class InterfaceController : MonoBehaviour
    {
        public static InterfaceController Instance;
        public List<CellControl> _cellsContainer;
        [SerializeField] private List<Sprite> _sprites;
        [SerializeField] private Transform _transformForCell;
        [SerializeField] private CellControl _cellForUnit;
        [SerializeField] private TMP_Text _enemyUnitCountText;
        [SerializeField] private TMP_Text _ourUnitCountText;
        [SerializeField] private GameObject _pausePanel;
        private UnitsContainer _unitsContainer;
        private const int CountCell = 49;

        public List<Sprite> Sprites => _sprites;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance == this)
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            _unitsContainer = UnitsContainer.Instance;
            _cellsContainer = new List<CellControl>();
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
    }
}