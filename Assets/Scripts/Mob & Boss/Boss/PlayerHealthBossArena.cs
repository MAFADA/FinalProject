using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealthBossArena : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] TMP_Text gameOverText;
    public UnityEvent OnDie;
    public UnityEvent OnFallFromBelowGround;
    

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    private void Update() {
        if (health <= 0) {
            Destroy(this.gameObject);
            OnDie.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("FallTrigger"))
        {
            gameOverText.text = "Kamu jatuh ke lubang void!!!\n Berhati-hati lah";
            OnFallFromBelowGround.Invoke();
        }

        if (other.CompareTag("NextStageTrigger"))
        {
            
        }

        if (other.CompareTag("MidBoss1StageTrigger"))
        {
            FindAnyObjectByType<Boss>().GetComponent<Animator>().enabled = true;
        }
    }

}
