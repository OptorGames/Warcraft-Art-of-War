using ForUnit.InitializeUnit;
using UnityEngine;

namespace ForUnit.Spawn
{
    public class EnemyUnitSpawner : SpawnUnit
    {
        [SerializeField] private InitializeEnemyUnit _initializeEnemyUnit;

        protected override void Start()
        {
            base.Start();
            for (int i = 0; i < 49; i++)
            {
                SpawnUnits(1, i);
            }
        }

        protected override void SpawnUnits(int unitCount, int unitType)
        {
            for (int i = 0; i < unitCount; i++)
            {
                var unit = Instantiate(_unit, _pointForSpawn);
                unit.transform.SetParent(_unitsTransformContainer);
                unit.transform.rotation = Quaternion.Euler(0, 180, 0);
                _initializeEnemyUnit.InitializeUnit(unitType, unit);
                UnitsContainer.AddEnemyUnit(unit);
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
                position.z += 1.4f;
            }

            _pointForSpawn.position = position;
        }
    }
}