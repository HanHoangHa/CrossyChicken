using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        timeUpdate = Time.time;
        moveScript = GetComponent<Move>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

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
}

