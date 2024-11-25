using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    // ��Ҿ�鹰ҹ�ͧʡ��
    public int powerBlastLevel = 1;     // �дѺ Power Blast
    public PowerBlastAOE powerBlastScript; // ��ҧ�ԧ�֧ PowerBlastAOE script

    public float shootRate = 0.5f;       // ��������㹡���ԧ
    public float moveSpeed = 5f;         // ��������㹡������͹���

    // ����÷�������дѺ�ͧ����ʡ��
    
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
            case 0: // Power Blast (���Դ��ѧ)
                powerBlastLevel++;
                powerBlastScript.UpgradePowerBlast(powerBlastLevel); // ���¡�ѧ��ѹ UpgradePowerBlast �ҡ PowerBlastAOE.cs
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
        Debug.Log("Power Blast Level: " + powerBlastLevel);
        Debug.Log("Shoot Speed Level: " + shootSpeedLevel);
        Debug.Log("Move Speed Level: " + moveSpeedLevel);
    }
}
