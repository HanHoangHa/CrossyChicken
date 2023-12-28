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
        if (MoveScript.gameOver == false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        
    }
}
