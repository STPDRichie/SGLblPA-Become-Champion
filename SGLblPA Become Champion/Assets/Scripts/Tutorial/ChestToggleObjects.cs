using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestToggleObjects : MonoBehaviour
{
    public Enemy enemy;

    public GameObject wall;

    
    public GameObject currentChestText;
    public GameObject nextChestText;
    public GameObject currentEnemyText;
    public GameObject nextEnemyText;

    void Start()
    {
        if (enemy == null || wall == null || 
            currentEnemyText == null || nextEnemyText == null || 
            currentChestText == null || nextChestText == null) return;
        
        wall.SetActive(true);

        currentChestText.SetActive(true);
        nextChestText.SetActive(false);

        currentEnemyText.SetActive(true);
        nextEnemyText.SetActive(false);
    }

    void Update()
    {
        if (enemy == null || wall == null || 
            currentEnemyText == null || nextEnemyText == null || 
            currentChestText == null || nextChestText == null) return;
        
        if (GetComponent<Chest>().isOpened)
        {
            wall.SetActive(false);

            currentChestText.SetActive(false);
            nextChestText.SetActive(true);

            currentEnemyText.SetActive(false);
            nextEnemyText.SetActive(true);
        }

        if (enemy.currentHealth <= 0)
        {
            nextChestText.SetActive(false);
            
            nextEnemyText.SetActive(false);
        }
    }
}
