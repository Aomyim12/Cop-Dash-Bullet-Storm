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
                playerLevel.CollectItem(); // เพิ่มจำนวนไอเท็มที่เก็บ
                Destroy(gameObject); // ทำลายไอเท็มหลังจากเก็บแล้ว
            }
        }
    }
}
