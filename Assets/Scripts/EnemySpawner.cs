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
            // ��Ǩ�ͺ��� Player �ѧ�ժ��Ե�����������
            if (playerHealth == null || playerHealth.currentHealth <= 0)
            {
                isSpawning = false; // ��ش������ҧ�ѵ��
                yield break; // �͡�ҡ Coroutine
            }

            yield return new WaitForSeconds(spawnRate); // �ͨ����Ҩж֧�������ҧ�ѵ������

            // �������͡ prefab �ѵ�٨ҡ List
            int randomIndex = Random.Range(0, enemyPrefabs.Count);
            GameObject enemyPrefab = enemyPrefabs[randomIndex];

            // ���ҧ�ѵ�ٷ����˹�����
            Vector2 spawnPosition = new Vector2(Random.Range(-10, 10), Random.Range(-5, 5));
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            // Ŵ spawnRate �������������������������ҧ�ѵ�ٶ����
            if (currentTime <= 15f && spawnRate > 0.5f) // Ŵ spawnRate ���������������
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
