using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    private void Update() {
        if (health <= 0) {
            Destroy(this.gameObject);
        }
    }
}
