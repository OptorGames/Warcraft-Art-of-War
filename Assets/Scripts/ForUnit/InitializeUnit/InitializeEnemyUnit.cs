using UnityEngine;

namespace Unit.InitializeUnit
{
    public class InitializeEnemyUnit:UnitInitializer
    {
        public override void InitializeUnit(int unitIndex, GameObject starterUnit)
        {
            base.InitializeUnit(unitIndex, starterUnit);
            NavMeshAgent.speed = _unitTypes[unitIndex].UnitStats.MoveSpeed;
            NavMeshAgent.stoppingDistance = _unitTypes[unitIndex].DistanceForStop;
            HealthUnit.SetHealth(_unitTypes[unitIndex].UnitStats.HealthNumber);
            AttackUnit.SetPower(_unitTypes[unitIndex].UnitStats.AttackPower);
            AttackUnit.DistanceForAttack = _unitTypes[unitIndex].DistanceForAttack;
            AttackUnit.TimeForAttack = _unitTypes[unitIndex].TimeForAttack;
            starterUnit.name = "enemy" + _unitTypes[unitIndex].UnitName;
            Instantiate(_unitTypes[unitIndex].EnemyUnitAppearance, starterUnit.transform);
            starterUnit.tag = "EnemyUnit";
        }

        protected override void UpgradeStats(int unitIndex)
        {
            
        }
    }
}