using UnityEngine;

public class Move : MonoBehaviour
{
    public float maxX = 10;
    public float minY = -4;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {

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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameOver = true;
        Debug.Log(gameOver);
    }
}
