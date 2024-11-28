using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // จำนวน HP สูงสุด
    public int currentHealth;
    private GameManager gameManager; // ตัวแปรสำหรับ GameManager
    public TextMeshProUGUI HP; // อ้างอิงถึง TextMeshProUGUI สำหรับแสดง HP

    void Start()
    {
        currentHealth = maxHealth; // ตั้งค่า HP เริ่มต้น
        gameManager = FindObjectOfType<GameManager>(); // ค้นหา GameManager ในฉาก
    }

    void Update()
    {
        // อัปเดต UI ของ HP ทุกครั้งที่เกิดการเปลี่ยนแปลงใน currentHealth
        HP.text = "" + currentHealth.ToString(); // แสดงค่าของ currentHealth
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
