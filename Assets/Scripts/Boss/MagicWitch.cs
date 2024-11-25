using UnityEngine;
using UnityEngine.AI; // ใช้สำหรับการเคลื่อนที่ด้วย NavMeshAgent

public class MagicWitch : MonoBehaviour
{

    public float speed;
    public float retreatDistance;
    public float stoppingDistance;

    public float shootRate = 1f;  // ความเร็วในการยิงพลังเวท
    public GameObject magicProjectilePrefab; // Prefab ของพลังเวทที่ยิงออกไป
    private float shootTimer = 0f;

    private NavMeshAgent agent;  // ตัวควบคุมการเคลื่อนที่
    public Transform player;  // ตำแหน่งของผู้เล่น

    void Start()
    {
        // หา NavMeshAgent ในตัว Magic Witch
        agent = GetComponent<NavMeshAgent>();
        if (player == null)
        {
            player = GameObject.FindWithTag("Player").transform;  // ค้นหาผู้เล่นโดยอัตโนมัติ
        }
    }

    void Update()
    {
        shootTimer += Time.deltaTime;

        // การเคลื่อนไหวของ Enemy
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position; // ยืนอยู่ที่เดิม
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime); // ถอยกลับ
        }

        // ยิงพลังเวทระยะไกลเมื่อถึงเวลาที่กำหนด
        if (shootTimer >= shootRate)
        {
            ShootMagicProjectile();
            shootTimer = 0f;  // รีเซ็ตตัวจับเวลา
        }
    }

    // ฟังก์ชันยิงพลังเวท
    void ShootMagicProjectile()
    {
        // สร้างพลังเวทที่ยิงออกไปในทิศทางที่ต้องการ
        Instantiate(magicProjectilePrefab, transform.position, Quaternion.identity);

        Debug.Log("Magic Witch is shooting!");
    }

    // เรียกใช้ฟังก์ชันนี้เพื่อเริ่มการโจมตี
    public void StartShooting()
    {
        // สั่งให้เริ่มการโจมตีเมื่อสาวถือไม้กวาดถูก Spawn
        Debug.Log("Magic Witch Started Shooting!");
    }
}
