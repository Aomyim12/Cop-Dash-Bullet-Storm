using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSelectionManager : MonoBehaviour
{
    public static SkillSelectionManager Instance; // ���ҧ����� static ����Ѻ Singleton

    public PlayerSkills playerSkills; // ��ҧ�ԧ�֧ PlayerSkills
    public GameObject skillSelectionUI; // UI ����Ѻ������͡ʡ��
    public GameObject[] skillButtons;  // ������������͡ʡ��

    private void Awake()
    {
        // ��Ǩ�ͺ����� Instance �����������
        if (Instance == null)
        {
            Instance = this; // �ҡ����� ����駤���繵���ù��
        }
        else if (Instance != this)
        {
            Destroy(gameObject); // ����� Instance �������� �����������ͺ�硵���
        }

        // ����� SkillSelectionManager ���١���������� Scene ����¹
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (playerSkills == null)
        {
            playerSkills = FindObjectOfType<PlayerSkills>();
        }

        skillSelectionUI.SetActive(false); // ��͹ UI ������������
    }


    // �ѧ��ѹ�����ʴ� UI ���͡ʡ������ͼ�������������ú 10 ���
    public void ShowSkillSelectionMenu()
    {
        skillSelectionUI.SetActive(true); // �ʴ� UI
        Time.timeScale = 0f; // ��ش��
    }

    // �ѧ��ѹ���ж١���¡����ͼ��������͡ʡ��
    public void SelectSkill(int skillIndex)
    {
        playerSkills.UpgradeSkill(skillIndex); // �ѻ�ôʡ�ŵ��������͡
        skillSelectionUI.SetActive(false); // ��͹ UI
        Time.timeScale = 1f; // �����������
    }

    public void UpdateSkillButtons()
    {
        for (int i = 0; i < skillButtons.Length; i++)
        {
            bool isUnlocked = i switch
            {
                0 => playerSkills.powerBlastLevel > i,
                1 => playerSkills.shootSpeedLevel > i,
                2 => playerSkills.moveSpeedLevel > i,
                _ => false
            };

            skillButtons[i].SetActive(isUnlocked); // �Դ/�Դ����������͹�
        }
    }

}
