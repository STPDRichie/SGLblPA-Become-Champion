using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteringDoor : MonoBehaviour
{
    private bool playerDetected;

    public bool healPlayer = false;
    
    public Transform doorPos;
    public float width;
    public float height;

    public LayerMask whatIsPlayer;

    [SerializeField]
    private string sceneName;

    SceneSwitch sceneSwitch;

    private void Start() 
    {
        sceneSwitch = FindObjectOfType<SceneSwitch>();
    }

    private void Update() 
    {
        if (doorPos == null) return;
        playerDetected = Physics2D.OverlapBox(doorPos.position, new Vector2(width, height), 0, whatIsPlayer);
        
        if (playerDetected == true)
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (healPlayer) PlayerPrefs.SetInt("CurrentPlayerHealth", 100);
                sceneSwitch.SwitchScene(sceneName);
            }
    }

    private void OnDrawGizmosSelected() 
    {
        if (doorPos == null) return;
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(doorPos.position, new Vector3(width, height, 1));
    }
}
