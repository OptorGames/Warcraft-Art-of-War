using UnityEngine;

public class HealthUnit : MonoBehaviour
{
    public float Health { get; private set; }

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
            Destroy(gameObject);
        }
    }
}