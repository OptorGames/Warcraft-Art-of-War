using UnityEngine;

namespace LevelGame.Unit.Attack
{
    public class MeleeAttack : AttackUnit
    {
        /*public GameObject TargetUnit { get; set; }
        private float _distanceToEnemy;
        private HealthUnit _healthUnit;

        private void Update()
        {
            if (TargetUnit != null)
            {
                _distanceToEnemy = Vector3.Distance(TargetUnit.transform.position, transform.position);
                if (_distanceToEnemy < 2.5f)
                {
                    DelayTime += Time.deltaTime;
                    if (DelayTime >= 0.5f)
                    {
                        Attack();
                        DelayTime = 0;
                    }
                }
            }
        }

        private void Attack()
        {
            _healthUnit = TargetUnit.gameObject.GetComponent<HealthUnit>();
            _healthUnit.LoseHealth(PowerAttack);
        }*/
    }
}