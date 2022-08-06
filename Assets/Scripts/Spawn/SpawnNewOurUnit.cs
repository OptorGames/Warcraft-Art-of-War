using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Spawn
{
    public class SpawnNewOurUnit : SpawnUnit
    {
        [SerializeField] private float _waitTimeForNewUnit = 2;
        [SerializeField] private int _maxCountNewUnit = 5;
        [SerializeField] private int _startCountForNewUnit = 1;
        [SerializeField] private Image _buttonImage;
        [SerializeField] private TMP_Text _possibleCountUnitText;
        private int _countForNewUnit;
        private Ray _ray;
        private Vector3 _worldPosition;
        private Plane _plane = new Plane(Vector3.down, 0);

        protected override void Start()
        {
            base.Start();
            _countForNewUnit = _startCountForNewUnit;
            _possibleCountUnitText.text = "X:" + _countForNewUnit;
        }

        private void Update()
        {
            PlusUnitForSpawn();

            if (Input.GetMouseButtonDown(0))
            {
                _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                ChangeSpawnPosition();
            }
        }

        private void PlusUnitForSpawn()
        {
            if (_countForNewUnit <= _maxCountNewUnit)
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

        public void NewUnit()
        {
            if (_countForNewUnit > 0)
            {
                _countForNewUnit--;
                _possibleCountUnitText.text = "X:" + _countForNewUnit;
                SpawnUnits(1);
            }
        }

        protected override void SpawnUnits(int unitCount)
        {
            for (int i = 0; i < unitCount; i++)
            {
                var unit = Instantiate(_unit, _pointForSpawn);
                unit.transform.SetParent(_unitsTransformContainer);
                UnitsContainer.AddOurUnit(unit);
            }
        }


        protected override void ChangeSpawnPosition()
        {
            if (_plane.Raycast(_ray, out float distance))
            {
                _worldPosition = _ray.GetPoint(distance);
                _pointForSpawn.position = new Vector3(_worldPosition.x, _pointForSpawn.position.y, _worldPosition.z);
                NewUnit();
            }
        }
    }
}