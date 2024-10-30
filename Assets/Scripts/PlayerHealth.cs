using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // จำนวน HP สูงสุด
    public int currentHealth;
    private GameManager gameManager; // ตัวแปรสำหรับ GameManager

    void Start()
    {
        currentHealth = maxHealth; // ตั้งค่า HP เริ่มต้น
        gameManager = FindObjectOfType<GameManager>(); // ค้นหา GameManager ในฉาก
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
        gameManager.PlayerDied(); // เรียกฟังก์ชัน PlayerDied ใน GameManager
        Destroy(gameObject); // ทำลาย Player
    }
}
