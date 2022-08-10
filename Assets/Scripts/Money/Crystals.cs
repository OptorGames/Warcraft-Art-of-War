using UnityEngine;

namespace Money
{
    public class Crystals : MoneySystem
    {
        private void Awake()
        {
            if (!PlayerPrefs.HasKey("Crystals"))
            {
                PlayerPrefs.SetInt("Crystals", 0);
            }
        }

        public override void ChangeMoneyNumber(int valueForChange)
        {
            var newCoinsValue = PlayerPrefs.GetInt("Crystals") - valueForChange;
            _moneyText.text = newCoinsValue.ToString();
            PlayerPrefs.SetInt("Crystals", newCoinsValue);
        }
    }
}