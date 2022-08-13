using System;
using UnityEngine;

namespace ForUnit
{
    [Serializable]
    public class UnitStat
    {
        [SerializeField] private int _level = 1;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _healthNumber;
        [SerializeField] private float _attackPower;

        public int Level => _level;
        public float MoveSpeed => _moveSpeed;
        public float HealthNumber => _healthNumber;
        public float AttackPower => _attackPower;

        public void Upgrade()
        {
            _level++;
        }
    }
}