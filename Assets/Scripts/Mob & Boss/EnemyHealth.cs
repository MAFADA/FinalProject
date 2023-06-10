using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth = 100;
    public int CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public int MaxHealth { get => maxHealth; }

    public UnityEvent OnEnemyDie;

    private void InitVariables()
    {
        currentHealth = maxHealth;
    }
    private void Start()
    {
        InitVariables();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            OnEnemyDie.Invoke();
        }
    }
}
