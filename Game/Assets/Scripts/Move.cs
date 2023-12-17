using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
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

        float y = Input.GetAxisRaw("Vertical");
        float x = Input.GetAxisRaw("Horizontal");
        if (y != 0 && !gameOver)
        {
            transform.Translate(Vector3.up * y * speed * Time.deltaTime);
        }
        else if (x != 0 && !gameOver)
        {
            transform.Translate(Vector3.right * x * speed * Time.deltaTime);
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
