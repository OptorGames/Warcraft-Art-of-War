using System.Collections;
using UnityEngine;

namespace Attack
{
    public class AttackEnemyUnit : AttackUnit
    {
        private HealthUnit _healthEnemyUnit;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("EnemyUnit") == TargetUnit)
            {
                _healthEnemyUnit = other.gameObject.GetComponent<HealthUnit>();
                StartCoroutine(Attack());
            }
        }

        private IEnumerator Attack()
        {
            while (_healthEnemyUnit.Health > 0)
            {
                _healthEnemyUnit.LoseHealth(PowerAttack);
                yield return new WaitForSeconds(1);
            }
        }
    }
}