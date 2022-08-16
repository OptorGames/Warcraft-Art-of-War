using UnityEngine;

namespace ForUnit
{
    [CreateAssetMenu(fileName = "New Unit", menuName = "ScriptableObject/UnitType")]
    public class UnitConfig : ScriptableObject
    {
        [SerializeField] private UnitType _unitName;
        [SerializeField] private UnitStat _unitStats;
        [SerializeField] private GameObject _enemyUnitAppearance;
        [SerializeField] private GameObject _ourUnitAppearance;
        
        public UnitType UnitName => _unitName;
        public UnitStat UnitStats => _unitStats;
        public GameObject EnemyUnitAppearance => _enemyUnitAppearance;
        public GameObject OurUnitAppearance => _ourUnitAppearance;
    }
}