using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // �ӹǹ HP �٧�ش
    public int currentHealth;
    private GameManager gameManager; // ���������Ѻ GameManager

    void Start()
    {
        currentHealth = maxHealth; // ��駤�� HP �������
        gameManager = FindObjectOfType<GameManager>(); // ���� GameManager 㹩ҡ
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount; // Ŵ�ӹǹ HP
        if (currentHealth <= 0)
        {
            Die(); // ���¡�ѧ��ѹ���Ѵ�������� Player ���
        }
    }

    private void Die()
    {
        // �Ѵ��á�õ�� �� ���͹����ѹ ����ź Player �͡�ҡ�ҡ
        Debug.Log("Player has died.");
        gameManager.PlayerDied(); // ���¡�ѧ��ѹ PlayerDied � GameManager
        Destroy(gameObject); // ����� Player
    }
}
