using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubDungeonDoors : MonoBehaviour
{
    [HideInInspector]
    public static bool isRHClosed = false;
    public static bool isCFClosed = false;
    public static bool isDCClosed = true;
    public static bool isAHClosed = true;

    public GameObject RHDoor;
    public GameObject RHCollider;

    public GameObject CFDoor;
    public GameObject CFCollider;

    public GameObject DCDoor;
    public GameObject DCCollider;

    public GameObject AHDoor;
    public GameObject AHCollider;


    void Start()
    {
        if (isRHClosed)
        {
            RHDoor.SetActive(false);
            RHCollider.SetActive(true);
        }

        if (isCFClosed)
        {
            CFDoor.SetActive(false);
            CFCollider.SetActive(true);
        }

        if (isDCClosed)
        {
            DCDoor.SetActive(false);
            DCCollider.SetActive(true);
        }

        if (isAHClosed)
        {
            DCDoor.SetActive(false);
            DCCollider.SetActive(true);
        }
    }
}
