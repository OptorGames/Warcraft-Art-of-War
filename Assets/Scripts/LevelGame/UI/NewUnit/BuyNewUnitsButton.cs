using System;
using UnityEngine;
using UnityEngine.UI;

namespace LevelGame.UI.NewUnit
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