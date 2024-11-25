using System.Collections;
using UnityEngine;

public class BossRunner : MonoBehaviour
{
    public float speed = 10f;           // ��������㹡�����
    public float attackRange = 1.5f;    // ���С������
    public int attackDamage = 20;    // ����������¨ҡ�������
    private Transform player;           // ��ҧ�ԧ�֧������
    private bool isRunning = false;     // ��˹���� Boss ����������

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform; // ���Ҽ�����
    }

    void Update()
    {
        // �����Ҽ�����
        if (isRunning)
        {
            RunTowardsPlayer();
        }

        // ��Ǩ�ͺ�������
        AttackPlayer();
    }

    // �ѧ��ѹ������� Boss ���价�������
    void RunTowardsPlayer()
    {
        float step = speed * Time.deltaTime; // ���зҧ��� Boss ������������
        transform.position = Vector3.MoveTowards(transform.position, player.position, step);
    }

    // �ѧ��ѹ��Ǩ�ͺ�������
    void AttackPlayer()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= attackRange)
        {
            // ��� Boss ����������������Ӥ����������
            player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
            Debug.Log("Boss Attack!");
        }
    }

    // �ѧ��ѹ���ж١���¡��������������觢ͧ Boss
    public void StartRunning()
    {
        isRunning = true;
    }

    // �ѧ��ѹ������ش������
    public void StopRunning()
    {
        isRunning = false;
    }
}
