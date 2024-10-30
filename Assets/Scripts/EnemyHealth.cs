using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 2; // HP สูงสุดของศัตรู
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
        Destroy(gameObject); // ทำลายศัตรูเมื่อ HP หมด
    }
}
