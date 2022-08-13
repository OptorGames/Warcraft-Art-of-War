using UnityEngine;

namespace ForUnit.Spawn
{
    public abstract class SpawnUnit : MonoBehaviour
    {
        protected UnitsContainer UnitsContainer;
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