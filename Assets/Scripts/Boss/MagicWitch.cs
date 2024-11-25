using UnityEngine;
using UnityEngine.AI; // ������Ѻ�������͹������ NavMeshAgent

public class MagicWitch : MonoBehaviour
{

    public float speed;
    public float retreatDistance;
    public float stoppingDistance;

    public float shootRate = 1f;  // ��������㹡���ԧ��ѧ�Ƿ
    public GameObject magicProjectilePrefab; // Prefab �ͧ��ѧ�Ƿ����ԧ�͡�
    private float shootTimer = 0f;

    private NavMeshAgent agent;  // ��ǤǺ����������͹���
    public Transform player;  // ���˹觢ͧ������

    void Start()
    {
        // �� NavMeshAgent 㹵�� Magic Witch
        agent = GetComponent<NavMeshAgent>();
        if (player == null)
        {
            player = GameObject.FindWithTag("Player").transform;  // ���Ҽ��������ѵ��ѵ�
        }
    }

    void Update()
    {
        shootTimer += Time.deltaTime;

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

        // �ԧ��ѧ�Ƿ����������Ͷ֧���ҷ���˹�
        if (shootTimer >= shootRate)
        {
            ShootMagicProjectile();
            shootTimer = 0f;  // ���絵�ǨѺ����
        }
    }

    // �ѧ��ѹ�ԧ��ѧ�Ƿ
    void ShootMagicProjectile()
    {
        // ���ҧ��ѧ�Ƿ����ԧ�͡�㹷�ȷҧ����ͧ���
        Instantiate(magicProjectilePrefab, transform.position, Quaternion.identity);

        Debug.Log("Magic Witch is shooting!");
    }

    // ���¡��ѧ��ѹ�������������������
    public void StartShooting()
    {
        // �������������������������Ƕ������Ҵ�١ Spawn
        Debug.Log("Magic Witch Started Shooting!");
    }
}
