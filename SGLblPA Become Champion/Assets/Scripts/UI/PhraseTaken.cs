using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhraseTaken : MonoBehaviour
{
    public GameObject form;

    void Start()
    {
        form.SetActive(false);
    }

    public void Show(string phrase)
    {
        form.GetComponentInChildren<Text>().text = phrase;

        StartCoroutine(Activate());
    }

    private IEnumerator Activate()
    {
        form.SetActive(true);

        yield return new WaitForSeconds(2);

        form.SetActive(false);
    }
}
