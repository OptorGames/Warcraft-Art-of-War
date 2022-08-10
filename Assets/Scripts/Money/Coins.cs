using UnityEngine;

namespace Money
{
    public class Coins : MoneySystem
    {
        private void Awake()
        {
            if (!PlayerPrefs.HasKey("Coins"))
            {
                PlayerPrefs.SetInt("Coins", 0);
            }
            _moneyText.text = PlayerPrefs.GetInt("Coins").ToString();
        }
        public override void ChangeMoneyNumber(int valueForChange)
        {
            var newCoinsValue = PlayerPrefs.GetInt("Coins") - valueForChange;
            _moneyText.text = newCoinsValue.ToString();
            PlayerPrefs.SetInt("Coins", newCoinsValue);
        }
    }
}