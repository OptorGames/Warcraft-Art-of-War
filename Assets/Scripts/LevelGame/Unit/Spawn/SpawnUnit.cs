using LevelGame.Unit;
using UnityEngine;

namespace Spawn
{
    public abstract class SpawnUnit : MonoBehaviour
    {
        protected UnitsContainer UnitsContainer;
        [SerializeField] protected GameObject _unit;
        [SerializeField] protected Transform _unitsTransformContainer;
        [SerializeField] protected Transform _pointForSpawn;
        [SerializeField] protected int _countUnit;


        protected virtual void Start()
        {
            UnitsContainer = UnitsContainer.Instance;
        }

        protected abstract void SpawnUnits(int unitCount);


        protected abstract void ChangeSpawnPosition();
    }
}