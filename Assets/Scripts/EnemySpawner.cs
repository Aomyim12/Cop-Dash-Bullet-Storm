using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemyPrefabs; // ��¡�� prefab �ͧ�ѵ�������ٻẺ
    public float spawnRate = 2f;          // �ѵ�ҡ���Դ�ѵ���������
    public float spawnRateIncrease = 0.5f; // �ѵ�ҡ����������������Դ�ѵ��
    public float totalTime = 5f;         // ���ҹѺ�����ѧ������ (�Թҷ�)
    public TextMeshProUGUI countdownText; // UI Text ����Ѻ�ʴ����Ҷ����ѧ
    public GameObject winPanel;            // Panel ����Ѻ�ʴ���ͤ��� "You Win!!"
    

    private float currentTime;            // ���һѨ�غѹ
    private bool isSpawning = true;       // ������ѧ���ҧ�ѵ�������������
    private PlayerHealth playerHealth;    // ���������Ѻ��ҧ�ԧ�֧ PlayerHealth

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>(); // ���� PlayerHealth 㹩ҡ
        currentTime = totalTime;         // ��駤�������������
        StartCoroutine(SpawnEnemies());  // �����������ҧ�ѵ��
        StartCoroutine(CountdownTimer()); // �������ùѺ�����ѧ
        winPanel.SetActive(false); // ��͹ Win Panel 㹵͹�������
    }

    IEnumerator SpawnEnemies()
    {
        while (isSpawning)
        {
            if (playerHealth == null || playerHealth.currentHealth <= 0)
            {
                isSpawning = false;
                yield break;
            }

            yield return new WaitForSeconds(spawnRate);

            int randomIndex = Random.Range(0, enemyPrefabs.Count);
            GameObject enemyPrefab = enemyPrefabs[randomIndex];

            // �� Camera ���������˹觡���Դ����㹢ͺࢵ˹�Ҩ�
            Vector2 spawnPosition = Camera.main.ViewportToWorldPoint(
                new Vector2(Random.Range(0f, 1f), Random.Range(0f, 1f))
            );
            spawnPosition.x = Mathf.Clamp(spawnPosition.x, -10f, 10f); // �����˹�����㹢ͺࢵ
            spawnPosition.y = Mathf.Clamp(spawnPosition.y, -5f, 5f);

            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            if (currentTime <= 15f && spawnRate > 0.5f)
            {
                spawnRate -= spawnRateIncrease * Time.deltaTime;
            }
        }
    }

    IEnumerator CountdownTimer()
    {
        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime; // Ŵ���Ҷ����ѧ
            countdownText.text = "Time Left: " + Mathf.Ceil(currentTime).ToString(); // �Ѿവ UI

            yield return null; // ������Ѵ�
        }

        isSpawning = false; // ��ش������ҧ�ѵ��������������
        countdownText.text = "Time's Up!"; // �ʴ���ͤ���������������
        winPanel.SetActive(true); // �ʴ� Win Panel
    }
}
