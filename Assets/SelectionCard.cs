using System;
using ForUnit;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectionCard : MonoBehaviour
{
   public UnitTypes UnitType { get; set; }
   [SerializeField] private Button _selectButton;
   [SerializeField] private Image _mainImage;
   [SerializeField] private TMP_Text _coinText;
   public Image MainImage => _mainImage;
   public TMP_Text CoinText => _coinText;
   public static event Action<int> OnSelectUnit;

   private void Start()
   {
      _selectButton.onClick.AddListener(ClickButton);
   }

   private void ClickButton()
   {
      OnSelectUnit?.Invoke((int)UnitType-1);
   }

   private void OnDestroy()
   {
      _selectButton.onClick.RemoveListener(ClickButton);
   }
}
