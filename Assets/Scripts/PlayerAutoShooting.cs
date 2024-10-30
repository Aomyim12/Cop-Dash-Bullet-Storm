using UnityEngine;

public class PlayerAutoShooting : MonoBehaviour
{
    public GameObject projectilePrefab; // prefab �ͧ����ع
    public Transform firePoint;         // �ش������ع�ж١�ԧ�͡��
    public float shootRate = 0.5f;      // �������㹡���ԧ (�Թҷ�)
    public float projectileSpeed = 10f; // �������Ǣͧ����ع
    public float targetRange = 10f;     // ���С����͡���

    private float shootTimer;

    void Update()
    {
        // �Ѿവ��ǨѺ����
        shootTimer += Time.deltaTime;

        // ��Ǩ�ͺ��Ҷ֧�����ԧ�����ѧ
        if (shootTimer >= shootRate)
        {
            Shoot();
            shootTimer = 0f; // ���絵�ǨѺ����
        }
    }

    void Shoot()
    {
        // ���� Enemy �����������С����͡���
        GameObject targetEnemy = FindClosestEnemy();

        if (targetEnemy != null)
        {
            // �ӹǳ��ȷҧ��ѧ�ѵ��
            Vector2 direction = (targetEnemy.transform.position - firePoint.position).normalized;

            // ���ҧ����ع�����˹���С����ع�ͧ firePoint
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

            // ��ع����ع����ѹ��ѧ�ѵ��
            projectile.transform.right = direction;

            // ��˹���������������ع�����ȷҧ��ѧ�ѵ��
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
}
