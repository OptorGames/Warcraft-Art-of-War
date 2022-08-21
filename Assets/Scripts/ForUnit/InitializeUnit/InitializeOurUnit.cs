using System.Collections.Generic;
using ForUnit.OnUnit;
using UnityEngine;

namespace ForUnit.InitializeUnit
{
    public class InitializeOurUnit : UnitInitializer
    {
        [SerializeField] private List<UnitConfig> _unitTypes;
        private UnitConfig _statsCopy;

        public override void InitializeUnit(int unitIndex, GameObject starterUnit)
        {
            base.InitializeUnit(unitIndex, starterUnit);
            foreach (var unit in _unitTypes)
            {
                if (unit.UnitName == (UnitTypes)unitIndex+1)
                {
                    _statsCopy = Instantiate(unit);
                }
            }

            NavMeshAgent.speed = _statsCopy.UnitStats.MoveSpeed;
            UnitControl.UnitName = _statsCopy.UnitName;
            NavMeshAgent.stoppingDistance = _statsCopy.UnitStats.DistanceForStop;
            AttackUnit.DistanceForAttack = _statsCopy.UnitStats.DistanceForAttack;
            AttackUnit.TimeForAttack = _statsCopy.UnitStats.TimeForAttack;
            UpgradeStats(_statsCopy);

            starterUnit.name = "our" + _statsCopy.UnitName;

            var appearance = Instantiate(_statsCopy.OurUnitAppearance, starterUnit.transform);
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