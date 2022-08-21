using System.Collections.Generic;
using UnityEngine;

namespace ForUnit.InitializeUnit
{
    public class InitializeEnemyUnit : UnitInitializer
    {
        private int _gameLevel;
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
            NavMeshAgent.stoppingDistance = _statsCopy.UnitStats.DistanceForStop;
            AttackUnit.DistanceForAttack = _statsCopy.UnitStats.DistanceForAttack;
            AttackUnit.TimeForAttack = _statsCopy.UnitStats.TimeForAttack;
            UpgradeStats( _statsCopy);

            starterUnit.name = "enemy" + _statsCopy.UnitName;

            var appearance = Instantiate(_statsCopy.EnemyUnitAppearance, starterUnit.transform);
            starterUnit.GetComponent<OnUnit.UnitControl>().Animator = appearance.GetComponent<Animator>();
            
            starterUnit.tag = "EnemyUnit";
        }

        protected override void UpgradeStats( UnitConfig unitConfig)
        {
            _gameLevel = PlayerPrefs.GetInt("GameLevel");
            HealthUnit.SetHealth(unitConfig.UnitStats.HealthNumber);
            AttackUnit.SetPower(unitConfig.UnitStats.AttackPower);
        }
    }
}