using UnityEngine;
using UnityEngine.SceneManagement; // สำหรับจัดการฉาก
using UnityEngine.UI; // สำหรับ UI

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI; // UI สำหรับแสดงข้อความ "You Die"
    public Button restartButton; // ปุ่ม Restart


    public GameObject bossPrefab;    // Prefab ของ Boss ที่จะสร้าง
    public GameObject magicWitchPrefab; // Prefab ของสาวถือไม้กวาดพลังเวท
    public float spawnTimeBoss = 20f; // เวลาที่จะ Spawn Boss (20 วินาที)
    public float spawnTimeWitch = 30f; // เวลาที่จะ Spawn สาวถือไม้กวาด (30 วินาที)
    private float timer = 0f;
    private bool bossSpawned = false; // ตัวแปรเช็คว่า Boss ถูก Spawn แล้วหรือยัง
    private bool witchSpawned = false; // ตัวแปรเช็คว่าสาวถือไม้กวาดถูก Spawn แล้วหรือยัง

    public float spawnTime = 40f; // เวลาที่จะ Spawn ทั้งสองตัวละคร (40 วินาที)
    private bool spawned = false;


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
        timer += Time.deltaTime;

        // ตรวจสอบว่า Boss ยังไม่ได้ Spawn และเวลาผ่านไปถึงเวลา
        if (!bossSpawned && timer >= spawnTimeBoss)
        {
            SpawnBoss();
            bossSpawned = true;
        }

        // ตรวจสอบว่าสาวถือไม้กวาดยังไม่ได้ Spawn และเวลาผ่านไปถึงเวลา
        if (!witchSpawned && timer >= spawnTimeWitch)
        {
            SpawnMagicWitch();
            witchSpawned = true;
        }

        if (!spawned && timer >= spawnTime)
        {
            SpawnBossAndWitch();
            spawned = true;  // ตั้งค่าเป็น true เพื่อไม่ให้ spawn ซ้ำ
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

    // ฟังก์ชัน Spawn สาวถือไม้กวาดพลังเวท
    void SpawnMagicWitch()
    {
        // สร้างสาวถือไม้กวาดที่ตำแหน่งที่ต้องการ (เช่น ใกล้ๆ กับผู้เล่น)
        GameObject witch = Instantiate(magicWitchPrefab, new Vector3(10f, 0f, 0f), Quaternion.identity); // ปรับตำแหน่งตามต้องการ

        // เรียกใช้ฟังก์ชันการโจมตีระยะไกลของสาวถือไม้กวาด
        witch.GetComponent<MagicWitch>().StartShooting();

        Debug.Log("Magic Witch Spawned and Started Attacking!");
    }

    void SpawnBossAndWitch()
    {
        // สร้าง Boss ที่ตำแหน่งที่ต้องการ
        GameObject boss = Instantiate(bossPrefab, new Vector3(10f, 0f, 0f), Quaternion.identity); // ปรับตำแหน่งตามต้องการ
        // เรียกใช้ฟังก์ชัน StartRunning ใน BossRunner เพื่อเริ่มการวิ่ง
        boss.GetComponent<BossRunner>().StartRunning();

        // สร้างสาวถือไม้กวาดที่ตำแหน่งที่ต้องการ
        GameObject witch = Instantiate(magicWitchPrefab, new Vector3(10f, 0f, 0f), Quaternion.identity); // ปรับตำแหน่งตามต้องการ
        // เรียกใช้ฟังก์ชันการโจมตีระยะไกลของสาวถือไม้กวาด
        witch.GetComponent<MagicWitch>().StartShooting();

        Debug.Log("Boss and Magic Witch Spawned and Started Running/Attacking!");
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
        SceneManager.LoadScene("Menu");
    }
}
