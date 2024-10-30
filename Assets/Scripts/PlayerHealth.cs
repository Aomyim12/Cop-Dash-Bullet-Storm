using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10; // �ӹǹ HP �٧�ش
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth; // ��駤�� HP �������
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
        // ����� Player ���ͷӡ�����絩ҡ�����
        Destroy(gameObject); // ������ҧ: ����� Player
    }
}
