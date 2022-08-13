using UnityEngine;

namespace Unit.ForUnit.Attack
{
    public class AttackUnit : MonoBehaviour
    {
        public float PowerAttack { get; private set; }
        public float DistanceForAttack { get; set; }
        public float TimeForAttack { get; set; }
        public GameObject TargetUnit { get; set; }
        private HealthUnit _healthUnit;
        private float _delayTime;
        private float _distanceToEnemy;
        
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
            _healthUnit = TargetUnit.gameObject.GetComponent<HealthUnit>();
            _healthUnit.LoseHealth(PowerAttack);
        }
    }
}