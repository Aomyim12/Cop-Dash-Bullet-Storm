using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    private Transform player;
    public float speed;
    public int damageAmount = 10; // �ӹǹ����������·�� Player �����Ѻ

    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Transform>(); // �� ? ������ա����§ NullReferenceException
    }

    // Update is called once per frame
    void Update()
    {
        // ��Ǩ�ͺ��Ҽ������ѧ�������������
        if (player == null)
        {
            // �ҡ����ռ����� ������� Enemy ������ش��÷ӧҹ�ͧʤ�Ի��
            Destroy(gameObject); // ����� Enemy ������ enabled = false; �������ͧ��÷����
            return; // �͡�ҡ�ѧ��ѹ Update
        }

        distance = Vector2.Distance(transform.position, player.position);
        Vector2 direction = player.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // ��Ǩ�ͺ��� Collider ��誹��� Player
        {
            // ���¡�ѧ��ѹ��� Player ���Ѻ�����������
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}
