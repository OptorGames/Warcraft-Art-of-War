using System.Collections.Generic;
using Attack;
using UnityEngine;

public class SearchEnemyForUnits : MonoBehaviour
{
    private UnitsContainer _unitsContainer;

    public bool StartGame { get; set; }

    private GameObject _closest;

    private void Start()
    {
        _unitsContainer = UnitsContainer.Instance;
        SetOpponents();
    }

    private void Update()
    {
        SetOpponents();
    }


    private void SetOpponents()
    {
        foreach (var ourUnit in _unitsContainer.OurUnits)
        {
            var enemy = SearchOpponents(ourUnit.transform, _unitsContainer.EnemyUnits);
            ourUnit.GetComponent<MoveUnit>().TargetUnit = enemy;
            ourUnit.GetComponent<MeleeAttack>().TargetUnit = enemy;
        }

        foreach (var enemyUnit in _unitsContainer.EnemyUnits)
        {
            var our = SearchOpponents(enemyUnit.transform, _unitsContainer.OurUnits);
            enemyUnit.GetComponent<MoveUnit>().TargetUnit = our;
            enemyUnit.GetComponent<MeleeAttack>().TargetUnit = our;
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