using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public Transform target;

    public float speed = 2f;
    public float nextWaypointDistance = 2f;

    public Transform enemyGFX;

    Path path;
    int currentWaypoint = 0;
    //bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    public Animator animator;

    private Vector2 moveDirection;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void UpdatePath() 
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error) 
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void FixedUpdate() 
    {
        if (path == null) return;

        if (currentWaypoint >= path.vectorPath.Count) 
        {
            //reachedEndOfPath = true;
            return;
        }
        //else reachedEndOfPath = false;

        moveDirection = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;

        if (path.vectorPath.Count == 0)
            animator.SetFloat("Speed", 0f);
        else animator.SetFloat("Speed", moveDirection.sqrMagnitude);

        animator.SetFloat("Horizontal", moveDirection.x);

        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance) 
            currentWaypoint++;
    }
}
