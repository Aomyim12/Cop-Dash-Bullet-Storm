using UnityEngine;
using UnityEngine.SceneManagement; // สำหรับจัดการฉาก
using UnityEngine.UI; // สำหรับ UI

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI; // UI สำหรับแสดงข้อความ "You Die"
    public Button restartButton; // ปุ่ม Restart

    private void Start()
    {
        // ซ่อน UI เกมโอเวอร์เริ่มต้น
        gameOverUI.SetActive(false);

        // เพิ่ม listener ให้กับปุ่ม Restart
        restartButton.onClick.AddListener(RestartGame);
        restartButton.gameObject.SetActive(false); // ซ่อนปุ่ม Restart เริ่มต้น
    }

    public void PlayerDied()
    {
        // แสดง UI เกมโอเวอร์
        gameOverUI.SetActive(true);
        restartButton.gameObject.SetActive(true); // แสดงปุ่ม Restart
    }

    private void RestartGame()
    {
        // โหลดฉากปัจจุบันใหม่
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
