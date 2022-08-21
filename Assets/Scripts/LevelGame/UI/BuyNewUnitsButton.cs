using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace LevelGame.UI
{
    public class BuyNewUnitsButton : MonoBehaviour
    {
        [SerializeField] private Button _newUnitButton;
        public static event Action OnNewUnit;

        private void Start()
        {
            _newUnitButton.onClick.AddListener(ClickButton);
        }

        private void ClickButton()
        {
            OnNewUnit?.Invoke();
        }

        private void OnDestroy()
        {
            _newUnitButton.onClick.RemoveListener(ClickButton);
        }
    }
}