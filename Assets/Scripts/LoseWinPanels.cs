using ForUnit;
using Money;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseWinPanels : MonoBehaviour
{
    [SerializeField] private Coins _coins;
    [SerializeField] private Crystals _crystals;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private TMP_Text _loseCoinText;
    [SerializeField] private TMP_Text _loseCrystalText;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private TMP_Text _winContinueCoinText;
    [SerializeField] private TMP_Text _winContinueCrystalText;
    [SerializeField] private TMP_Text _winX3CoinText;
    [SerializeField] private TMP_Text _winX3CrystalText;
    private const int CoinsAfterWin = 100;
    private const int CrystalAfterWin = 30;
    private const int X3CoinsAfterWin = 300;
    private const int X3CrystalAfterWin = 90;
    private const int CoinsAfterLose = 30;
    private const int CrystalAfterLose = 15;
    private UnitsContainer _unitsContainer;

    private void Start()
    {
        _unitsContainer = UnitsContainer.Instance;
        _unitsContainer.OnWin += IfWin;
        _unitsContainer.OnLose += IfLose;
    }

    private void OnDisable()
    {
        _unitsContainer.OnWin -= IfWin;
        _unitsContainer.OnLose -= IfLose;
    }


    private void IfLose()
    {
        Time.timeScale = 0;
        print("lose!");
        _losePanel.SetActive(true);
        _loseCoinText.text = CoinsAfterLose.ToString();
        _loseCrystalText.text = CrystalAfterLose.ToString();

    }

    private void IfWin()
    {
        Time.timeScale = 0;
        print("win!");
        _winPanel.SetActive(true);
        _winContinueCoinText.text = CoinsAfterWin.ToString();
        _winContinueCrystalText.text = CrystalAfterWin.ToString();
        _winX3CoinText.text = X3CoinsAfterWin.ToString();
        _winX3CrystalText.text = X3CrystalAfterWin.ToString();
    }

    public void ContinueButtonWin()
    {
        PlayerPrefs.SetInt("GameLevel", PlayerPrefs.GetInt("GameLevel") + 1);
        _coins.ChangeMoneyNumber(CoinsAfterWin);
        _crystals.ChangeMoneyNumber(CrystalAfterWin);
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    public void ContinueButtonLose()
    {
        _coins.ChangeMoneyNumber(X3CoinsAfterWin);
        _crystals.ChangeMoneyNumber(X3CrystalAfterWin);
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    public void X3Button()
    {
        _coins.ChangeMoneyNumber(CoinsAfterLose);
        _crystals.ChangeMoneyNumber(CrystalAfterLose);
    }
}