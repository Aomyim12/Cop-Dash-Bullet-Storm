using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour
{
    public int playerLevel = 1; // �дѺ����Ţͧ������
    private int itemCount = 0; // �ӹǹ����������
    public int itemsToLevelUp = 10; // �ӹǹ���������ͧ����������������

    private Slider levelProgressBar; // Slider UI ����Ѻ��ʹ�����

    private void Start()
    {
        // ���� Slider � Scene �������
        levelProgressBar = GameObject.Find("LevelProgressBar")?.GetComponent<Slider>();

        if (levelProgressBar != null)
        {
            levelProgressBar.maxValue = itemsToLevelUp; // ��駤�Ңմ�ش�ͧ Slider
            levelProgressBar.value = 0; // ��駤����������� 0
        }
        else
        {
            Debug.LogError("LevelProgressBar Slider not found in the scene!");
        }
    }

    public void CollectItem()
    {
        itemCount++;
        UpdateLevelProgressBar(); // �ѻവ��ʹ�����

        if (itemCount >= itemsToLevelUp)
        {
            itemCount = 0; // ���絨ӹǹ�����
            IncreaseLevel(); // ���������
            SkillSelectionManager.Instance.ShowSkillSelectionMenu(); // �ʴ�˹�Ҩ����͡ʡ��
        }
    }

    private void UpdateLevelProgressBar()
    {
        if (levelProgressBar != null)
        {
            levelProgressBar.value = itemCount; // ��駤�Ңͧ Slider ����ӹǹ�����
        }
    }

    private void IncreaseLevel()
    {
        playerLevel++;
        Debug.Log("Player level increased to: " + playerLevel);
    }
}
