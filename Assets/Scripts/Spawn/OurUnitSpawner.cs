namespace Spawn
{
    public class OurUnitSpawner : SpawnUnit
    {
        protected override void SpawnUnits(int unitCount)
        {
            for (int i = 0; i < unitCount; i++)
            {
                _searchEnemyForUnits.OurUnits.Add(Instantiate(_unit, _pointForSpawn));
                _searchEnemyForUnits.OurUnits[i].transform.SetParent(_unitsContainer);
                ChangeSpawnPosition();
                //yield return new WaitForSeconds(0.3f);
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