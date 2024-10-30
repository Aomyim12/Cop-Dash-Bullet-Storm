using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    private Transform player;
    public float speed;
    public int damageAmount = 10; // จำนวนความเสียหายที่ Player จะได้รับ

    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Transform>(); // ใช้ ? เพื่อหลีกเลี่ยง NullReferenceException
    }

    // Update is called once per frame
    void Update()
    {
        // ตรวจสอบว่าผู้เล่นยังมีอยู่หรือไม่
        if (player == null)
        {
            // หากไม่มีผู้เล่น ให้ทำลาย Enemy หรือหยุดการทำงานของสคริปต์
            Destroy(gameObject); // ทำลาย Enemy หรือใช้ enabled = false; ถ้าไม่ต้องการทำลาย
            return; // ออกจากฟังก์ชัน Update
        }

        distance = Vector2.Distance(transform.position, player.position);
        Vector2 direction = player.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // ตรวจสอบว่า Collider ที่ชนคือ Player
        {
            // เรียกฟังก์ชันให้ Player ได้รับความเสียหาย
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}
