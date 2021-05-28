using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChanging : MonoBehaviour
{
    private string start = "Для начала сходи налево";
    private string afterChest = "Теперь смело иди направо";
    private string afterEnemy = "Поздравляю! Можно отправлять в путь!";

    public Chest chest;
    public Enemy enemy;

    void Start()
    {
        this.GetComponent<Text>().text = start;
    }

    void Update()
    {
        if (chest == null || enemy == null) return;

        if (chest.isOpened)
            this.GetComponent<Text>().text = afterChest;
        
        if (enemy.currentHealth <= 0)
            this.GetComponent<Text>().text = afterEnemy;
    }
}
