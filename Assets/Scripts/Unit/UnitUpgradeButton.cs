using Unit;
using UnityEngine;
using UnityEngine.UI;

public class UnitUpgradeButton : MonoBehaviour
{
    [SerializeField] private Button _companyButton;
    [SerializeField] private UnitConfig _unitConfig;
    [SerializeField] private UnitStat _unitStat;

    private void Start()
    {
        _companyButton.onClick.AddListener(ClickButton);
    }

    private void ClickButton()
    {
        var moveSpeed = _unitConfig.StartUnitStats.MoveSpeed + _unitStat.MoveSpeed;
        var healthNumber = _unitConfig.StartUnitStats.HealthNumber + _unitStat.HealthNumber;
        var attackPower = _unitConfig.StartUnitStats.AttackPower + _unitStat.AttackPower;

        _unitConfig.StartUnitStats.SetValue(moveSpeed, healthNumber, attackPower);
    }

    private void OnDestroy()
    {
        _companyButton.onClick.RemoveListener(ClickButton);
    }
}