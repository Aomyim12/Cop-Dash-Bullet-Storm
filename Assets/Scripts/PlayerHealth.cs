using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5; // HP สูงสุด
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth; // ตั้งค่า HP เริ่มต้น
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // ลด HP ตามความเสียหายที่ได้รับ

        if (currentHealth <= 0)
        {
            Die(); // ถ้า HP หมด เรียกฟังก์ชัน Die
        }
    }

    void Die()
    {
        Destroy(gameObject); // ทำลายเมื่อ HP หมด
    }
}
