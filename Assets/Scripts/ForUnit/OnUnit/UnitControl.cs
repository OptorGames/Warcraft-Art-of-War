using System;
using LevelGame;
using Unit;
using UnityEngine;
using UnityEngine.AI;

namespace ForUnit.OnUnit
{
    public class UnitControl : MonoBehaviour
    {
        public UnitType UnitName { get; set; }
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