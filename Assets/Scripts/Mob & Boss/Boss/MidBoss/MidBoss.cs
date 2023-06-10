using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MidBoss : MonoBehaviour
{
    [SerializeField] string midBossName;
    [SerializeField] TMP_Text midBossNameText;
    [SerializeField] Transform player;
    [SerializeField] bool isFlipped;

    [Header("UI")]
    [SerializeField] float health;
    [SerializeField] Image hpBar;
    [SerializeField] float maxHealth = 1000;

  
    private Rigidbody2D rb;

    private void Awake()
    {
        hpBar.fillAmount = (float)health / (float)maxHealth;
        midBossNameText.text = midBossName;
    }

    private void Update()
    {
        hpBar.fillAmount = (float)health / (float)maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        hpBar.fillAmount = (float)health / (float)maxHealth;
    }


    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {

            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
}
