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
    private AudioSource playerAudio;
    private SpriteRenderer spriteRenderer;
    Vector3 posChicken;
    float speedChicken = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        playerAudio = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        posChicken = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && !gameOver)
        {
            posChicken += new Vector3(0, 2, 0);
            playerAudio.PlayOneShot(jump, 1f);
        }
        else if (Input.GetKeyDown(KeyCode.S) && !gameOver)
        {
            posChicken += new Vector3(0, -2, 0);
            playerAudio.PlayOneShot(jump, 1f);
        }
        else if (Input.GetKeyDown(KeyCode.A) && !gameOver)
        {
            posChicken += new Vector3(-2, 0, 0);
            spriteRenderer.flipX = false;
            playerAudio.PlayOneShot(jump, 1f);
        }
        else if (Input.GetKeyDown(KeyCode.D) && !gameOver)
        {
            posChicken += new Vector3(2, 0, 0);
            spriteRenderer.flipX = true;
            playerAudio.PlayOneShot(jump, 1f);
        }
        if (transform.position.y < (posChicken.y - 0.2) && !gameOver)
        {
            transform.Translate(Vector3.up * speedChicken);
        }
        else if (transform.position.y > (posChicken.y + 0.2) && !gameOver)
        {
            transform.Translate(Vector3.down * speedChicken);
        }
        else if (transform.position.x < (posChicken.x - 0.2) && !gameOver)
        {
            transform.Translate(Vector3.right * speedChicken);
        }
        else if (transform.position.x > (posChicken.x + 0.2) && !gameOver)
        {
            transform.Translate(Vector3.left * speedChicken);
        }

        if (transform.position.x < -maxX)
        {
            transform.position = new Vector3(-maxX, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > maxX)
        {
            transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
        }
        else if (transform.position.y < minY)
        {
            transform.position = new Vector3(transform.position.x, minY, transform.position.z);
        }

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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameOver = true;
        gameOverUI.SetActive(true);
        playerAudio.PlayOneShot(crash, 1f);
        Debug.Log("GameOver");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        score += 1;
        scoreText.text = score.ToString();
        BoxCollider2D.Destroy(collision);
    }

}
