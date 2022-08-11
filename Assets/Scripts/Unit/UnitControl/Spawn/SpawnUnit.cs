using Unit;
using UnityEngine;

namespace LevelGame.Unit.Spawn
{
    public abstract class SpawnUnit : MonoBehaviour
    {
        protected UnitsContainer UnitsContainer;
        [SerializeField] protected UnitsInitializer _unitsInitializer;
        [SerializeField] protected GameObject _unit;
        [SerializeField] protected Transform _unitsTransformContainer;
        [SerializeField] protected Transform _pointForSpawn;
        


        protected virtual void Start()
        {
            UnitsContainer = UnitsContainer.Instance;
        }

        protected abstract void SpawnUnits(int unitCount, int unitType);


        protected abstract void ChangeSpawnPosition();
    }
}