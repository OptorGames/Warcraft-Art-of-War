using System;
using ForUnit;
using ForUnit.Spawn;
using LevelGame.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectionCardController : MonoBehaviour
{
    [SerializeField] private SelectionCard _selectionCard;
    [SerializeField] private SpawnNewOurUnit _spawnNewOurUnit;
    [SerializeField] private GameObject _selectionCardView;
    [SerializeField] private Transform _cardContainer;
    [SerializeField] private Image _cardImageBeforeGame;
    [SerializeField] private Image _cardImageInGame;
    [SerializeField] private TMP_Text _cardTextBeforeGame;
    [SerializeField] private TMP_Text _cardTextInGame;
    private UnitsContainer _unitsContainer;
    private InterfaceController _interfaceController;

    private void Start()
    {
        _unitsContainer = UnitsContainer.Instance;
        _interfaceController = InterfaceController.Instance;
        SelectionCard.OnSelectUnit += SetNewCard;
        CreateSelectionView();
        SetNewCard(0);
    }

    private void CreateSelectionView()
    {
        for (int i = 0; i < _interfaceController.Sprites.Count; i++)
        {
            var card = Instantiate(_selectionCard, _cardContainer);
            card.UnitType = (UnitTypes) i + 1;
            card.MainImage.sprite = _interfaceController.Sprites[i];
            foreach (var unitType in _unitsContainer.UnitTypes)
            {
                if (card.UnitType == unitType.UnitName)
                {
                    card.CoinText.text = unitType.NewUnitCost.ToString();
                }
            }
        }
    }

    private void SetNewCard(int unitIndex)
    {
        _spawnNewOurUnit.UnitIndex = unitIndex;
        _cardImageBeforeGame.sprite = _interfaceController.Sprites[unitIndex];
        _cardImageInGame.sprite = _interfaceController.Sprites[unitIndex];
        foreach (var unit in _unitsContainer.UnitTypes)
        {
            if (unit.UnitName == (UnitTypes) unitIndex + 1)
            {
                _cardTextBeforeGame.text = unit.NewUnitCost.ToString();
                _cardTextInGame.text = unit.NewUnitCost.ToString();
                _spawnNewOurUnit.NewUnitCost = unit.NewUnitCost;
            }
        }

        _selectionCardView.SetActive(false);
    }

    private void OnDisable()
    {
        SelectionCard.OnSelectUnit -= SetNewCard;
    }
}