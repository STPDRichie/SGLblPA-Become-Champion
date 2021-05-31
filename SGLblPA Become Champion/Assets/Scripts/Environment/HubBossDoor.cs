using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubBossDoor : MonoBehaviour
{
    public GameObject RHBossFrame;
    public GameObject CFBossFrame;
    public GameObject DCBossFrame;
    public GameObject AHBossFrame;

    public GameObject ClosedGates;

    void Start()
    {
        if (RHBossFrame == null || CFBossFrame == null || 
            DCBossFrame == null || AHBossFrame == null || ClosedGates == null) return;

        if (HubDungeonDoors.isRHClosed) RHBossFrame.SetActive(true);
        if (HubDungeonDoors.isCFClosed) CFBossFrame.SetActive(true);
        if (HubDungeonDoors.isDCClosed) DCBossFrame.SetActive(true);
        if (HubDungeonDoors.isAHClosed) AHBossFrame.SetActive(true);

        if (HubDungeonDoors.isRHClosed && HubDungeonDoors.isCFClosed &&
            HubDungeonDoors.isDCClosed && HubDungeonDoors.isAHClosed)
            ClosedGates.SetActive(false);
    }
}
