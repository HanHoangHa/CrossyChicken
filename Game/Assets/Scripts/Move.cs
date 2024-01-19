
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    private float maxX = 8;
    private float minY = -4;
    public bool gameOver = false;
    public GameObject gameOverUI;
    private int score = 0;
    public Text scoreText;
    public Text endScoreText;
    public Text endScoreTitle;
    public AudioClip jump;
    public AudioClip crash;
    public AudioClip death;
    public AudioClip fallingWater;
    private AudioSource playerAudio;
    private SpriteRenderer spriteRenderer;
    Vector3 posChicken;
    float speedChicken = 0.25f;
    LayerMask layerMask;
    bool hasObstacleAbove = false;
    bool hasObstacleBelow = false;
    bool hasObstacleLeft = false;
    bool hasObstacleRight = false;
    public static bool Paused = false;
    public GameObject PauseMenuCanvas;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        scoreText.text = score.ToString();
        playerAudio = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        posChicken = transform.position;
        layerMask = LayerMask.GetMask("Stand");
    }

    // Update is called once per frame
    void Update()
    {
        PredictObstacles();
        //Di chuyển
        if (!gameOver)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                posChicken += new Vector3(0, 2, 0);
                playerAudio.PlayOneShot(jump, 1f);
                if (hasObstacleAbove)
                {
                    posChicken -= new Vector3(0, 2, 0);
                }
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {

                posChicken += new Vector3(0, -2, 0);
                playerAudio.PlayOneShot(jump, 1f);
                if (posChicken.y < minY || hasObstacleBelow)
                {
                    posChicken -= new Vector3(0, -2, 0);
                }
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                posChicken += new Vector3(-2, 0, 0);
                spriteRenderer.flipX = false;
                playerAudio.PlayOneShot(jump, 1f);
                if (posChicken.x < -maxX || hasObstacleLeft)
                {
                    posChicken -= new Vector3(-2, 0, 0);
                }
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                posChicken += new Vector3(2, 0, 0);
                spriteRenderer.flipX = true;
                playerAudio.PlayOneShot(jump, 1f);
                if (posChicken.x > maxX || hasObstacleRight)
                {
                    posChicken -= new Vector3(2, 0, 0);
                }
            }
            if (transform.position.y <= (posChicken.y - 0.2))
            {
                transform.Translate(Vector3.up * speedChicken);
            }
            else if (transform.position.y >= (posChicken.y + 0.2))
            {
                transform.Translate(Vector3.down * speedChicken);
            }
            else if (transform.position.x <= (posChicken.x - 0.2))
            {
                transform.Translate(Vector3.right * speedChicken);
            }
            else if (transform.position.x >= (posChicken.x + 0.2))
            {
                transform.Translate(Vector3.left * speedChicken);
            }
        }

        //Menu game over
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameOver == false)
            {
                gameOverUI.SetActive(true);
                gameOver = true;
                PauseMenuCanvas.SetActive(false);

            }
            else
            {
                Application.Quit();
            }

        }
        if ((gameOverUI.activeInHierarchy) || (PauseMenuCanvas.activeInHierarchy))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else if (Input.GetKeyUp(KeyCode.P))
        {
            if (Paused)
            {
                Play();
            }
            else
            {
                Stop();
            }

        }

        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }



    }

    //Kiểm tra va chạm
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("River"))
        {
            gameOverUI.SetActive(true);
            gameOver = true;
            endScoreText.text = scoreText.text;
            scoreText.text = "";
            endScoreTitle.text = "";
            playerAudio.PlayOneShot(fallingWater, 1f);
            transform.position = new Vector3(14, transform.position.y, 0);
            Debug.Log("GameOver");
        }
        else
        {
            gameOverUI.SetActive(true);
            gameOver = true;
            endScoreText.text = scoreText.text;
            scoreText.text = "";
            endScoreTitle.text = "";
            playerAudio.PlayOneShot(crash, 1f);
            Debug.Log("GameOver");
        }
    }

    //Tính điểm
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ItemDelete"))
        {
            DeleteCarsByTag("Car1");
            DeleteCarsByTag("Car2");
            DeleteCarsByTag("Car3");
            DeleteCarsByTag("Car4");
            Destroy(collision.gameObject);
        }
        else if (!collision.gameObject.CompareTag("ItemDelete") && !collision.gameObject.CompareTag("ItemSlow"))
        {
            score += 1;
            scoreText.text = score.ToString();
            BoxCollider2D.Destroy(collision);
        }

    }

    //Du doan chuong ngai vat
    private void PredictObstacles()
    {
        hasObstacleAbove = Physics2D.Raycast(transform.position, Vector3.up, 2, layerMask);
        hasObstacleBelow = Physics2D.Raycast(transform.position, Vector3.down, 2, layerMask);
        hasObstacleLeft = Physics2D.Raycast(transform.position, Vector3.left, 2, layerMask);
        hasObstacleRight = Physics2D.Raycast(transform.position, Vector3.right, 2, layerMask);
    }

    //Delete car khi an item DeleteCar
    void DeleteCarsByTag(string tag)
    {
        GameObject[] carsToDelete = GameObject.FindGameObjectsWithTag(tag);

        foreach (GameObject cars in carsToDelete)
        {
            Destroy(cars);
        }
    }
    void Stop()
    {
        PauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
        AudioListener.pause = true; // Tắt âm thanh
    }

    public void Play()
    {
        PauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
        AudioListener.pause = false; // Bật âm thanh
    }
}
