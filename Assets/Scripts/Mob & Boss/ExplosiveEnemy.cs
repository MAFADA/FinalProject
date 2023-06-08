using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveEnemy : MonoBehaviour
{
    [SerializeField] float explosionRadius = 3f;
    [SerializeField] int damageAmount = 1;
    [SerializeField] GameObject explosionEffect;
    [SerializeField] Animator animator;

    private bool exploded = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!exploded && collision.CompareTag("Player"))
        {
            Explode();
            PlayerHealthBossArena player = collision.GetComponent<PlayerHealthBossArena>();
            if (player != null)
            {
                player.TakeDamage(damageAmount);
            }
        }
    }

    private void Explode()
    {
        exploded = true;

        animator.SetTrigger("Explode");

        // Spawn explosion effect
        Instantiate(explosionEffect, transform.position, Quaternion.identity);

        // Apply explosion force to nearby objects
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D collider in colliders)
        {
            Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce((collider.transform.position - transform.position).normalized * 10f, ForceMode2D.Impulse);
            }
        }

        // Destroy the explosive enemy
        Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
    }
}
