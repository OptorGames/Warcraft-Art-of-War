using ForUnit.InitializeUnit;
using UnityEngine;

namespace ForUnit.Spawn
{
    public class OurUnitSpawner : SpawnUnit
    {
        [SerializeField] protected InitializeOurUnit _initializeOurUnit;
        [SerializeField] private int _countUnit1;
        [SerializeField] private int _countUnit2;
        [SerializeField] private int _countUnit3;

        protected override void Start()
        {
            base.Start();
            SpawnUnits(_countUnit1, 0);
            SpawnUnits(_countUnit2, 1);
            SpawnUnits(_countUnit3, 2);
        }

        protected override void SpawnUnits(int unitCount, int unitType)
        {
            for (int i = 0; i < unitCount; i++)
            {
                var unit = Instantiate(_unit, _pointForSpawn);
                unit.transform.SetParent(_unitsTransformContainer);
                _initializeOurUnit.InitializeUnit(unitType, unit);
                UnitsContainer.AddOurUnit(unit);
                ChangeSpawnPosition();
            }
        }

        protected override void ChangeSpawnPosition()
        {
            var position = _pointForSpawn.position;

            if (_pointForSpawn.position.x < 4)
            {
                position.x += 1.4f;
            }
            else
            {
                position.x = -4;
                position.z -= 1.4f;
            }

            _pointForSpawn.position = position;
        }
    }
}