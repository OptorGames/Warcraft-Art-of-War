using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LevelGame
{
    public class BuyNewUnitsButton : MonoBehaviour
    {
        [SerializeField] private Button _companyButton;
        [SerializeField] private TMP_Text _buttonText;
        public static event Action OnNewUnit;

        private void Start()
        {
            _companyButton.onClick.AddListener(ClickButton);
            _buttonText.text = 50.ToString();
        }

        private void ClickButton()
        {
            OnNewUnit?.Invoke();
            _buttonText.text = 50.ToString();
        }

        private void OnDestroy()
        {
            _companyButton.onClick.RemoveListener(ClickButton);
        }
    }
}