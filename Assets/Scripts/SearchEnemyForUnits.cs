using System.Collections.Generic;
using Attack;
using UnityEngine;

public class SearchEnemyForUnits : MonoBehaviour
{
    [SerializeField] private List<GameObject> _ourUnits;
    [SerializeField] private List<GameObject> _enemyUnits;
    public List<GameObject> OurUnits => _ourUnits;
    public List<GameObject> EnemyUnits => _enemyUnits;
    public bool StartGame { get; set; }

    private GameObject _closest;

    private void Start()
    {
        SetOpponents();
    }

    private void Update()
    {
        ListCleaning();
    }

    private void ListCleaning()
    {
        foreach (var enemyUnit in _enemyUnits)
        {
            if (enemyUnit == null)
            {
                _enemyUnits.Remove(enemyUnit);
            }
        }

        foreach (var ourUnit in _ourUnits)
        {
            if (ourUnit == null)
            {
                _ourUnits.Remove(ourUnit);
            }
        }

        SetOpponents();
    }

    private void SetOpponents()
    {
        foreach (var ourUnit in _ourUnits)
        {
            var enemy = SearchOpponents(ourUnit.transform, _enemyUnits);
            ourUnit.GetComponent<MoveUnit>().TargetUnit = enemy;
            ourUnit.GetComponent<AttackEnemyUnit>().TargetUnit = enemy;
        }

        foreach (var enemyUnit in _enemyUnits)
        {
            var our = SearchOpponents(enemyUnit.transform, _ourUnits);
            enemyUnit.GetComponent<MoveUnit>().TargetUnit = our;
            enemyUnit.GetComponent<AttackOurUnit>().TargetUnit = our;
        }
    }

    private GameObject SearchOpponents(Transform unit, List<GameObject> otherUnits)
    {
        float distance = Mathf.Infinity;
        Vector3 unitPosition = unit.transform.position;
        foreach (var otherUnit in otherUnits)
        {
            Vector3 diff = otherUnit.transform.position - unitPosition;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                _closest = otherUnit;
                distance = curDistance;
            }
        }

        return _closest;
    }
}