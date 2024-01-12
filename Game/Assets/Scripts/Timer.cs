using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    public GameObject gameOverUI;

    // Thêm biến và tham chiếu liên quan đến script Move
    private Move moveScript;
    private float posYChicken;
    private AudioSource audioSource;
    public AudioClip death;

    private bool gameOverTriggered = false; // Thêm biến để đảm bảo TriggerGameOver chỉ được gọi một lần

    void Start()
    {
        // Thực hiện khởi tạo biến và tham chiếu ở đây
        moveScript = GetComponent<Move>();
        audioSource = GetComponent<AudioSource>();
        posYChicken = transform.position.y;
    }

    void Update()
    {
        if (remainingTime > 0 && !gameOverTriggered) // Thêm điều kiện kiểm tra gameOverTriggered
        {
            remainingTime -= Time.deltaTime;
            UpdateTimerDisplay(remainingTime);
        }
        else
        {
            if (remainingTime != 0 && !gameOverTriggered)
            {
                remainingTime = 0;
                UpdateTimerDisplay(remainingTime);
                TriggerGameOver();
            }
        }
    }

    void UpdateTimerDisplay(float timeToDisplay)
    {
        // Loại bỏ phần timeToDisplay += 1;
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void TriggerGameOver()
    {
        moveScript.gameOver = true;
        Debug.Log(moveScript.gameOver);
        posYChicken = transform.position.y; // Gán giá trị mới cho posYChicken
        audioSource.PlayOneShot(death, 1f);
        gameOverUI.SetActive(true);
        gameOverTriggered = true; // Đặt gameOverTriggered thành true để đảm bảo TriggerGameOver chỉ được gọi một lần
    }
}
