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

    Seeker seeker;
    Rigidbody2D rb;
    Vector2 seekerSpawn;

    public Animator animator;

    // [HideInInspector]
    public Vector2 moveDirection;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        seekerSpawn = GetComponent<Transform>().position;

        InvokeRepeating("UpdatePath", 0f, 0.5f);
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
        else seeker.StartPath(rb.position, seekerSpawn, OnPathComplete);
    }

    void FixedUpdate() 
    {
        if (path == null) return;

        if (currentWaypoint >= path.vectorPath.Count) 
            return;

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
