using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMob : MonoBehaviour
{
    [SerializeField] float health = 100f;

    public void TakeDamage(float damage){
        health -= damage;
    }
}
