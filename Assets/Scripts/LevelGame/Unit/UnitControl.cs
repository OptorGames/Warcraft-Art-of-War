using LevelGame;
using UnityEngine;
using UnityEngine.AI;

public class UnitControl : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;

    public NavMeshAgent NavMeshAgent => _navMeshAgent;

    private void Start()
    {
        if (GameStageController.StartFight)
        {
            _navMeshAgent.enabled = true;
        }
    }
}
