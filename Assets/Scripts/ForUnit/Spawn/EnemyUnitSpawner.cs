using ForUnit.InitializeUnit;
using ForUnit.Spawn;
using LevelGame.Unit.Spawn;
using UnityEngine;

namespace Unit.UnitControl.Spawn
{
    public class EnemyUnitSpawner : SpawnUnit
    {
        [SerializeField] protected InitializeEnemyUnit _initializeEnemyUnit;
        [SerializeField] private int _countMeleeUnit;
        [SerializeField] private int _countRangeUnit;
        protected override void Start()
        {
            base.Start();
            SpawnUnits(_countMeleeUnit,0);
            SpawnUnits(_countRangeUnit,1);
        }

        protected override void SpawnUnits(int unitCount,int unitType)
        {
            for (int i = 0; i < unitCount; i++)
            {
                var unit = Instantiate(_unit, _pointForSpawn);
                unit.transform.SetParent(_unitsTransformContainer);
                unit.transform.rotation=Quaternion.Euler(0,180,0);
                _initializeEnemyUnit.InitializeUnit(unitType,unit);
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