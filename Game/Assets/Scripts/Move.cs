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
    private AudioSource playerAudio;
    private SpriteRenderer spriteRenderer;
    float posYChicken;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        playerAudio = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        posYChicken = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        //Di chuyển
        if (Input.GetKeyDown(KeyCode.W) && !gameOver)
        {
            transform.Translate(Vector3.up * 2);
            playerAudio.PlayOneShot(jump, 1f);
        }
        else if (Input.GetKeyDown(KeyCode.S) && !gameOver)
        {
            transform.Translate(Vector3.down * 2);
            playerAudio.PlayOneShot(jump, 1f);
        }
        else if (Input.GetKeyDown(KeyCode.A) && !gameOver)
        {
            transform.Translate(Vector3.left * 2);
            spriteRenderer.flipX = false;
            playerAudio.PlayOneShot(jump, 1f);
        }
        else if (Input.GetKeyDown(KeyCode.D) && !gameOver)
        {
            transform.Translate(Vector3.right * 2);
            spriteRenderer.flipX = true;
            playerAudio.PlayOneShot(jump, 1f);
        }
        //Giới hạn di chuyển X
        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.Clamp(newPosition.x, -maxX, maxX);
        transform.position = newPosition;
        //Giới hạn di chuyển Y
        if (transform.position.y < minY)
        {
            transform.position = new Vector3(transform.position.x, minY, transform.position.z);
        }
        //Giới hạn lùi
        if(transform.position.y > posYChicken)
        {
            posYChicken = transform.position.y;
        }
        if(posYChicken - transform.transform.position.y > 6)
        {
            gameOver = true;
            Debug.Log(gameOver);
            posYChicken = transform.position.y;
            playerAudio.PlayOneShot(death, 1f);
            gameOverUI.SetActive(true);
        }
        Debug.Log(transform.position);
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
        gameOver = true;
        gameOverUI.SetActive(true);
        playerAudio.PlayOneShot(crash, 1f);
        Debug.Log("GameOver");
    }
    //Tính điểm
    private void OnTriggerEnter2D(Collider2D collision)
    {
        score += 1;
        scoreText.text = score.ToString();
        BoxCollider2D.Destroy(collision);
    }

}
