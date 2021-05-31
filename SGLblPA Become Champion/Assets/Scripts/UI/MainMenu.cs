using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class MainMenu : MonoBehaviour 
{
    public Animator transition;

    void Start()
    {
        Time.timeScale = 1f;
    }

    public void PlayTutorial()
    {
        PlayerPrefs.SetInt("CurrentPlayerHealth", 100);
        PlayerPrefs.SetInt("CurrentPlayerDamage", 20);
        PlayerPrefs.SetString("PlayerPhrasesString", null);
        PlayerNS.Player.isPlayerAlive = true;
        Time.timeScale = 1f;

        // SceneManager.LoadScene("Tutorial");
        StartCoroutine(LoadLevel("Tutorial"));
    }

    public void PlayGame()
    {
        PlayerPrefs.SetInt("CurrentPlayerHealth", 100);
        PlayerPrefs.SetInt("CurrentPlayerDamage", 20);
        PlayerPrefs.SetString("PlayerPhrasesString", null);
        PlayerNS.Player.isPlayerAlive = true;
        Time.timeScale = 1f;

        // SceneManager.LoadScene("Hub");
        StartCoroutine(LoadLevel("Hub"));
    }

    IEnumerator LoadLevel(string sceneName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
