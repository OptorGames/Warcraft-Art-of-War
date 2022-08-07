using System;
using UnityEngine;

public class HealthUnit : MonoBehaviour
{
    public float Health { get; private set; }
    public event Action<GameObject> OnDeath;
    private void Start()
    {
        SetHealth(100);
    }

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
            Destroy(gameObject);
        }
    }
}