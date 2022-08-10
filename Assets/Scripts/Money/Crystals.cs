using UnityEngine;

namespace Money
{
    public class Cristal : MoneySystem
    {
        private void Awake()
        {
            if (!PlayerPrefs.HasKey("Cristals"))
            {
                PlayerPrefs.SetInt("Cristals", 0);
            }
        }

        protected override void ChangeMoneyNumber(int valueForChange)
        {
            var newCoinsValue = PlayerPrefs.GetInt("Coins") - valueForChange;
            _moneyText.text = newCoinsValue.ToString();
            PlayerPrefs.SetInt("Coins", newCoinsValue);
        }
    }
}