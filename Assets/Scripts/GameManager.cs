using UnityEngine;
using UnityEngine.SceneManagement; // ����Ѻ�Ѵ��éҡ
using UnityEngine.UI; // ����Ѻ UI

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI; // UI ����Ѻ�ʴ���ͤ��� "You Die"
    public Button restartButton; // ���� Restart


    public GameObject bossPrefab;    // Prefab �ͧ Boss �������ҧ
    public GameObject magicWitchPrefab; // Prefab �ͧ��Ƕ������Ҵ��ѧ�Ƿ
    public float spawnTimeBoss = 20f; // ���ҷ��� Spawn Boss (20 �Թҷ�)
    public float spawnTimeWitch = 30f; // ���ҷ��� Spawn ��Ƕ������Ҵ (30 �Թҷ�)
    private float timer = 0f;
    private bool bossSpawned = false; // ���������� Boss �١ Spawn ���������ѧ
    private bool witchSpawned = false; // ������������Ƕ������Ҵ�١ Spawn ���������ѧ

    public float spawnTime = 40f; // ���ҷ��� Spawn ����ͧ����Ф� (40 �Թҷ�)
    private bool spawned = false;


    private void Start()
    {
        // ��͹ UI ����������������
        gameOverUI.SetActive(false);

        // ���� listener ���Ѻ���� Restart
        restartButton.onClick.AddListener(RestartGame);
        restartButton.gameObject.SetActive(false); // ��͹���� Restart �������
    }

    private void Update()
    {
        timer += Time.deltaTime;

        // ��Ǩ�ͺ��� Boss �ѧ����� Spawn ������Ҽ�ҹ件֧����
        if (!bossSpawned && timer >= spawnTimeBoss)
        {
            SpawnBoss();
            bossSpawned = true;
        }

        // ��Ǩ�ͺ�����Ƕ������Ҵ�ѧ����� Spawn ������Ҽ�ҹ件֧����
        if (!witchSpawned && timer >= spawnTimeWitch)
        {
            SpawnMagicWitch();
            witchSpawned = true;
        }

        if (!spawned && timer >= spawnTime)
        {
            SpawnBossAndWitch();
            spawned = true;  // ��駤���� true ���������� spawn ���
        }
    }

    // �ѧ��ѹ Spawn Boss
    void SpawnBoss()
    {
        // ���ҧ Boss �����˹觷���ͧ��� (�� ���� �Ѻ������)
        GameObject boss = Instantiate(bossPrefab, new Vector3(10f, 0f, 0f), Quaternion.identity); // ��Ѻ���˹觵����ͧ���

        // ���¡��ѧ��ѹ StartRunning � BossRunner ���������������
        boss.GetComponent<BossRunner>().StartRunning();

        Debug.Log("Boss Spawned and Started Running!");
    }

    // �ѧ��ѹ Spawn ��Ƕ������Ҵ��ѧ�Ƿ
    void SpawnMagicWitch()
    {
        // ���ҧ��Ƕ������Ҵ�����˹觷���ͧ��� (�� ���� �Ѻ������)
        GameObject witch = Instantiate(magicWitchPrefab, new Vector3(10f, 0f, 0f), Quaternion.identity); // ��Ѻ���˹觵����ͧ���

        // ���¡��ѧ��ѹ������������Ţͧ��Ƕ������Ҵ
        witch.GetComponent<MagicWitch>().StartShooting();

        Debug.Log("Magic Witch Spawned and Started Attacking!");
    }

    void SpawnBossAndWitch()
    {
        // ���ҧ Boss �����˹觷���ͧ���
        GameObject boss = Instantiate(bossPrefab, new Vector3(10f, 0f, 0f), Quaternion.identity); // ��Ѻ���˹觵����ͧ���
        // ���¡��ѧ��ѹ StartRunning � BossRunner ���������������
        boss.GetComponent<BossRunner>().StartRunning();

        // ���ҧ��Ƕ������Ҵ�����˹觷���ͧ���
        GameObject witch = Instantiate(magicWitchPrefab, new Vector3(10f, 0f, 0f), Quaternion.identity); // ��Ѻ���˹觵����ͧ���
        // ���¡��ѧ��ѹ������������Ţͧ��Ƕ������Ҵ
        witch.GetComponent<MagicWitch>().StartShooting();

        Debug.Log("Boss and Magic Witch Spawned and Started Running/Attacking!");
    }

    public void PlayerDied()
    {
        // �ʴ� UI ���������
        gameOverUI.SetActive(true);
        restartButton.gameObject.SetActive(true); // �ʴ����� Restart
    }

    private void RestartGame()
    {
        // ��Ŵ�ҡ�Ѩ�غѹ����
        SceneManager.LoadScene("Menu");
    }
}
