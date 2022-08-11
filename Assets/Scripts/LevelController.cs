using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public void StartLevel()
    {
        SceneManager.LoadScene("GamePlay");
    }
}