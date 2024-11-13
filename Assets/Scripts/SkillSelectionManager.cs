using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSelectionManager : MonoBehaviour
{
    public static SkillSelectionManager Instance;
    public GameObject skillSelectionUI; // UI สำหรับเลือกสกิล

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void ShowSkillSelection()
    {
        skillSelectionUI.SetActive(true); // แสดง UI
        Time.timeScale = 0; // หยุดเกม
    }

    public void SelectSkill(int skillIndex)
    {
        Debug.Log("Skill " + skillIndex + " selected.");
        skillSelectionUI.SetActive(false); // ปิด UI
        Time.timeScale = 1; // กลับมาเล่นเกมต่อ
    }
}
