using ForUnit.OnUnit;
using Unit.InitializeUnit;
using UnityEngine;

namespace ForUnit.InitializeUnit
{
    public class InitializeOurUnit : UnitInitializer
    {
        public override void InitializeUnit(int unitIndex, GameObject starterUnit)
        {
            base.InitializeUnit(unitIndex, starterUnit);
            var statsCopy = Instantiate(_unitTypes[unitIndex]);
            UpgradeStats(unitIndex);
            UnitControl.UnitName = statsCopy.UnitName;
            NavMeshAgent.stoppingDistance = _unitTypes[unitIndex].DistanceForStop;
            AttackUnit.DistanceForAttack = _unitTypes[unitIndex].DistanceForAttack;
            AttackUnit.TimeForAttack = _unitTypes[unitIndex].TimeForAttack;

            starterUnit.name = "our" + _unitTypes[unitIndex].UnitName;
            Instantiate(_unitTypes[unitIndex].OurUnitAppearance, starterUnit.transform);
            starterUnit.tag = "OurUnit";
        }

        protected override void UpgradeStats(int unitIndex)
        {
            var level = _unitTypes[unitIndex].UnitStats.Level;
            NavMeshAgent.speed = _unitTypes[unitIndex].UnitStats.MoveSpeed;
            HealthUnit.SetHealth(_unitTypes[unitIndex].UnitStats.HealthNumber);
            AttackUnit.SetPower(_unitTypes[unitIndex].UnitStats.AttackPower);
        }
    }
}