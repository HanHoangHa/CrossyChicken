using UnityEngine;

public class CarLeftRight : MonoBehaviour
{
    private float speedCar1 = 8;
    private float speedCar2 = 6;
    private float speedCar3 = 9;
    private float speedCar4 = 5;
    private Move MoveScript;
    // Start is called before the first frame update
    void Start()
    {
        MoveScript = GameObject.Find("Chicken").GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveScript.gameOver == false && gameObject.CompareTag("Car1"))
        {
            transform.Translate(Vector3.left * speedCar1 * Time.deltaTime);
        }
        if (MoveScript.gameOver == false && gameObject.CompareTag("Car2"))
        {
            transform.Translate(Vector3.left * speedCar2 * Time.deltaTime);
        }
        if (MoveScript.gameOver == false && gameObject.CompareTag("Car3"))
        {
            transform.Translate(Vector3.left * speedCar3 * Time.deltaTime);
        }
        if (MoveScript.gameOver == false && gameObject.CompareTag("Car4"))
        {
            transform.Translate(Vector3.left * speedCar4 * Time.deltaTime);
        }
    }
}
