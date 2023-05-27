using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] float attackDamage = 5f;
    [SerializeField, Range(0, 10)] float speed = 5;
    Wayponts waypoints;
    Vector2 initialPosition;
    float distanceLimit = float.MaxValue;
    public Transform target;
    private int waypointsIndex = 0;

    public void SetWaypoint(Wayponts waypoints)
    {
        this.waypoints = waypoints;
        target = waypoints.points[0];
    }

    private void Start()
    {
        // initialPosition = this.transform.position;

    }

    private void Update()
    {
        var virusYPos = transform.position.y;
        var freezeYPos = virusYPos * 0;
        // transform.Translate(Vector2.right * speed * Time.deltaTime);
        Vector3 dir = target.position - this.transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= .2f)
        {
            GetNextWaypoint();
        }

        if (Vector2.Distance(
            initialPosition,
            this.transform.position) > this.distanceLimit || health < 0)
        {
            Destroy(this.gameObject);
        }
    }

    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.CompareTag("Waypoint Down"))
    //     {
    //         transform.Translate(Vector2.down * speed * Time.deltaTime);
    //     }
    //     else if (other.CompareTag("Waypoint Up"))
    //     {
    //         transform.Translate(Vector2.up * speed * Time.deltaTime);
    //     }
    //     else if (other.CompareTag("Waypoint Right"))
    //     {
    //         transform.Translate(Vector2.right * speed * Time.deltaTime);
    //     }


    // }

    private void GetNextWaypoint()
    {
        if (waypointsIndex >= waypoints.points.Length - 1)
        {
            Destroy(this.gameObject);
            return;
        }

        waypointsIndex++;
        target = waypoints.points[waypointsIndex];
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Firewall")
        {
            other.gameObject.GetComponent<FirewallHealth>().TakeDamage(attackDamage);
        }
    }

    public void SetUpDistanceLimit(float distance)
    {
        this.distanceLimit = distance;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
