using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour
{
    public int playerLevel = 1; // ระดับเลเวลของผู้เล่น
    private int itemCount = 0; // จำนวนไอเท็มที่เก็บ
    public int itemsToLevelUp = 10; // จำนวนไอเท็มที่ต้องการเพื่อเพิ่มเลเวล

    private Slider levelProgressBar; // Slider UI สำหรับหลอดเลเวล

    private void Start()
    {
        // ค้นหา Slider ใน Scene โดยใช้ชื่อ
        levelProgressBar = GameObject.Find("LevelProgressBar")?.GetComponent<Slider>();

        if (levelProgressBar != null)
        {
            levelProgressBar.maxValue = itemsToLevelUp; // ตั้งค่าขีดสุดของ Slider
            levelProgressBar.value = 0; // ตั้งค่าเริ่มต้นเป็น 0
        }
        else
        {
            Debug.LogError("LevelProgressBar Slider not found in the scene!");
        }
    }

    public void CollectItem()
    {
        itemCount++;
        UpdateLevelProgressBar(); // อัปเดตหลอดเลเวล

        if (itemCount >= itemsToLevelUp)
        {
            itemCount = 0; // รีเซ็ตจำนวนไอเท็ม
            IncreaseLevel(); // เพิ่มเลเวล
            SkillSelectionManager.Instance.ShowSkillSelectionMenu(); // แสดงหน้าจอเลือกสกิล
        }
    }

    private void UpdateLevelProgressBar()
    {
        if (levelProgressBar != null)
        {
            levelProgressBar.value = itemCount; // ตั้งค่าของ Slider ตามจำนวนไอเท็ม
        }
    }

    private void IncreaseLevel()
    {
        playerLevel++;
        Debug.Log("Player level increased to: " + playerLevel);
    }
}
