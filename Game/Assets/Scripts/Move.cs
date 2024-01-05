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
<<<<<<< HEAD
    Vector3 posChicken;
    float speedChicken = 0.2f;
=======
    float posYChicken;
>>>>>>> 825af318d6eb6a7f025294fbf624179326999e4c

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        playerAudio = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
<<<<<<< HEAD
        posChicken = transform.position;
=======
        posYChicken = transform.position.y;
>>>>>>> 825af318d6eb6a7f025294fbf624179326999e4c
    }

    // Update is called once per frame
    void Update()
    {
        //Di chuyển
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
<<<<<<< HEAD
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
=======
        //Giới hạn di chuyển X
        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.Clamp(newPosition.x, -maxX, maxX);
        transform.position = newPosition;
        //Giới hạn di chuyển Y
        if (transform.position.y < minY)
>>>>>>> 825af318d6eb6a7f025294fbf624179326999e4c
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
