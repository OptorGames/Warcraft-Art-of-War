using UnityEngine;
using UnityEngine.AI;

namespace LevelGame.Unit
{
    public class UnitControl : MonoBehaviour
    {
        public NavMeshAgent NavMeshAgent { get; set; }

        private void Start()
        {
            if (GameStageController.StartFight)
            {
                NavMeshAgent.enabled = true;
            }
        }
    }
}
