using System.Collections.Generic;
using UnityEngine;

namespace ForUnit.InitializeUnit
{
    public class InitializeEnemyUnit : UnitInitializer
    {
        private int _gameLevel;
        [SerializeField] private List<UnitConfig> _unitTypes;



        public override void InitializeUnit(int unitIndex, GameObject starterUnit)
        {
            base.InitializeUnit(unitIndex, starterUnit);

            var statsCopy = Instantiate(_unitTypes[unitIndex]);

            NavMeshAgent.speed = statsCopy.UnitStats.MoveSpeed;
            NavMeshAgent.stoppingDistance = statsCopy.UnitStats.DistanceForStop;
            AttackUnit.DistanceForAttack = statsCopy.UnitStats.DistanceForAttack;
            AttackUnit.TimeForAttack = statsCopy.UnitStats.TimeForAttack;
            UpgradeStats( statsCopy);

            starterUnit.name = "enemy" + statsCopy.UnitName;

            var appearance = Instantiate(statsCopy.EnemyUnitAppearance, starterUnit.transform);
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