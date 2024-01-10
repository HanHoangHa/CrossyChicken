using UnityEngine;

public class BackwardLimit : MonoBehaviour
{
    float posYChicken;
    Move moveScript;
    AudioSource audioSource;
    public AudioClip death;
    public GameObject gameOverUI;
    // Start is called before the first frame update
    void Start()
    {
        posYChicken = transform.position.y;
        moveScript = GetComponent<Move>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > posYChicken)
        {
            posYChicken = transform.position.y;
        }
        if (posYChicken - transform.position.y >= 6)
        {
            moveScript.gameOver = true;
            Debug.Log(moveScript.gameOver);
            posYChicken = transform.position.y;//khong lap di lap lai am thanh
            audioSource.PlayOneShot(death, 1f);
            gameOverUI.SetActive(true);
        }
    }
}
