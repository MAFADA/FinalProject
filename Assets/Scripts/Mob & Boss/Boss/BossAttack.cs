using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [Header("Melee Attack")]
    [SerializeField] float attackDamage = 10;
    [SerializeField] Vector3 attackOffset;
    [SerializeField] float attackRange = 1f;
    [SerializeField] LayerMask attackMask;

    private Rigidbody2D rb;
    private GameObject player;
    private bool isJumping = false;
    private float cooldownTimer = 0f;
    private Collider2D colInfo;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        colInfo = Physics2D.OverlapCircle(point: pos, attackRange, attackMask);
        if (colInfo != null)
        {
            var collider = colInfo.GetComponent<PlayerHealth>();
            collider.TakeDamage((int)attackDamage);
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        // Gizmos.DrawWireSphere(transform.position, attackRange);      
    }

}
