using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    // ค่าพื้นฐานของสกิล
    public int powerBlastLevel = 1;     // ระดับ Power Blast
    public PowerBlastAOE powerBlastScript; // อ้างอิงถึง PowerBlastAOE script

    public float shootRate = 0.5f;       // ความเร็วในการยิง
    public float moveSpeed = 5f;         // ความเร็วในการเคลื่อนที่

    // ตัวแปรที่ใช้เก็บระดับของแต่ละสกิล
    
    public int shootSpeedLevel = 1;
    public int moveSpeedLevel = 1;

    public PlayerAutoShooting playerAutoShooting;
    public PlayerMovement playerMovement;

    private void Start()
    {
        if (powerBlastScript == null)
        {
            powerBlastScript = GetComponent<PowerBlastAOE>();
        }

        if (playerAutoShooting == null)
        {
            playerAutoShooting = GetComponent<PlayerAutoShooting>();
        }

        if (playerMovement == null)
        {
            playerMovement = GetComponent<PlayerMovement>();
        }
    }



    public void UpgradeSkill(int skillIndex)
    {
        switch (skillIndex)
        {
            case 0: // Power Blast (ระเบิดพลัง)
                powerBlastLevel++;
                powerBlastScript.UpgradePowerBlast(powerBlastLevel); // เรียกฟังก์ชัน UpgradePowerBlast จาก PowerBlastAOE.cs
                break;
            case 1: // ยิงเร็วขึ้น (Fast Shooting)
                shootSpeedLevel++;
                shootRate = Mathf.Max(0.1f, shootRate - 0.1f); // ลดความเร็วในการยิง
                playerAutoShooting.UpgradeFastShooting(); // เรียกฟังก์ชันใน PlayerAutoShooting
                break;
            case 2: // วิ่งเร็วขึ้น (Speed Boost)
                moveSpeedLevel++;
                moveSpeed += 1f; // เพิ่มความเร็วในการเคลื่อนที่
                playerMovement.UpgradeSpeedBoost(moveSpeed); // เรียกฟังก์ชันใน PlayerMovement
                break;
        }

        // ตรวจสอบสถานะของสกิล
        Debug.Log("Power Blast Level: " + powerBlastLevel);
        Debug.Log("Shoot Speed Level: " + shootSpeedLevel);
        Debug.Log("Move Speed Level: " + moveSpeedLevel);
    }
}
