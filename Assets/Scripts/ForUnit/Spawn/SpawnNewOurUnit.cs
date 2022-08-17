using ForUnit.InitializeUnit;
using LevelGame;
using Money;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ForUnit.Spawn
{
    public class SpawnNewOurUnit : SpawnUnit
    {
        [SerializeField] protected InitializeOurUnit _initializeOurUnit;
        [SerializeField] private Coins _coins;
        [SerializeField] private Camera _camera;
        [SerializeField] private float _waitTimeForNewUnit = 2;
        [SerializeField] private int _maxCountNewUnit = 5;
        [SerializeField] private int _startCountForNewUnit = 1;
        [SerializeField] private Image _buttonImage;
        [SerializeField] private TMP_Text _possibleCountUnitText;
        private const int NewUnitCost = 50;
        private int _countForNewUnit;
        private Ray _ray;
        private Vector3 _worldPosition;

        protected override void Start()
        {
            base.Start();
            _countForNewUnit = _startCountForNewUnit;
            _possibleCountUnitText.text = "X:" + _countForNewUnit;
            BuyNewUnitsButton.OnNewUnit += NewUnit;
        }

        private void Update()
        {
            if (GameStageController.StartFight)
            {
                PlusUnitForSpawn();
                if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
                {
                    ChangeSpawnPosition();
                }
            }
        }

        private void PlusUnitForSpawn()
        {
            if (_countForNewUnit < _maxCountNewUnit)
            {
                _buttonImage.fillAmount -= 1.0f / _waitTimeForNewUnit * Time.deltaTime;
                if (_buttonImage.fillAmount == 0)
                {
                    _countForNewUnit++;
                    _possibleCountUnitText.text = "X:" + _countForNewUnit;
                    _buttonImage.fillAmount = 1;
                }
            }
        }

        private void NewUnit()
        {
            if (_countForNewUnit > 0 && PlayerPrefs.GetInt("Coins") >= NewUnitCost)
            {
                _coins.ChangeMoneyNumber(NewUnitCost);
                _countForNewUnit--;
                _possibleCountUnitText.text = "X:" + _countForNewUnit;
                SpawnUnits(1, 0);
            }
        }

        protected override void SpawnUnits(int unitCount, int unitType)
        {
            for (int i = 0; i < unitCount; i++)
            {
                var unit = Instantiate(_unit, _pointForSpawn);
                unit.transform.SetParent(_unitsTransformContainer);
                _initializeOurUnit.InitializeUnit(unitType, unit);
                UnitsContainer.AddOurUnit(unit);
            }
        }

        protected override void ChangeSpawnPosition()
        {
            _ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(_ray, out var hit) && hit.transform.gameObject.CompareTag("Plane"))
            {
                _worldPosition = hit.point;
                _pointForSpawn.position = new Vector3(_worldPosition.x, _pointForSpawn.position.y, _worldPosition.z);
                NewUnit();
            }
        }

        private void OnDisable()
        {
            BuyNewUnitsButton.OnNewUnit -= NewUnit;
        }
    }
}