using System.Collections.Generic;
using LevelGame.Unit;
using LevelGame.Unit.Attack;
using UnityEngine;
using UnityEngine.AI;

public class UnitsInitializer : MonoBehaviour
{
    [SerializeField] private List<UnitType> _unitTypes;

    public void InitializeUnit(int unitIndex, GameObject starterUnit, string EnemyOrOur)
    {
        

        var navMeshAgent = starterUnit.AddComponent<NavMeshAgent>();
        navMeshAgent.enabled = false;
        navMeshAgent.speed = _unitTypes[unitIndex].MoveSpeed;
        navMeshAgent.stoppingDistance = _unitTypes[unitIndex].DistanceForStop;

        var moveUnit = starterUnit.AddComponent<MoveUnit>();
        moveUnit.NavMeshAgent = navMeshAgent;

        var healthUnit = starterUnit.AddComponent<HealthUnit>();
        healthUnit.SetHealth(_unitTypes[unitIndex].HealthNumber);

        var attackUnit = starterUnit.AddComponent<AttackUnit>();
        attackUnit.SetPower(_unitTypes[unitIndex].AttackPower);
        attackUnit.DistanceForAttack = _unitTypes[unitIndex].DistanceForAttack;
        attackUnit.TimeForAttack = _unitTypes[unitIndex].TimeForAttack;

        var unitControl = starterUnit.AddComponent<UnitControl>();
        unitControl.NavMeshAgent = navMeshAgent;
        switch (EnemyOrOur)
        {
            case "Enemy":
                starterUnit.name = "enemy"+_unitTypes[unitIndex].UnitName;
                Instantiate(_unitTypes[unitIndex].EnemyUnitAppearance, starterUnit.transform);
                starterUnit.tag = "EnemyUnit";
                break;
            case "Our":
                starterUnit.name = "our"+_unitTypes[unitIndex].UnitName;
                Instantiate(_unitTypes[unitIndex].OurUnitAppearance, starterUnit.transform);
                starterUnit.tag = "OurUnit";
                break;
        }
    }
}