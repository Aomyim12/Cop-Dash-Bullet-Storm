using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBlastAOE : MonoBehaviour
{
    public float powerBlastRadius = 5f; // รัศมีของระเบิด (AOE)
    public int damage = 10;          // ความเสียหายที่ทำให้กับศัตรู
    public float powerBlastCooldown = 5f; // ค่าเริ่มต้นของเวลาคูลดาวน์
    private float powerBlastTimer = 0f;   // ตัวจับเวลาในการทำระเบิด

    public int powerBlastLevel = 1;    // ระดับ Power Blast
    public GameObject explosionEffectPrefab; // Prefab สำหรับเอฟเฟกต์ระเบิด

    void Update()
    {
        powerBlastTimer += Time.deltaTime;

        if (powerBlastTimer >= powerBlastCooldown)
        {
            PowerBlastAttack();
            powerBlastTimer = 0f;
        }
    }

    void PowerBlastAttack()
    {
        // หาศัตรูในรัศมี AOE
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, powerBlastRadius);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                // ทำความเสียหายให้ศัตรู
                enemy.GetComponent<EnemyHealth>().TakeDamage(damage);
            }
        }

        // แสดงเอฟเฟกต์ระเบิด
        ShowExplosionEffect();

        Debug.Log("Power Blast AOE Attack!");
    }

    void ShowExplosionEffect()
    {
        if (explosionEffectPrefab != null)
        {
            // สร้างเอฟเฟกต์ระเบิดที่ตำแหน่งของผู้เล่น
            GameObject explosion = Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);

            // ทำลายเอฟเฟกต์หลังจากเวลาที่กำหนด
            Destroy(explosion, 2f); // ปรับเวลาตามความเหมาะสม
        }
    }

    public void UpgradePowerBlast(int level)
    {
        powerBlastLevel = level;

        // อัปเกรดค่าคูลดาวน์ตามระดับ
        switch (powerBlastLevel)
        {
            case 1:
                powerBlastCooldown = 5f;
                break;
            case 2:
                powerBlastCooldown = 3f;
                break;
            case 3:
                powerBlastCooldown = 1f;
                break;
            default:
                powerBlastCooldown = 5f;
                break;
        }

        Debug.Log("Power Blast Level: " + powerBlastLevel + ", Cooldown: " + powerBlastCooldown + " seconds");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, powerBlastRadius);
    }
}
