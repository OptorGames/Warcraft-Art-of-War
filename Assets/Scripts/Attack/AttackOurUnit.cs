using System.Collections;
using UnityEngine;

namespace Attack
{
    public class AttackOurUnit : AttackUnit
    {
        private HealthUnit _healthOurUnit;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("OurUnit") == TargetUnit)
            {
                _healthOurUnit = other.gameObject.GetComponent<HealthUnit>();
                StartCoroutine(Attack());
            }
        }

        private IEnumerator Attack()
        {
            while (_healthOurUnit.Health > 0)
            {
                _healthOurUnit.LoseHealth(PowerAttack);
                yield return new WaitForSeconds(1);
            }
        }
    }
}