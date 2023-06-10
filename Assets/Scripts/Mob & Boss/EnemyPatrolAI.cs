using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class EnemyPatrolAI : MonoBehaviour
{

    [Header("AI Patrol")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    // [Header("Enemy")]
    [SerializeField] private Transform enemy;

    // [Header("Movement Parameter")]
    [SerializeField] private float speedPatrol;
    private Vector3 initScale;
    private bool movingLeft;

    // [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;


    [Header("AI Movement")]
    [SerializeField] Transform target;
    [SerializeField] float speed = 200f;
    [SerializeField] float nextWaypointDistance = 3f;
    [SerializeField] Transform enemyVisual;
    [SerializeField] float detectionArea;

    [SerializeField] private Animator animator;

    private Path path;
    private int currentWaypoint = 0;
    private bool endOfPath = false;
    private Seeker seeker;
    private Rigidbody2D rb;

    private void Awake()
    {
        initScale = enemy.localScale;
    }

    void Start()
    {
        // seeker for pathfinding
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        // repeat calling function UpdatePath
        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            //Draw the path
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distanceToPlayer = Vector2.Distance(rb.position, target.position);

        if (distanceToPlayer >= detectionArea)
        {
            if (movingLeft)
            {
                if (enemy.position.x >= leftEdge.position.x)
                {
                    MoveInDirection(-1);
                }
                else
                {
                    DirectionChange();
                }

            }
            else
            {
                if (enemy.position.x <= rightEdge.position.x)
                {
                    MoveInDirection(1);
                }
                else
                {
                    DirectionChange();
                }
            }
        }

        if (path == null)
        {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            endOfPath = true;
            return;
        }
        else
        {
            endOfPath = false;
        }

        //Calculating the waypoint to target
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        if (distanceToPlayer <= detectionArea)
        {
            //move the enemy to target
            rb.AddForce(force);
        }

        // jarak rigidbody terhadap satu point dalam waypoint 
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if (rb.velocity.x >= 0.01f)
        {
            enemyVisual.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (rb.velocity.x <= -0.01f)
        {
            enemyVisual.localScale = new Vector3(1f, 1f, 1f);
        }
    }
    private void DirectionChange()
    {
        animator.SetBool("isRunning", false);

        idleTimer += Time.deltaTime;

        if (idleTimer >= idleDuration)
            movingLeft = !movingLeft;

        movingLeft = !movingLeft;
    }

    private void MoveInDirection(int _direction)
    {
        if (enemy == null)
            return;

        idleTimer = 0;
        animator.SetBool("isRunning", true);

        // enemy face direction
        enemy.localScale = new Vector3(-Mathf.Abs(initScale.x) * _direction,
        initScale.y, initScale.z);
        //move to thta direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speedPatrol,
        enemy.position.y, enemy.position.z);
    }
}