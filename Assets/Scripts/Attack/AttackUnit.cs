﻿using UnityEngine;

namespace Attack
{
    public class AttackUnit : MonoBehaviour
    {
        public float PowerAttack { get; private set; }
        public GameObject TargetUnit { get; set; }

        protected void Start()
        {
            SetPower(10);
        }

        private void SetPower(float value)
        {
            PowerAttack = value;
        }
    }
}