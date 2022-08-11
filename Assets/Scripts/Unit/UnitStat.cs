using System;
using UnityEngine;

namespace Unit
{
    [Serializable]
    public class UnitStat
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _healthNumber;
        [SerializeField] private float _attackPower;


        public float MoveSpeed => _moveSpeed;
        public float HealthNumber => _healthNumber;
        public float AttackPower => _attackPower;

        public void SetValue(float moveSpeed, float healthNumber, float attackPower)
        {
            _moveSpeed = moveSpeed;
            _healthNumber = healthNumber;
            _attackPower = attackPower;
        }
    }
}