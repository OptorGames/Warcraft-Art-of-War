using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitsContainer : MonoBehaviour
{
    public static UnitsContainer Instance;
    [SerializeField] private List<GameObject> _ourUnits;
    [SerializeField] private List<GameObject> _enemyUnits;
    public List<GameObject> OurUnits => _ourUnits;
    public List<GameObject> EnemyUnits => _enemyUnits;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance == this)
        {
            Destroy(gameObject);
        }
    }

    public void AddOurUnit(GameObject unit)
    {
        _ourUnits.Add(unit);
        unit.GetComponent<HealthUnit>().OnDeath += RemoveOurUnit;
    }

    public void AddEnemyUnit(GameObject unit)
    {
        _enemyUnits.Add(unit);
        unit.GetComponent<HealthUnit>().OnDeath += RemoveEnemyUnit;
    }

    public void RemoveOurUnit(GameObject unit)
    {
        unit.GetComponent<HealthUnit>().OnDeath -= RemoveOurUnit;
        _ourUnits.Remove(unit);
    }

    public void RemoveEnemyUnit(GameObject unit)
    {
        unit.GetComponent<HealthUnit>().OnDeath -= RemoveEnemyUnit;
        _enemyUnits.Remove(unit);
    }
}