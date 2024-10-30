using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 2; // HP �٧�ش�ͧ�ѵ��
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
        Destroy(gameObject); // ������ѵ������� HP ���
    }
}
