using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyToggleObjects : MonoBehaviour
{
    public GameObject wall;

    public GameObject nextEnemyText;

    public GameObject nextChestText;

    void Start()
    {
        if (wall == null || nextEnemyText == null || nextChestText == null) return;
        
        wall.SetActive(true);

        nextChestText.SetActive(false);

        nextEnemyText.SetActive(false);
    }

    void Update()
    {
        if (wall == null || nextEnemyText == null || nextChestText == null) return;
        
        if (GetComponent<Enemy>().currentHealth <= 0)
        {
            wall.SetActive(false);

            nextChestText.SetActive(true);

            nextEnemyText.SetActive(true);
        }
    }
}
