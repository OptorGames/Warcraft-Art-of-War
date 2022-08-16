using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static int Level { get; private set; }
    [SerializeField] private TMP_Text _levelText;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("GameLevel"))
        {
            PlayerPrefs.SetInt("GameLevel", 1);
        }

        Level = PlayerPrefs.GetInt("GameLevel");
        _levelText.text = Level.ToString();
    }

    public void StartLevel()
    {
        SceneManager.LoadScene("GamePlay");
    }
}