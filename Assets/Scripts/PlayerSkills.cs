using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    // ��Ҿ�鹰ҹ�ͧʡ��
    public float explosionCooldown = 5f; // �������� cooldown �ͧʡ�����Դ
    public float shootRate = 0.5f;       // ��������㹡���ԧ
    public float moveSpeed = 5f;         // ��������㹡������͹���

    // ����÷�������дѺ�ͧ����ʡ��
    public int explosionLevel = 1;
    public int shootSpeedLevel = 1;
    public int moveSpeedLevel = 1;

    public PlayerAutoShooting playerAutoShooting;
    public PlayerMovement playerMovement;

    public void UpgradeSkill(int skillIndex)
    {
        switch (skillIndex)
        {
            case 0: // ���Դ��ѧ (Power Blast)
                explosionLevel++;
                explosionCooldown = Mathf.Max(1f, explosionCooldown - 1f); // Ŵ���� cooldown �ͧ���Դ
                break;
            case 1: // �ԧ���Ǣ�� (Fast Shooting)
                shootSpeedLevel++;
                shootRate = Mathf.Max(0.1f, shootRate - 0.1f); // Ŵ��������㹡���ԧ
                playerAutoShooting.UpgradeFastShooting(); // ���¡�ѧ��ѹ� PlayerAutoShooting
                break;
            case 2: // ������Ǣ�� (Speed Boost)
                moveSpeedLevel++;
                moveSpeed += 1f; // ������������㹡������͹���
                playerMovement.UpgradeSpeedBoost(moveSpeed); // ���¡�ѧ��ѹ� PlayerMovement
                break;
        }

        // ��Ǩ�ͺʶҹТͧʡ��
        Debug.Log("Explosion Level: " + explosionLevel);
        Debug.Log("Shoot Speed Level: " + shootSpeedLevel);
        Debug.Log("Move Speed Level: " + moveSpeedLevel);
    }
}
