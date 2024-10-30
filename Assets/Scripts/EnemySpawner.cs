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
            // ตรวจสอบว่า Player ยังมีชีวิตอยู่หรือไม่
            if (playerHealth == null || playerHealth.currentHealth <= 0)
            {
                isSpawning = false; // หยุดการสร้างศัตรู
                yield break; // ออกจาก Coroutine
            }

            yield return new WaitForSeconds(spawnRate); // รอจนกว่าจะถึงเวลาสร้างศัตรูใหม่

            // สุ่มเลือก prefab ศัตรูจาก List
            int randomIndex = Random.Range(0, enemyPrefabs.Count);
            GameObject enemyPrefab = enemyPrefabs[randomIndex];

            // สร้างศัตรูที่ตำแหน่งสุ่ม
            Vector2 spawnPosition = new Vector2(Random.Range(-10, 10), Random.Range(-5, 5));
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            // ลด spawnRate เมื่อเข้าใกล้หมดเวลาเพื่อสร้างศัตรูถี่ขึ้น
            if (currentTime <= 15f && spawnRate > 0.5f) // ลด spawnRate เมื่อใกล้หมดเวลา
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
