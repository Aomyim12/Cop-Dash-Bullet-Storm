using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDropItem : MonoBehaviour
{
    public GameObject itemPrefab; // Prefab ของไอเท็มที่จะดรอป
    public float dropChance = 0.5f; // โอกาสในการดรอป (เช่น 0.5 = 50%)

    public void DropItem()
    {
        if (Random.value < dropChance) // เช็คโอกาสในการดรอป
        {
            Instantiate(itemPrefab, transform.position, Quaternion.identity); // สร้างไอเท็มที่ตำแหน่งของศัตรู
        }
    }

    private void OnDestroy()
    {
        DropItem(); // เรียกฟังก์ชันดรอปไอเท็มเมื่อศัตรูถูกทำลาย
    }
}
