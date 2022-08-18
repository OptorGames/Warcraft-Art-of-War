using UnityEngine;

namespace ForUnit
{
    [CreateAssetMenu(fileName = "New Unit", menuName = "ScriptableObject/UnitType")]
    public class UnitConfig : ScriptableObject
    {
        [SerializeField] private UnitTypes _unitName;
        [SerializeField] private UnitStat _unitStats;
        [SerializeField] private GameObject _enemyUnitAppearance;
        [SerializeField] private GameObject _ourUnitAppearance;
        
        public UnitTypes UnitName => _unitName;
        public UnitStat UnitStats => _unitStats;
        public GameObject EnemyUnitAppearance => _enemyUnitAppearance;
        public GameObject OurUnitAppearance => _ourUnitAppearance;
    }
}