using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidBossMeleeAttack : MonoBehaviour
{
    [Header("Melee Attack")]
    [SerializeField] int attackDamage = 20;
    [SerializeField] Vector3 attackOffset;
    [SerializeField] float attackRange = 1f;
    [SerializeField] LayerMask attackMask;

    private Rigidbody2D rb;
    private GameObject player;
    private bool isJumping = false;
    private float cooldownTimer = 0f;
    private Collider2D colInfo;
    private Vector3 pos;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {

    }

    public void Attack()
    {
        pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        colInfo = Physics2D.OverlapCircle(point: pos, attackRange, attackMask);
        if (colInfo != null)
        {
            var collider = colInfo.GetComponent<PlayerHealth>();
            collider.TakeDamage(amount: attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(center: this.transform.position,attackRange);
    }


}
