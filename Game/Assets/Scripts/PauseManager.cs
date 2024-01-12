using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f; // Dừng thời gian
        // Thêm các hành động khác cần thiết khi game được pause
    }

    void ResumeGame()
    {
        Time.timeScale = 1f; // Tiếp tục thời gian
        // Thêm các hành động khác cần thiết khi game được resume
    }
}
