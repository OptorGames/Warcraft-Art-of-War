using ForUnit.OnUnit;
using UnityEngine;
using UnityEngine.AI;

namespace ForUnit.InitializeUnit
{
    public abstract class UnitInitializer : MonoBehaviour
    {
        protected NavMeshAgent NavMeshAgent;
        protected MoveUnit MoveUnit;
        protected HealthUnit HealthUnit;
        protected AttackUnit AttackUnit;
        protected UnitControl UnitControl;
        

        public virtual void InitializeUnit(int unitIndex, GameObject starterUnit)
        {
            NavMeshAgent = starterUnit.AddComponent<NavMeshAgent>();
            NavMeshAgent.enabled = false;
            MoveUnit = starterUnit.AddComponent<MoveUnit>();
            MoveUnit.NavMeshAgent = NavMeshAgent;
            HealthUnit = starterUnit.AddComponent<HealthUnit>();
            AttackUnit = starterUnit.AddComponent<AttackUnit>();
            UnitControl = starterUnit.AddComponent<UnitControl>();
            UnitControl.NavMeshAgent = NavMeshAgent;
        }

        protected abstract void UpgradeStats(UnitConfig unitConfig);
    }
}