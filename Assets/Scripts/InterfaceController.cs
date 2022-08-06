using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class InterfaceController : MonoBehaviour
{
    private UnitsContainer _unitsContainer;
    [SerializeField] private Transform _transformForCell;
    [SerializeField] private GameObject _cellForUnit;
    [SerializeField] private TMP_Text _enemyUnitCountText;
    [SerializeField] private TMP_Text _ourUnitCountText;
    private const int CountCell = 49;

    private void Start()
    {
        _unitsContainer = UnitsContainer.Instance;
        for (int i = 0; i < CountCell; i++)
        {
            Instantiate(_cellForUnit, _transformForCell);
        }

        _enemyUnitCountText.text = _unitsContainer.EnemyUnits.Count.ToString();
        _ourUnitCountText.text = _unitsContainer.OurUnits.Count.ToString();
    }

    private void Update()
    {
        _enemyUnitCountText.text = _unitsContainer.EnemyUnits.Count.ToString();
        _ourUnitCountText.text = _unitsContainer.OurUnits.Count.ToString();
        IfLose();
        IfWin();
    }

    private void IfLose()
    {
        if (_unitsContainer.OurUnits.Count <= 0)
        {
            Time.timeScale = 0;
            print("lose!");
        }
    }

    private void IfWin()
    {
        if (_unitsContainer.EnemyUnits.Count <= 0)
        {
            Time.timeScale = 0;
            print("win!");
        }
    }
}