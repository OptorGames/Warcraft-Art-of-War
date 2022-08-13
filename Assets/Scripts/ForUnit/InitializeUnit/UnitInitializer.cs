using System.Collections.Generic;
using LevelGame.Unit;
using Unit.ForUnit;
using Unit.ForUnit.Attack;
using UnityEngine;
using UnityEngine.AI;

namespace Unit.InitializeUnit
{
    public abstract class UnitInitializer : MonoBehaviour
    {
        [SerializeField] protected List<UnitConfig> _unitTypes;
        protected NavMeshAgent NavMeshAgent;
        protected MoveUnit MoveUnit;
        protected HealthUnit HealthUnit;
        protected AttackUnit AttackUnit;
        protected global::ForUnit.OnUnit.UnitControl UnitControl;

        public virtual void InitializeUnit(int unitIndex, GameObject starterUnit)
        {
            NavMeshAgent = starterUnit.AddComponent<NavMeshAgent>();
            NavMeshAgent.enabled = false;
            MoveUnit = starterUnit.AddComponent<MoveUnit>();
            MoveUnit.NavMeshAgent = NavMeshAgent;
            HealthUnit = starterUnit.AddComponent<HealthUnit>();
            AttackUnit = starterUnit.AddComponent<AttackUnit>();
            UnitControl = starterUnit.AddComponent<global::ForUnit.OnUnit.UnitControl>();
            UnitControl.NavMeshAgent = NavMeshAgent;
        }

        protected abstract void UpgradeStats(int unitIndex);

    }
}