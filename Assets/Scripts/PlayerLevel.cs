using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    public int playerLevel = 1;
    private int itemCount = 0; // �Ѻ�ӹǹ����������

    public void CollectItem()
    {
        itemCount++;
        if (itemCount >= 1)
        {
            itemCount = 0; // ���絨ӹǹ�����
            IncreaseLevel(); // ���������
            SkillSelectionManager.Instance.ShowSkillSelectionMenu(); // �ʴ�˹�Ҩ����͡ʡ��
        }
    }

    private void IncreaseLevel()
    {
        playerLevel++;
        Debug.Log("Player level increased to: " + playerLevel);
    }
}
