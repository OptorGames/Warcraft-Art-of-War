using ForUnit.InitializeUnit;
using UnityEngine;

namespace ForUnit.Spawn
{
    public class OurUnitSpawner : SpawnUnit
    {
        [SerializeField] private InitializeOurUnit _initializeOurUnit;

        protected override void Start()
        {
            base.Start();
            SpawnUnits(1, 0);
            SpawnUnits(1, 1);
            SpawnUnits(1, 2);
            SpawnUnits(1, 3);
            SpawnUnits(1, 4);
            SpawnUnits(1, 5);
            SpawnUnits(1, 6);
            SpawnUnits(1, 7);
            SpawnUnits(1, 8);
            SpawnUnits(1, 9);
            SpawnUnits(1, 10);
            SpawnUnits(1, 11);
            SpawnUnits(1, 12);
            SpawnUnits(1, 13);
            SpawnUnits(1, 14);
            SpawnUnits(1, 15);
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