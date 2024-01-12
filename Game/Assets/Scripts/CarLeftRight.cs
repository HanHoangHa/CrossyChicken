using System.Collections;
using UnityEngine;

public class CarLeftRight : MonoBehaviour
{
    private static float speedCar1 =8;
    private static float speedCar2 =6;
    private static float speedCar3 =9;
    private static float speedCar4 =5;
    private Move MoveScript;
    // Start is called before
    // the first frame update
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
            Debug.Log(speedCar1);
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Chicken"))
        {
            speedCar1 *= 0.5f;
            speedCar2 *= 0.5f;
            speedCar3 *= 0.5f;
            speedCar4 *= 0.5f;
            StartCoroutine(ReduceSpeed());
        }
    }
    IEnumerator ReduceSpeed() //dem nguoc thoi gian
    {
        yield return new WaitForSeconds(5); // tam dung thuc thi trong 5 giay
        speedCar1 *= 2f;
        speedCar2 *= 2f;
        speedCar3 *= 2f;
        speedCar4 *= 2f;
    }
}
