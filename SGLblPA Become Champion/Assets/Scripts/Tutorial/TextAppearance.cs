using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAppearance : MonoBehaviour
{
    private string text;

    void Start()
    {
        text = this.GetComponent<Text>().text;

        this.GetComponent<Text>().text = "";
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        this.GetComponent<Text>().text = text;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        this.GetComponent<Text>().text = "";
    }
}
