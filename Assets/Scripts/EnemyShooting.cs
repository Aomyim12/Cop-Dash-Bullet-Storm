using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform; 

        if (player == null)
        {
            
            Destroy(gameObject); // ทำลาย Enemy ถ้าไม่พบ Player
            return; // ออกจากฟังก์ชัน Start
        }

        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        // ตรวจสอบว่าผู้เล่นยังมีอยู่หรือไม่
        if (player == null)
        {
            Destroy(gameObject); // ทำลาย Enemy
            return; // ออกจากฟังก์ชัน Update
        }

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

        // การยิง
        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots; // รีเซ็ตเวลา
        }
        else
        {
            timeBtwShots -= Time.deltaTime; // ลดเวลา
        }
    }
}
