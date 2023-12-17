using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLeftRight : MonoBehaviour
{
    public float speed = 10;
    private Move MoveScript;

    // Start is called before the first frame update
    void Start()
    {
        MoveScript = GameObject.Find("Chicken").GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("CarRight") && MoveScript.gameOver == false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else if(gameObject.CompareTag("CarLeft") && MoveScript.gameOver == false)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
}
