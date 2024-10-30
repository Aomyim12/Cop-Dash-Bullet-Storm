using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public int damageAmount = 10; // �ӹǹ����������·�� Projectile �з���� Player

    private Transform player;
    private Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // ����Ҷ֧�ش���������ѧ
        if (Vector2.Distance(transform.position, target) < 0.1f) // �����зҧ���ͻ�ͧ�ѹ����� == ����Ҩ��������
        {
            DestroyProjectile();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // ���¡��ѧ��ѹ��� Player ���Ѻ�����������
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount); // �觨ӹǹ�����������
            }
            DestroyProjectile(); // ����� projectile ��ѧ�ҡ������� Player ���Ѻ�����������
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
