using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace ForUnit.OnUnit
{
    public class AttackUnit : MonoBehaviour
    {
        public float PowerAttack { get; private set; }
        public float DistanceForAttack { get; set; }
        public float TimeForAttack { get; set; }
        public GameObject TargetUnit { get; set; }
        private HealthUnit _healthTargetUnit;
        private float _delayTime;
        private float _distanceToEnemy;
        private Animator _animator;
        private float _rotationSpeed=10;

        private void Start()
        {
            _animator = GetComponent<UnitControl>().Animator;
        }

        public void SetPower(float value)
        {
            PowerAttack = value;
        }

        private void Update()
        {
            if (TargetUnit != null)
            {
                _distanceToEnemy = Vector3.Distance(TargetUnit.transform.position, transform.position);
                if (_distanceToEnemy < DistanceForAttack)
                {
                    _delayTime += Time.deltaTime;
                    if (_delayTime >= TimeForAttack)
                    {
                        Attack();
                        _delayTime = 0;
                    }
                }
            }
        }

        private void Attack()
        {
            LookAtEnemy();
            _animator.Play("Attack");
            _healthTargetUnit = TargetUnit.gameObject.GetComponent<HealthUnit>();
            _healthTargetUnit.LoseHealth(PowerAttack);
        }

        private void LookAtEnemy()
        {
            Vector3 direction = TargetUnit.transform.position - transform.position;
            direction.y = 0;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _rotationSpeed * Time.deltaTime);
        }
    }
}