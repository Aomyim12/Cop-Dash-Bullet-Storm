using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5; // HP �٧�ش
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth; // ��駤�� HP �������
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Ŵ HP �������������·�����Ѻ

        if (currentHealth <= 0)
        {
            Die(); // ��� HP ��� ���¡�ѧ��ѹ Die
        }
    }

    void Die()
    {
        Destroy(gameObject); // ���������� HP ���
    }
}
