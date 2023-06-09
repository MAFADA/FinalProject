using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExplosiveMob : MonoBehaviour
{
    [SerializeField] float health = 100f;
    public UnityEvent<GameObject> OnHit = new UnityEvent<GameObject>();


    public void TakeDamage(float damage)
    {
        // OnHit.Invoke();
        health -= damage;
    }
}
