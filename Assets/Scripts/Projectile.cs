using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public int damageAmount = 10; // จำนวนความเสียหายที่ Projectile จะทำให้ Player

    private Transform player;
    private Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // เช็คว่าถึงจุดหมายหรือยัง
        if (Vector2.Distance(transform.position, target) < 0.1f) // ใช้ระยะทางเพื่อป้องกันการใช้ == ซึ่งอาจไม่แม่นยำ
        {
            DestroyProjectile();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // เรียกใช้ฟังก์ชันให้ Player ได้รับความเสียหาย
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount); // ส่งจำนวนความเสียหาย
            }
            DestroyProjectile(); // ทำลาย projectile หลังจากที่ทำให้ Player ได้รับความเสียหาย
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
