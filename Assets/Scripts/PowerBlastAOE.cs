using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBlastAOE : MonoBehaviour
{
    public float powerBlastRadius = 5f; // ����բͧ���Դ (AOE)
    public int damage = 10;          // ����������·������Ѻ�ѵ��
    public float powerBlastCooldown = 5f; // ���������鹢ͧ���Ҥ�Ŵ�ǹ�
    private float powerBlastTimer = 0f;   // ��ǨѺ����㹡�÷����Դ

    public int powerBlastLevel = 1;    // �дѺ Power Blast
    public GameObject explosionEffectPrefab; // Prefab ����Ѻ�Ϳ࿡�����Դ

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
        // ���ѵ�������� AOE
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, powerBlastRadius);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                // �Ӥ��������������ѵ��
                enemy.GetComponent<EnemyHealth>().TakeDamage(damage);
            }
        }

        // �ʴ��Ϳ࿡�����Դ
        ShowExplosionEffect();

        Debug.Log("Power Blast AOE Attack!");
    }

    void ShowExplosionEffect()
    {
        if (explosionEffectPrefab != null)
        {
            // ���ҧ�Ϳ࿡�����Դ�����˹觢ͧ������
            GameObject explosion = Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);

            // ������Ϳ࿡����ѧ�ҡ���ҷ���˹�
            Destroy(explosion, 2f); // ��Ѻ���ҵ�������������
        }
    }

    public void UpgradePowerBlast(int level)
    {
        powerBlastLevel = level;

        // �ѻ�ô��Ҥ�Ŵ�ǹ����дѺ
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
