using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class MainMenu : MonoBehaviour 
{
    public List<string> PhrasesList = new List<string>();

    public void PlayGame()
    {
        PlayerPrefs.SetInt("CurrentPlayerHealth", 100);
        PlayerPrefs.SetInt("CurrentPlayerDamage", 20);
        PlayerPrefs.SetString("PlayerPhrasesString", null);
        PlayerNS.Player.isPlayerAlive = true;
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
