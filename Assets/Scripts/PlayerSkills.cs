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

    public delegate void PlayerSpawnedHandler(PlayerSkills playerSkills);
    public static event PlayerSpawnedHandler OnPlayerSpawned;

    private void Awake()
    {
        OnPlayerSpawned?.Invoke(this);
    }

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

    // �ѻ�ô Power Blast
    public void UpgradePowerBlast()
    {
        powerBlastLevel++;
        powerBlastScript.UpgradePowerBlast(powerBlastLevel); // ���¡�ѧ��ѹ UpgradePowerBlast �ҡ PowerBlastAOE.cs
        Debug.Log("Power Blast Level: " + powerBlastLevel);
    }

    // �ѻ�ô Fast Shooting
    public void UpgradeFastShooting()
    {
        shootSpeedLevel++;
        shootRate = Mathf.Max(0.1f, shootRate - 0.1f); // Ŵ��������㹡���ԧ
        playerAutoShooting.UpgradeFastShooting(); // ���¡�ѧ��ѹ� PlayerAutoShooting
        Debug.Log("Shoot Speed Level: " + shootSpeedLevel);
    }

    // �ѻ�ô Speed Boost
    public void UpgradeSpeedBoost()
    {
        moveSpeedLevel++;
        moveSpeed += 1f; // ������������㹡������͹���
        playerMovement.UpgradeSpeedBoost(moveSpeed); // ���¡�ѧ��ѹ� PlayerMovement
        Debug.Log("Move Speed Level: " + moveSpeedLevel);
    }
}
