using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSelectionManager : MonoBehaviour
{
    public static SkillSelectionManager Instance; // สร้างตัวแปร static สำหรับ Singleton

    public PlayerSkills playerSkills; // อ้างอิงถึง PlayerSkills
    public GameObject skillSelectionUI; // UI สำหรับการเลือกสกิล
    public GameObject[] skillButtons;  // ปุ่มที่ใช้เลือกสกิล

    private void Awake()
    {
        // ตรวจสอบว่ามี Instance อยู่หรือไม่
        if (Instance == null)
        {
            Instance = this; // หากไม่มี ให้ตั้งค่าเป็นตัวแปรนี้
        }
        else if (Instance != this)
        {
            Destroy(gameObject); // ถ้ามี Instance อยู่แล้ว ให้ทำลายเกมอ็อบเจ็กต์นี้
        }

        // ทำให้ SkillSelectionManager ไม่ถูกทำลายเมื่อ Scene เปลี่ยน
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        skillSelectionUI.SetActive(false); // ซ่อน UI เมื่อเริ่มเกม
    }

    // ฟังก์ชันนี้จะแสดง UI เลือกสกิลเมื่อผู้เล่นเก็บไอเท็มครบ 10 ชิ้น
    public void ShowSkillSelectionMenu()
    {
        skillSelectionUI.SetActive(true); // แสดง UI
        Time.timeScale = 0f; // หยุดเกม
    }

    // ฟังก์ชันนี้จะถูกเรียกเมื่อผู้เล่นเลือกสกิล
    public void SelectSkill(int skillIndex)
    {
        playerSkills.UpgradeSkill(skillIndex); // อัปเกรดสกิลตามที่เลือก
        skillSelectionUI.SetActive(false); // ซ่อน UI
        Time.timeScale = 1f; // เริ่มเกมใหม่
    }

    // ฟังก์ชันนี้จะใช้เพื่ออัปเดตปุ่มสกิลที่สามารถเลือกได้
    public void UpdateSkillButtons()
    {
        for (int i = 0; i < skillButtons.Length; i++)
        {
            if (i < playerSkills.explosionLevel) // ตรวจสอบว่าผู้เล่นปลดล็อคสกิลแล้วหรือยัง
            {
                skillButtons[i].SetActive(true); // แสดงปุ่ม
            }
            else
            {
                skillButtons[i].SetActive(false); // ซ่อนปุ่ม
            }
        }
    }
}
