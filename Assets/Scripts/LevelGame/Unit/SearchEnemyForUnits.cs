using System.Collections.Generic;
using LevelGame.Unit.Attack;
using UnityEngine;

namespace LevelGame.Unit
{
    public class SearchEnemyForUnits : MonoBehaviour
    {
        private UnitsContainer _unitsContainer;
        private GameObject _closest;

        private void Start()
        {
            _unitsContainer = UnitsContainer.Instance;
        }

        private void Update()
        {
            if (GameStageController.StartFight)
            {
                SetOpponents();
            }
        }


        private void SetOpponents()
        {
            foreach (var ourUnit in _unitsContainer.OurUnits)
            {
                var enemy = SearchOpponents(ourUnit.transform, _unitsContainer.EnemyUnits);
                ourUnit.GetComponent<MoveUnit>().TargetUnit = enemy;
                ourUnit.GetComponent<AttackUnit>().TargetUnit = enemy;
            }

            foreach (var enemyUnit in _unitsContainer.EnemyUnits)
            {
                var our = SearchOpponents(enemyUnit.transform, _unitsContainer.OurUnits);
                enemyUnit.GetComponent<MoveUnit>().TargetUnit = our;
                enemyUnit.GetComponent<AttackUnit>().TargetUnit = our;
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
}