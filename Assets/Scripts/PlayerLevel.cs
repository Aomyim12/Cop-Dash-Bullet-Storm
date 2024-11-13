using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    public int playerLevel = 1;
    private int itemCount = 0; // นับจำนวนไอเท็มที่เก็บ

    public void CollectItem()
    {
        itemCount++;
        if (itemCount >= 1)
        {
            itemCount = 0; // รีเซ็ตจำนวนไอเท็ม
            IncreaseLevel(); // เพิ่มเลเวล
            SkillSelectionManager.Instance.ShowSkillSelectionMenu(); // แสดงหน้าจอเลือกสกิล
        }
    }

    private void IncreaseLevel()
    {
        playerLevel++;
        Debug.Log("Player level increased to: " + playerLevel);
    }
}
