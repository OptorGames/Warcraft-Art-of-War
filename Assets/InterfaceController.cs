using System;
using TMPro;
using UnityEngine;

public class InterfaceController : MonoBehaviour
{
    [SerializeField] private SearchEnemyForUnits _searchEnemyForUnits;
    [SerializeField] private Transform _transformForCell;
    [SerializeField] private GameObject _cellForUnit;
    [SerializeField] private TMP_Text _enemyUnitCountText;
    [SerializeField] private TMP_Text _ourUnitCountText;
    private const int CountCell = 49;

    private void Start()
    {
        for (int i = 0; i < CountCell; i++)
        {
            Instantiate(_cellForUnit, _transformForCell);
        }

        _enemyUnitCountText.text = _searchEnemyForUnits.EnemyUnits.Count.ToString();
        _ourUnitCountText.text = _searchEnemyForUnits.OurUnits.Count.ToString();
    }

    private void Update()
    {
        _enemyUnitCountText.text = _searchEnemyForUnits.EnemyUnits.Count.ToString();
        _ourUnitCountText.text = _searchEnemyForUnits.OurUnits.Count.ToString();
    }
}