using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prompt : MonoBehaviour
{
    public GameObject prompt;

    void Start() 
    {
        prompt.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.tag == "Player")
            prompt.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        prompt.SetActive(false);
    }
}
