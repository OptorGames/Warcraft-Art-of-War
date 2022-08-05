using UnityEngine;
using UnityEngine.AI;

public class MoveUnit : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
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
        _navMeshAgent.destination = TargetUnit.transform.position;
    }
}