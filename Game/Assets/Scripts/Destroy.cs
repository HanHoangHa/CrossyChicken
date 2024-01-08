<<<<<<< HEAD
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private float posYChicken;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 22 || transform.position.x < -22)
        {
            Destroy(gameObject);
        }
        posYChicken = GameObject.Find("Chicken").transform.position.y;
        if (posYChicken - transform.position.y > 10)
        {
            Destroy(gameObject);
        }
    }
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private float posYChicken;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >20 || transform.position.x <-20)
        {
            Destroy(gameObject);
        }
        posYChicken = GameObject.Find("Chicken").transform.position.y;
        if(posYChicken - transform.position.y > 8)
        {
            Destroy(gameObject);
        }
    }
}
>>>>>>> dfa6395af90c91800df35947daae937bdf6a45c6
