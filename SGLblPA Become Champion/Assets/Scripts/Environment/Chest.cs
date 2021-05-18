using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Collider2D area;
    
    private bool playerDetected;
    public LayerMask whatIsPlayer;

    public SpriteRenderer sprite;
    public Sprite opened;
    public Sprite closed;

    void Start()
    {
        if (closed == null || opened == null || sprite == null) return;

        sprite.sprite = closed;
    }

    void Update()
    {
        if (closed == null && opened == null || sprite == null) return;
        CheckAndOpen();
    }

    void CheckAndOpen()
    {
        playerDetected = Physics2D.OverlapBox(this.transform.position, new Vector2(2, 2), 0, whatIsPlayer);

        if (playerDetected == true)
            if (Input.GetKeyDown(KeyCode.E))
            {
                sprite.sprite = opened;
                GetComponent<Prompt>().prompt = null;
            }
    }
}
