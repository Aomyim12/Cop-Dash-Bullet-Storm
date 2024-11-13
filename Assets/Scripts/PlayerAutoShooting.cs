using UnityEngine;

public class PlayerAutoShooting : MonoBehaviour
{
    public GameObject projectilePrefab; // prefab ของกระสุน
    public Transform firePoint;         // จุดที่กระสุนจะถูกยิงออกมา
    public float shootRate = 0.5f;      // ความถี่ในการยิง (วินาที)
    public float projectileSpeed = 10f; // ความเร็วของกระสุน
    public float targetRange = 10f;     // ระยะการล็อกเป้า

    private float shootTimer;
    public int powerBlastLevel = 1; // ระดับ Power Blast
    public int fastShootingLevel = 1; // ระดับ Fast Shooting

    void Update()
    {
        // อัพเดตตัวจับเวลา
        shootTimer += Time.deltaTime;

        // ตรวจสอบว่าถึงเวลายิงหรือยัง
        if (shootTimer >= shootRate)
        {
            Shoot();
            shootTimer = 0f; // รีเซ็ตตัวจับเวลา
        }
    }

    void Shoot()
    {
        // ค้นหา Enemy ที่อยู่ในระยะการล็อกเป้า
        GameObject targetEnemy = FindClosestEnemy();

        if (targetEnemy != null)
        {
            // คำนวณทิศทางไปยังศัตรู
            Vector2 direction = (targetEnemy.transform.position - firePoint.position).normalized;

            // สร้างกระสุนที่ตำแหน่งและการหมุนของ firePoint
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

            // หมุนกระสุนให้หันไปยังศัตรู
            projectile.transform.right = direction;

            // กำหนดความเร็วให้กระสุนตามทิศทางไปยังศัตรู
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.velocity = direction * projectileSpeed;
        }
    }

    GameObject FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closestEnemy = null;
        float minDistance = targetRange;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestEnemy = enemy;
            }
        }

        return closestEnemy;
    }

    public void UpgradeFastShooting()
    {
        if (fastShootingLevel < 3)
        {
            fastShootingLevel++;

            // ปรับ shootRate ตามระดับ
            switch (fastShootingLevel)
            {
                case 2:
                    shootRate = 0.4f;
                    break;
                case 3:
                    shootRate = 0.3f;
                    break;
                default:
                    shootRate = 0.5f;
                    break;
            }
        }
    }
}
