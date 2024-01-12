using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamePlayController : MonoBehaviour
{
    private GameObject pausePanel;

    [SerializeField] 
    private GameObject resumePanel;
    public void PauseGameButton()
    {
        pausePanel.SetActive(true);
            Time.timeScale =0f;

    }
    public void ResumeButton()
    {
        pausePanel.SetActive(false);
        Time.timeScale =1f;
    }
}
