namespace Spawn
{
    public class EnemyUnitSpawner : SpawnUnit
    {
        protected override void Start()
        {
            base.Start();
            SpawnUnits(_countUnit);
        }

        protected override void SpawnUnits(int unitCount)
        {
            for (int i = 0; i < unitCount; i++)
            {
                var unit = Instantiate(_unit, _pointForSpawn);
                unit.transform.SetParent(_unitsTransformContainer);
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