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

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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
        if (Input.GetKeyDown(KeyCode.W) && !gameOver)
        {
            posChicken += new Vector3(0, 2, 0);
            playerAudio.PlayOneShot(jump, 1f);
            if (hasObstacleAbove)
            {
                posChicken -= new Vector3(0, 2, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.S) && !gameOver)
        {

            posChicken += new Vector3(0, -2, 0);
            playerAudio.PlayOneShot(jump, 1f);
            if (posChicken.y < minY || hasObstacleBelow)
            {
                posChicken -= new Vector3(0, -2, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.A) && !gameOver)
        {
            posChicken += new Vector3(-2, 0, 0);
            spriteRenderer.flipX = false;
            playerAudio.PlayOneShot(jump, 1f);
            if (posChicken.x < -maxX || hasObstacleLeft)
            {
                posChicken -= new Vector3(-2, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.D) && !gameOver)
        {
            posChicken += new Vector3(2, 0, 0);
            spriteRenderer.flipX = true;
            playerAudio.PlayOneShot(jump, 1f);
            if (posChicken.x > maxX || hasObstacleRight)
            {
                posChicken -= new Vector3(2, 0, 0);
            }
        }
        if (transform.position.y <= (posChicken.y - 0.2) && !gameOver)
        {
            transform.Translate(Vector3.up * speedChicken);
        }
        else if (transform.position.y >= (posChicken.y + 0.2) && !gameOver)
        {
            transform.Translate(Vector3.down * speedChicken);
        }
        else if (transform.position.x <= (posChicken.x - 0.2) && !gameOver)
        {
            transform.Translate(Vector3.right * speedChicken);
        }
        else if (transform.position.x >= (posChicken.x + 0.2) && !gameOver)
        {
            transform.Translate(Vector3.left * speedChicken);
        }

        //Menu game over
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameOver = true;
            gameOverUI.SetActive(true);
        }
        if (gameOverUI.activeInHierarchy)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
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
            gameOver = true;
            gameOverUI.SetActive(true);
            playerAudio.PlayOneShot(fallingWater, 1f);
            transform.position = new Vector3(14, transform.position.y, 0);
            Debug.Log("GameOver");
        }
        else
        {
            gameOver = true;
            gameOverUI.SetActive(true);
            playerAudio.PlayOneShot(crash, 1f);
            Debug.Log("GameOver");
        }
    }

    //Tính điểm
    private void OnTriggerEnter2D(Collider2D collision)
    {
        score += 1;
        scoreText.text = score.ToString();
        BoxCollider2D.Destroy(collision);
    }

    //Du doan chuong ngai vat
    private void PredictObstacles()
    {
        hasObstacleAbove = Physics2D.Raycast(transform.position, Vector3.up, 2, layerMask);
        hasObstacleBelow = Physics2D.Raycast(transform.position, Vector3.down, 2, layerMask);
        hasObstacleLeft = Physics2D.Raycast(transform.position, Vector3.left, 2, layerMask);
        hasObstacleRight = Physics2D.Raycast(transform.position, Vector3.right, 2, layerMask);
    }
}
