using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth = 100;

    [SerializeField] private Image healthBar;

    // [SerializeField] private TMP_Text damageText;
    public UnityEvent OnPlayerDie;

    public int CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public int MaxHealth { get => maxHealth; }

    private void InitVariables()
    {
        currentHealth = maxHealth;
    }

    private void Start()
    {
        InitVariables();
    }

    private void Update()
    {
        healthBar.fillAmount = (float) currentHealth / maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        // damageText.text = Convert.ToString(amount);

        if (currentHealth <= 0)
        {
            // Destroy(gameObject);
            OnPlayerDie.Invoke();
        }
    }
}
