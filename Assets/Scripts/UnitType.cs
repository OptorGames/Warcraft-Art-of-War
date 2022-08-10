using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "ScriptableObject/UnitType")]
public class UnitType : ScriptableObject
{
    [SerializeField] private string _unitName;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _healthNumber;
    [SerializeField] private float _distanceForStop;
    [SerializeField] private float _distanceForAttack;
    [SerializeField] private float _attackPower;
    [SerializeField] private float _timeForAttack;
    [SerializeField] private GameObject _enemyUnitAppearance;
    [SerializeField] private GameObject _ourUnitAppearance;
    public string UnitName => _unitName;
    public float MoveSpeed => _moveSpeed;
    public float HealthNumber => _healthNumber;
    public float DistanceForStop => _distanceForStop;
    public float DistanceForAttack => _distanceForAttack;
    public float AttackPower => _attackPower;

    public float TimeForAttack => _timeForAttack;

    public GameObject EnemyUnitAppearance => _enemyUnitAppearance;

    public GameObject OurUnitAppearance => _ourUnitAppearance;
}