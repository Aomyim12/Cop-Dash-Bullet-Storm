using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform; 

        if (player == null)
        {
            
            Destroy(gameObject); // ����� Enemy �����辺 Player
            return; // �͡�ҡ�ѧ��ѹ Start
        }

        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        // ��Ǩ�ͺ��Ҽ������ѧ�������������
        if (player == null)
        {
            Destroy(gameObject); // ����� Enemy
            return; // �͡�ҡ�ѧ��ѹ Update
        }

        // �������͹��Ǣͧ Enemy
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position; // �׹���������
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime); // ��¡�Ѻ
        }

        // ����ԧ
        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots; // ��������
        }
        else
        {
            timeBtwShots -= Time.deltaTime; // Ŵ����
        }
    }
}
