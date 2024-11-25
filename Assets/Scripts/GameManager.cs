using UnityEngine;
using UnityEngine.SceneManagement; // สำหรับจัดการฉาก
using UnityEngine.UI; // สำหรับ UI

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI; // UI สำหรับแสดงข้อความ "You Die"
    public Button restartButton; // ปุ่ม Restart
    public GameObject bossPrefab;    // Prefab ของ Boss ที่จะสร้าง
    public float spawnTime = 20f;    // เวลาที่จะ Spawn Boss (20 วินาที)
    private float timer = 0f;
    private bool bossSpawned = false; // ตัวแปรเช็คว่า Boss ถูก Spawn แล้วหรือยัง


    private void Start()
    {
        // ซ่อน UI เกมโอเวอร์เริ่มต้น
        gameOverUI.SetActive(false);

        // เพิ่ม listener ให้กับปุ่ม Restart
        restartButton.onClick.AddListener(RestartGame);
        restartButton.gameObject.SetActive(false); // ซ่อนปุ่ม Restart เริ่มต้น
    }

    private void Update()
    {
        if (!bossSpawned) // ตรวจสอบว่า Boss ยังไม่ถูก Spawn
        {
            timer += Time.deltaTime;

            // หากเวลาผ่านไปถึง 20 วินาที ให้ Spawn Boss
            if (timer >= spawnTime)
            {
                SpawnBoss();
                bossSpawned = true; // ตั้งค่าค่าให้ Boss ถูก Spawn แล้ว
                timer = 0f; // รีเซ็ตตัวจับเวลา
            }
        }
    }

    // ฟังก์ชัน Spawn Boss
    void SpawnBoss()
    {
        // สร้าง Boss ที่ตำแหน่งที่ต้องการ (เช่น ใกล้ๆ กับผู้เล่น)
        GameObject boss = Instantiate(bossPrefab, new Vector3(10f, 0f, 0f), Quaternion.identity); // ปรับตำแหน่งตามต้องการ

        // เรียกใช้ฟังก์ชัน StartRunning ใน BossRunner เพื่อเริ่มการวิ่ง
        boss.GetComponent<BossRunner>().StartRunning();

        Debug.Log("Boss Spawned and Started Running!");
    }

    public void PlayerDied()
    {
        // แสดง UI เกมโอเวอร์
        gameOverUI.SetActive(true);
        restartButton.gameObject.SetActive(true); // แสดงปุ่ม Restart
    }

    private void RestartGame()
    {
        // โหลดฉากปัจจุบันใหม่
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
