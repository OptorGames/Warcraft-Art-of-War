using System;
using UnityEngine;

namespace Unit.ForUnit
{
    public class HealthUnit : MonoBehaviour
    {
        public float Health { get; private set; }
        public event Action<GameObject> OnDeath;
   
        public void SetHealth(float value)
        {
            Health = value;

        }

        public void LoseHealth(float value)
        {
            Health -= value;
            if (Health <= 0)
            {
                OnDeath?.Invoke(gameObject);
                    // Destroy(gameObject);
                    gameObject.SetActive(false);
            }
        }
    }
}