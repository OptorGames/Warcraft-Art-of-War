using System;
using UnityEngine;

namespace ForUnit.OnUnit
{
    public class HealthUnit : MonoBehaviour
    {
        [SerializeField] private float _health;
        public float Health { get; private set; }
        public event Action<GameObject> OnDeath;
        private UnitControl _unitControl;
        private Animator _animator;

        private void Start()
        {
            _unitControl = GetComponent<UnitControl>();
            _animator = _unitControl.Animator;
            _health = Health;
        }

        public void SetHealth(float value)
        {
            Health = value;

        }

        public void LoseHealth(float value)
        {
            _health = Health;
            Health -= value;
            if (Health <= 0)
            {
                GetComponent<AttackUnit>().enabled = false;
                _animator.Play("Die");
                OnDeath?.Invoke(gameObject);
                Destroy(gameObject,1.5f);
            }
        }
    }
}