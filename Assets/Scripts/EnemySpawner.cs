using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemyPrefabs; // รายการ prefab ของศัตรูหลายรูปแบบ
    public float spawnRate = 2f;          // อัตราการเกิดศัตรูเริ่มต้น
    public float spawnRateIncrease = 0.5f; // อัตราการเพิ่มความถี่การเกิดศัตรู
    public float totalTime = 5f;         // เวลานับถอยหลังทั้งหมด (วินาที)
    public TextMeshProUGUI countdownText; // UI Text สำหรับแสดงเวลาถอยหลัง
    public GameObject winPanel;            // Panel สำหรับแสดงข้อความ "You Win!!"
    

    private float currentTime;            // เวลาปัจจุบัน
    private bool isSpawning = true;       // เช็คว่ายังสร้างศัตรูอยู่หรือไม่
    private PlayerHealth playerHealth;    // ตัวแปรสำหรับอ้างอิงถึง PlayerHealth

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>(); // ค้นหา PlayerHealth ในฉาก
        currentTime = totalTime;         // ตั้งค่าเวลาเริ่มต้น
        StartCoroutine(SpawnEnemies());  // เริ่มการสร้างศัตรู
        StartCoroutine(CountdownTimer()); // เริ่มการนับถอยหลัง
        winPanel.SetActive(false); // ซ่อน Win Panel ในตอนเริ่มเกม
    }

    IEnumerator SpawnEnemies()
    {
        while (isSpawning)
        {
            if (playerHealth == null || playerHealth.currentHealth <= 0)
            {
                isSpawning = false;
                yield break;
            }

            yield return new WaitForSeconds(spawnRate);

            int randomIndex = Random.Range(0, enemyPrefabs.Count);
            GameObject enemyPrefab = enemyPrefabs[randomIndex];

            // ใช้ Camera เพื่อให้ตำแหน่งการเกิดอยู่ในขอบเขตหน้าจอ
            Vector2 spawnPosition = Camera.main.ViewportToWorldPoint(
                new Vector2(Random.Range(0f, 1f), Random.Range(0f, 1f))
            );
            spawnPosition.x = Mathf.Clamp(spawnPosition.x, -10f, 10f); // ให้ตำแหน่งอยู่ในขอบเขต
            spawnPosition.y = Mathf.Clamp(spawnPosition.y, -5f, 5f);

            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            if (currentTime <= 15f && spawnRate > 0.5f)
            {
                spawnRate -= spawnRateIncrease * Time.deltaTime;
            }
        }
    }

    IEnumerator CountdownTimer()
    {
        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime; // ลดเวลาถอยหลัง
            countdownText.text = "Time Left: " + Mathf.Ceil(currentTime).ToString(); // อัพเดต UI

            yield return null; // รอเฟรมถัดไป
        }

        isSpawning = false; // หยุดการสร้างศัตรูเมื่อหมดเวลา
        countdownText.text = "Time's Up!"; // แสดงข้อความเมื่อหมดเวลา
        winPanel.SetActive(true); // แสดง Win Panel
    }
}
