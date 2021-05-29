using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonDescription : MonoBehaviour
{
    public Text textForm;

    private string text;

    void Start()
    {
        if (textForm == null) return;

        text = textForm.text;
        textForm.text = "";
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (textForm == null) return;

        textForm.text = text;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (textForm == null) return;

        textForm.text = "";
    }
}
