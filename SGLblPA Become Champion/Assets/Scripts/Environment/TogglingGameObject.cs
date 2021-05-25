using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglingGameObject : MonoBehaviour
{
    public GameObject objectToToggle;

    public void Toggle(bool on)
    {
        if (on) 
            objectToToggle.SetActive(true);
        else 
            objectToToggle.SetActive(false);
    }
}
