using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public string bossName;
    public Text bossNameText;

    public Slider slider;
    public Image fill;

    void Start()
    {
        bossNameText.text = bossName;
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = Color.red;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = Color.red;
    }
}
