using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSelectionManager : MonoBehaviour
{
    public static SkillSelectionManager Instance;
    public GameObject skillSelectionUI; // UI ����Ѻ���͡ʡ��

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void ShowSkillSelection()
    {
        skillSelectionUI.SetActive(true); // �ʴ� UI
        Time.timeScale = 0; // ��ش��
    }

    public void SelectSkill(int skillIndex)
    {
        Debug.Log("Skill " + skillIndex + " selected.");
        skillSelectionUI.SetActive(false); // �Դ UI
        Time.timeScale = 1; // ��Ѻ����������
    }
}
