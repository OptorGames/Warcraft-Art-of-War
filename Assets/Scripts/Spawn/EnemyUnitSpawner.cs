using System.Collections;
using UnityEngine;

namespace Spawn
{
    /*public class EnemyUnitSpawner : SpawnUnit
    {
        protected override IEnumerator SpawnUnits(int unitCount)
        {
            for (int i = 0; i < unitCount; i++)
            {
                _searchEnemyForUnits.EnemyUnits[i] = Instantiate(_unit, _pointForSpawn);
                _searchEnemyForUnits.EnemyUnits[i].transform.SetParent(_unitsContainer);
                ChangeSpawnPosition();
                yield return new WaitForSeconds(0.3f);
            }
        }

        protected override void ChangeSpawnPosition()
        {
            var position = _pointForSpawn.position;
            position.x += 1.4f;
            _pointForSpawn.position = position;
        }
    }*/
}