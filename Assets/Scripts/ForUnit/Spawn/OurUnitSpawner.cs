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