using UnityEngine;
using UnityEngine.AI;

namespace LevelGame.Unit
{
    public class MoveUnit : MonoBehaviour
    {
        public NavMeshAgent NavMeshAgent { get; set; }
        public GameObject TargetUnit { get; set; }

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
        }
    }
}