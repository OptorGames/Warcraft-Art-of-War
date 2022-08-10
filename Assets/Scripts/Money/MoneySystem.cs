using TMPro;
using UnityEngine;

namespace Money
{
    public abstract class MoneySystem : MonoBehaviour
    {
        [SerializeField] protected TMP_Text _moneyText;
        public abstract void ChangeMoneyNumber(int value);
    }
}