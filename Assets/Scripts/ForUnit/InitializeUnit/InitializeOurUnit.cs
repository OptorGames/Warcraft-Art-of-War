using System.Collections.Generic;
using ForUnit.OnUnit;
using UnityEngine;

namespace ForUnit.InitializeUnit
{
    public class InitializeOurUnit : UnitInitializer
    {
        [SerializeField] private List<UnitConfig> _unitTypes;

        public override void InitializeUnit(int unitIndex, GameObject starterUnit)
        {
            base.InitializeUnit(unitIndex, starterUnit);
            var statsCopy = Instantiate(_unitTypes[unitIndex]);

            NavMeshAgent.speed = statsCopy.UnitStats.MoveSpeed;
            UnitControl.UnitName = statsCopy.UnitName;
            NavMeshAgent.stoppingDistance = statsCopy.UnitStats.DistanceForStop;
            AttackUnit.DistanceForAttack = statsCopy.UnitStats.DistanceForAttack;
            AttackUnit.TimeForAttack = statsCopy.UnitStats.TimeForAttack;
            UpgradeStats(statsCopy);

            starterUnit.name = "our" + statsCopy.UnitName;

            var appearance = Instantiate(statsCopy.OurUnitAppearance, starterUnit.transform);
            starterUnit.GetComponent<UnitControl>().Animator = appearance.GetComponent<Animator>();

            starterUnit.tag = "OurUnit";
        }

        protected override void UpgradeStats(UnitConfig unitConfig)
        {
            HealthUnit.SetHealth(unitConfig.UnitStats.HealthNumber);
            AttackUnit.SetPower(unitConfig.UnitStats.AttackPower);
        }
    }
}