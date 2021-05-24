using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{
    public GameObject deathMenuUI;

    void Update()
    {
        if (!PlayerNS.Player.isPlayerAlive)
            ShowScreen();
    }

    public void ShowScreen()
    {
        deathMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
