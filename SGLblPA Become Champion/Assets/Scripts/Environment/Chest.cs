using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerNS;

public class Chest : MonoBehaviour
{
    public Player player;

    public string phrase;

    private bool playerDetected;
    public LayerMask whatIsPlayer;

    public SpriteRenderer sprite;
    public Sprite opened;
    public Sprite closed;

    private bool isOpened = false;

    void Start()
    {
        if (closed == null || opened == null || sprite == null) return;
        sprite.sprite = closed;
    }

    void Update()
    {
        if (closed == null || opened == null || sprite == null) return;
        if (!isOpened) CheckAndOpen();
    }

    void CheckAndOpen()
    {
        playerDetected = Physics2D.OverlapBox(this.transform.position, new Vector2(2, 2), 0, whatIsPlayer);

        if (playerDetected == true)
            if (Input.GetKeyDown(KeyCode.E))
            {
                sprite.sprite = opened;
                GetComponent<Prompt>().prompt.SetActive(false);
                GetComponent<Prompt>().active = false;

                GetComponent<PhraseTaken>().Show(phrase);

                player.PhrasesList.Add(phrase);
                var phrasesString = string.Join(";", player.PhrasesList);
                PlayerPrefs.SetString("PlayerPhrasesString", phrasesString);

                player.GetComponent<PlayerCombatSystem>().attackDamage += 2;
                PlayerPrefs.SetInt("CurrentPlayerDamage", player.GetComponent<PlayerCombatSystem>().attackDamage);

                isOpened = true;
            }
    }
}
