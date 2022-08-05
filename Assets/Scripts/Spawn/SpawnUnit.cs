using System.Collections;
using UnityEngine;

namespace Spawn
{
    public abstract class SpawnUnit : MonoBehaviour
    {
        [SerializeField] protected SearchEnemyForUnits _searchEnemyForUnits;
        [SerializeField] protected GameObject _unit;
        [SerializeField] protected Transform _unitsContainer;
        [SerializeField] protected Transform _pointForSpawn;
        [SerializeField] protected int _countUnit;


        private void Awake()
        {
            SpawnUnits(_countUnit);
        }
        
        protected abstract void SpawnUnits(int unitCount);
        

        protected abstract void ChangeSpawnPosition();
    }
}