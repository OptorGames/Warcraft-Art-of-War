using System.Collections.Generic;
using LevelGame.Unit;
using LevelGame.Unit.Attack;
using UnityEngine;
using UnityEngine.AI;

namespace Unit
{
    public class UnitsInitializer : MonoBehaviour
    {
        [SerializeField] private List<UnitConfig> _unitTypes;

        public void InitializeUnit(int unitIndex, GameObject starterUnit, UnitClass unitClass)
        {
        

            var navMeshAgent = starterUnit.AddComponent<NavMeshAgent>();
            navMeshAgent.enabled = false;
            navMeshAgent.speed = _unitTypes[unitIndex].StartUnitStats.MoveSpeed;
            navMeshAgent.stoppingDistance = _unitTypes[unitIndex].DistanceForStop;

            var moveUnit = starterUnit.AddComponent<MoveUnit>();
            moveUnit.NavMeshAgent = navMeshAgent;

            var healthUnit = starterUnit.AddComponent<HealthUnit>();
            healthUnit.SetHealth(_unitTypes[unitIndex].StartUnitStats.HealthNumber);

            var attackUnit = starterUnit.AddComponent<AttackUnit>();
            attackUnit.SetPower(_unitTypes[unitIndex].StartUnitStats.AttackPower);
            attackUnit.DistanceForAttack = _unitTypes[unitIndex].DistanceForAttack;
            attackUnit.TimeForAttack = _unitTypes[unitIndex].TimeForAttack;

            var unitControl = starterUnit.AddComponent<UnitControl>();
            unitControl.NavMeshAgent = navMeshAgent;
            switch (unitClass)
            {
                case UnitClass.Enemy:
                    starterUnit.name = "enemy"+_unitTypes[unitIndex].UnitName;
                    Instantiate(_unitTypes[unitIndex].EnemyUnitAppearance, starterUnit.transform);
                    starterUnit.tag = "EnemyUnit";
                    break;
                case UnitClass.Our:
                    starterUnit.name = "our"+_unitTypes[unitIndex].UnitName;
                    Instantiate(_unitTypes[unitIndex].OurUnitAppearance, starterUnit.transform);
                    starterUnit.tag = "OurUnit";
                    break;
            }
        }
    }
}