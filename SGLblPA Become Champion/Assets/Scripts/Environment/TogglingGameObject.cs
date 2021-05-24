using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglingGameObject : MonoBehaviour
{
    public GameObject obj;

    public void Toggle(bool on)
    {
        if (on) 
            obj.SetActive(true);
        else 
            obj.SetActive(false);
    }
}
