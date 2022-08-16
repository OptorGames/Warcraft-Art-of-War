using System;
using UnityEngine;

namespace ForUnit
{
    [Serializable]
    public class UnitStat
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _healthNumber;
        [SerializeField] private float _attackPower;
        [SerializeField] private float _timeForAttack;
        [SerializeField] private float _distanceForStop;
        [SerializeField] private float _distanceForAttack;
        public float MoveSpeed => _moveSpeed;
        public float HealthNumber => _healthNumber;
        public float AttackPower => _attackPower;
        public float TimeForAttack => _timeForAttack;
        public float DistanceForStop => _distanceForStop;
        public float DistanceForAttack => _distanceForAttack;
    }
}