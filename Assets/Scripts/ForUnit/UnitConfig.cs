using ForUnit;
using UnityEngine;

namespace Unit
{
    [CreateAssetMenu(fileName = "New Unit", menuName = "ScriptableObject/UnitType")]
    public class UnitConfig : ScriptableObject
    {
        [SerializeField] private UnitType _unitName;
        [SerializeField] private UnitStat _unitStats;
        [SerializeField] private float _timeForAttack;
        [SerializeField] private float _distanceForStop;
        [SerializeField] private float _distanceForAttack;
        [SerializeField] private GameObject _enemyUnitAppearance;
        [SerializeField] private GameObject _ourUnitAppearance;
        
        public UnitType UnitName => _unitName;
        public UnitStat UnitStats => _unitStats;
        public float TimeForAttack => _timeForAttack;
        public float DistanceForStop => _distanceForStop;
        public float DistanceForAttack => _distanceForAttack;
        public GameObject EnemyUnitAppearance => _enemyUnitAppearance;
        public GameObject OurUnitAppearance => _ourUnitAppearance;
    }
}