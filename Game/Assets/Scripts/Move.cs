using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    public float maxX = 10;
    public float minY = -4;
    public bool gameOver = false;
    public GameObject gameOverUI;
    private int score = 0;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && !gameOver)
        {
            transform.Translate(Vector3.up * 2);
        }
        else if (Input.GetKeyDown(KeyCode.S) && !gameOver)
        {
            transform.Translate(Vector3.down * 2);
        }
        else if (Input.GetKeyDown(KeyCode.A) && !gameOver)
        {
            transform.Translate(Vector3.left * 2);
        }
        else if (Input.GetKeyDown(KeyCode.D) && !gameOver)
        {
            transform.Translate(Vector3.right * 2);
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
       Debug.Log("GameOver");
   }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        score += 1;
        scoreText.text = score.ToString();
        BoxCollider2D.Destroy(collision);
    }

}
