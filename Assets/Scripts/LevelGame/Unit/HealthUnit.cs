using System;
using UnityEngine;

namespace LevelGame.Unit
{
    public class HealthUnit : MonoBehaviour
    {
        [SerializeField] private float _health;
        public float Health { get; private set; }
        public event Action<GameObject> OnDeath;
   
        public void SetHealth(float value)
        {
            Health = value;
            _health = Health;
            _health = Health;
        }

        public void LoseHealth(float value)
        {
            Health -= value;
            _health = Health;
            if (Health <= 0)
            {
                OnDeath?.Invoke(gameObject);
                Destroy(gameObject);
            }
        }
    }
}