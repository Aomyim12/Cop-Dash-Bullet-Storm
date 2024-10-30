using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10; // จำนวน HP สูงสุด
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth; // ตั้งค่า HP เริ่มต้น
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount; // ลดจำนวน HP
        if (currentHealth <= 0)
        {
            Die(); // เรียกฟังก์ชันที่จัดการเมื่อ Player ตาย
        }
    }

    private void Die()
    {
        // จัดการการตาย เช่น เล่นอนิเมชัน หรือลบ Player ออกจากฉาก
        Debug.Log("Player has died.");
        // ทำลาย Player หรือทำการรีเซ็ตฉากที่นี่
        Destroy(gameObject); // ตัวอย่าง: ทำลาย Player
    }
}
