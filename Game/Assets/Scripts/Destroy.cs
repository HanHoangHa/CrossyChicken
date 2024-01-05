<<<<<<< HEAD
=======
using System.Collections;
using System.Collections.Generic;
>>>>>>> 825af318d6eb6a7f025294fbf624179326999e4c
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private float posYChicken;
    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD

=======
        
>>>>>>> 825af318d6eb6a7f025294fbf624179326999e4c
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        if (transform.position.x > 22 || transform.position.x < -22)
=======
        if (transform.position.x > 20 || transform.position.x < -20)
>>>>>>> 825af318d6eb6a7f025294fbf624179326999e4c
        {
            Destroy(gameObject);
        }
        posYChicken = GameObject.Find("Chicken").transform.position.y;
<<<<<<< HEAD
        if (posYChicken - transform.position.y > 10)
=======
        if(posYChicken - transform.position.y > 10)
>>>>>>> 825af318d6eb6a7f025294fbf624179326999e4c
        {
            Destroy(gameObject);
        }
    }
}
