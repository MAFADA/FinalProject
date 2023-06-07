using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidBossMeleeAttack : MonoBehaviour
{
    [Header("Melee Attack")]
    [SerializeField] float attackDamage = 10;
    [SerializeField] Vector3 attackOffset;
    [SerializeField] float attackRange = 1f;
    [SerializeField] LayerMask attackMask;

    [Header("Jump Attack")]
    public float jumpForce = 10f;
    public float cooldownTime = 3f;
    public float jumpAttackRange = 5f;

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

    private void Update()
    {
        if (isJumping) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= attackRange)
        {
            cooldownTimer -= Time.deltaTime;

            if (cooldownTimer <= 0f)
            {
                Jump();
                cooldownTimer = cooldownTime;
            }
        }
    }

    public void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isJumping = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        colInfo = Physics2D.OverlapCircle(point: pos, attackRange, attackMask);
        if (colInfo != null)
        {
            var collider = colInfo.GetComponent<PlayerHealthBossArena>();
            collider.TakeDamage(attackDamage);
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        // Gizmos.DrawWireSphere(transform.position, attackRange);      
    }

}
