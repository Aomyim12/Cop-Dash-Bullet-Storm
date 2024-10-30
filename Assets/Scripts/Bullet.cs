using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1; // ความเสียหายที่กระสุนสร้างต่อศัตรู

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) // ตรวจสอบว่ากระสุนชนกับศัตรูหรือไม่
        {
            // เข้าถึงสคริปต์ EnemyHealth ของศัตรู
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage); // ลด HP ของศัตรู
            }

            Destroy(gameObject); // ทำลายกระสุนหลังจากชน
        }
    }
}
