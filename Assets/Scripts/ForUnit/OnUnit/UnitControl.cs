using System;
using LevelGame;
using UnityEngine;
using UnityEngine.AI;

namespace ForUnit.OnUnit
{
    public class UnitControl : MonoBehaviour
    {
        public UnitTypes UnitName { get; set; }
        public NavMeshAgent NavMeshAgent { get; set; }
        public Animator Animator { get; set; }

        private void Start()
        {

            if (GameStageController.StartFight)
            {
                NavMeshAgent.enabled = true;
            }
        }
    }
}