using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1; // ����������·�����ع���ҧ����ѵ��

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) // ��Ǩ�ͺ��ҡ���ع���Ѻ�ѵ���������
        {
            // ��Ҷ֧ʤ�Ի�� EnemyHealth �ͧ�ѵ��
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage); // Ŵ HP �ͧ�ѵ��
            }

            Destroy(gameObject); // ����¡���ع��ѧ�ҡ��
        }
    }
}
