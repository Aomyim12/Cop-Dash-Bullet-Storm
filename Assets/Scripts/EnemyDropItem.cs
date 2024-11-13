using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDropItem : MonoBehaviour
{
    public GameObject itemPrefab; // Prefab �ͧ��������д�ͻ
    public float dropChance = 0.5f; // �͡��㹡�ô�ͻ (�� 0.5 = 50%)

    public void DropItem()
    {
        if (Random.value < dropChance) // ���͡��㹡�ô�ͻ
        {
            Instantiate(itemPrefab, transform.position, Quaternion.identity); // ���ҧ����������˹觢ͧ�ѵ��
        }
    }

    private void OnDestroy()
    {
        DropItem(); // ���¡�ѧ��ѹ��ͻ�����������ѵ�ٶ١�����
    }
}
