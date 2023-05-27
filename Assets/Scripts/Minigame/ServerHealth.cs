using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ServerHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] float counterAtk = 30f;
    [SerializeField] Image healhtBar;
    [SerializeField] Canvas finishedCanvas;
    [SerializeField] TMP_Text finishedText;

    private bool isGameOver;

    private void Start()
    {
        healhtBar.fillAmount = health / 100;
    }

    private void Update()
    {
        healhtBar.fillAmount = health / 100;
    }

    void TakeDamage(float damage)
    {
        health -= damage;
        healhtBar.fillAmount = health / 100;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Virus")
        {
            other.gameObject.GetComponent<Virus>().TakeDamage(counterAtk);
        }
    }

    // private void Update()
    // {
    //     if (health < 0)
    //         Destroy(this.gameObject);
    // }

    public void GameOver()
    {
        if (health < 0)
            Destroy(this.gameObject);
        finishedCanvas.gameObject.SetActive(true);
        finishedText.text = "Game Over!!!";
        isGameOver = true;
    }

    public void PlayerWin()
    {
        finishedCanvas.gameObject.SetActive(true);
        finishedText.text = "You Win!!!";
    }



}
