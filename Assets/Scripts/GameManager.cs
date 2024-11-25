using UnityEngine;
using UnityEngine.SceneManagement; // ����Ѻ�Ѵ��éҡ
using UnityEngine.UI; // ����Ѻ UI

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI; // UI ����Ѻ�ʴ���ͤ��� "You Die"
    public Button restartButton; // ���� Restart
    public GameObject bossPrefab;    // Prefab �ͧ Boss �������ҧ
    public float spawnTime = 20f;    // ���ҷ��� Spawn Boss (20 �Թҷ�)
    private float timer = 0f;
    private bool bossSpawned = false; // ���������� Boss �١ Spawn ���������ѧ


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
        if (!bossSpawned) // ��Ǩ�ͺ��� Boss �ѧ���١ Spawn
        {
            timer += Time.deltaTime;

            // �ҡ���Ҽ�ҹ件֧ 20 �Թҷ� ��� Spawn Boss
            if (timer >= spawnTime)
            {
                SpawnBoss();
                bossSpawned = true; // ��駤�Ҥ����� Boss �١ Spawn ����
                timer = 0f; // ���絵�ǨѺ����
            }
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

    public void PlayerDied()
    {
        // �ʴ� UI ���������
        gameOverUI.SetActive(true);
        restartButton.gameObject.SetActive(true); // �ʴ����� Restart
    }

    private void RestartGame()
    {
        // ��Ŵ�ҡ�Ѩ�غѹ����
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
