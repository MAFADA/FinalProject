using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] float attackDamage = 10;
    [SerializeField] Vector3 attackOffset;
    [SerializeField] float attackRange = 1f;
    [SerializeField] LayerMask attackMask;

    public void Attack(){
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(point: pos,attackRange,attackMask);
        if (colInfo != null)
        {
            var collider = colInfo.GetComponent<PlayerHealthBossArena>();
            collider.TakeDamage(attackDamage);
        }
    }
}
