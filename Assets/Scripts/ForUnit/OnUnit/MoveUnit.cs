using UnityEngine;
using UnityEngine.AI;

namespace ForUnit.OnUnit
{
    public class MoveUnit : MonoBehaviour
    {
        public NavMeshAgent NavMeshAgent { get; set; }
        public GameObject TargetUnit { get; set; }
        private AttackUnit _attackUnit;
        private Animator _animator;
        private GameObject _previousTarget;

        private void Start()
        {
            _animator = GetComponent<UnitControl>().Animator;
            _attackUnit = GetComponent<AttackUnit>();
            
        }

        private void Update()
        {
            if (TargetUnit != null)
            {
                GoToTarget();
            }
        }

        private void GoToTarget()
        {
            NavMeshAgent.destination = TargetUnit.transform.position;
            var _distanceToEnemy = Vector3.Distance(TargetUnit.transform.position, transform.position);
            if (_distanceToEnemy > _attackUnit.DistanceForAttack && TargetUnit != _previousTarget&& NavMeshAgent.enabled)
            {
                _animator.Play("Walk");
                _previousTarget = TargetUnit;
            }
        }
    }
}