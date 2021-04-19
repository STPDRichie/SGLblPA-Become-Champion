using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTo : MonoBehaviour
{
    private bool playerDetected;
    public GameObject Player;
    
    public Transform door1;
    public float width1;
    public float height1;

    public Transform door2;
    public float width2;
    public float height2;

    public LayerMask whatIsPlayer;

    public bool twoWay;

    private void Update() 
    {
        if (twoWay) 
        {
            CheckAndMove(door1, door2, width1, height1);
            CheckAndMove(door2, door1, width2, height2);
        }
        else 
            CheckAndMove(door1, door2, width1, height1);
    }

    private void CheckAndMove(Transform moveFrom, Transform moveTo, float width, float height) 
    {
        playerDetected = Physics2D.OverlapBox(moveFrom.position, new Vector2(width, height), 0, whatIsPlayer);

        if (playerDetected == true) 
            if (Input.GetKeyDown(KeyCode.E)) 
                Player.transform.position = new Vector2(moveTo.position.x, moveTo.position.y);
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(door1.position, new Vector3(width1, height1, 1));
        Gizmos.DrawWireCube(door2.position, new Vector3(width2, height2, 1));
    }
}
