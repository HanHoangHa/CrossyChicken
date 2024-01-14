using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
using UnityEngine.PlayerLoop;

public class Timer : MonoBehaviour
{
    Move moveScript;
    AudioSource audioSource;
    public AudioClip death;
    public GameObject gameOverUI;
    private float timeUpdate;
    private float distanceTime;
    void Start()
    {
        moveScript = GetComponent<Move>();
        audioSource = GetComponent<AudioSource>();
=======
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
>>>>>>> f4b8d0330673f063221564c524af76365613fda2
    }

    void Update()
    {
<<<<<<< HEAD
        distanceTime = Time.time - timeUpdate;
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S)|| Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) && moveScript.gameOver == false)
        {
            timeUpdate = Time.time;
        }
        if(distanceTime > 5 && moveScript.gameOver == false)
        {
            moveScript.gameOver = true;
            Debug.Log(moveScript.gameOver);
            audioSource.PlayOneShot(death, 1f);
            gameOverUI.SetActive(true);
        }
    }

=======
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
>>>>>>> f4b8d0330673f063221564c524af76365613fda2
}
