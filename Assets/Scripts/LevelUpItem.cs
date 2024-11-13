using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerLevel playerLevel = other.GetComponent<PlayerLevel>();
            if (playerLevel != null)
            {
                playerLevel.CollectItem(); // �����ӹǹ����������
                Destroy(gameObject); // ������������ѧ�ҡ������
            }
        }
    }
}
