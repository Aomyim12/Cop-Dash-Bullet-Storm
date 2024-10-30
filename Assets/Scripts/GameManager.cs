using UnityEngine;
using UnityEngine.SceneManagement; // ����Ѻ�Ѵ��éҡ
using UnityEngine.UI; // ����Ѻ UI

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI; // UI ����Ѻ�ʴ���ͤ��� "You Die"
    public Button restartButton; // ���� Restart

    private void Start()
    {
        // ��͹ UI ����������������
        gameOverUI.SetActive(false);

        // ���� listener ���Ѻ���� Restart
        restartButton.onClick.AddListener(RestartGame);
        restartButton.gameObject.SetActive(false); // ��͹���� Restart �������
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
