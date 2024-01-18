
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] car;
    public GameObject[] grassAndRoad;
    public GameObject[] items;
    private Move moveScript;
    private float startDelay = 3f;
    private float spawnInterval = 3f;
    private float previousY;
    private int[] posXArray = { 11, 13, 15, 17, 19, 21, -11, -13, -15, -17, -19, -21 };

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCar", startDelay, spawnInterval);
        moveScript = GameObject.Find("Chicken").GetComponent<Move>();
        previousY = GameObject.Find("Chicken").transform.position.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        SpawnRoadOrGrass();
    }

    void SpawnRoadOrGrass()
    {

        float currentY = GameObject.Find("Chicken").transform.position.y;
        float rangeY = currentY - previousY;
        if (Input.GetKeyDown(KeyCode.W) && moveScript.gameOver == false && rangeY > 0)
        {
            previousY += 2;
            int randomGrassRoad = Random.Range(0, grassAndRoad.Length);
            Vector3 spawnPosition = new Vector3(0, 10, 0) + new Vector3(0, previousY, 0);
            Instantiate(grassAndRoad[randomGrassRoad], spawnPosition, grassAndRoad[randomGrassRoad].transform.rotation);
            if (randomGrassRoad == 3 || randomGrassRoad == 4 || randomGrassRoad == 5 || randomGrassRoad == 6)
            {
                int randomValue = Random.Range(1, 11);
                if(randomValue == 5 || randomValue == 25)
                {
                    int itemNumber = Random.Range(0, items.Length);
                    Instantiate(items[itemNumber], spawnPosition, items[itemNumber].transform.rotation);
                }
            }
        }
    }
    void SpawnCar()
    {
        if (moveScript.gameOver == false)
        {
            GameObject[] roadObjects = GameObject.FindGameObjectsWithTag("Road");
            foreach (GameObject roadObject in roadObjects)
            {
                Instantiate(car[0], roadObject.transform.position + new Vector3(posXArray[Random.Range(0, 3)], 0, 0), car[0].transform.rotation);
            }
            GameObject[] roadObjects1 = GameObject.FindGameObjectsWithTag("Road1");
            foreach (GameObject roadObject1 in roadObjects1)
            {
                Instantiate(car[1], roadObject1.transform.position + new Vector3(posXArray[Random.Range(3, 6)], 0, 0), car[1].transform.rotation);
            }
            GameObject[] roadObjects2 = GameObject.FindGameObjectsWithTag("Road2");
            foreach (GameObject roadObject2 in roadObjects2)
            {
                Instantiate(car[2], roadObject2.transform.position + new Vector3(posXArray[Random.Range(6, 9)], 0, 0), car[2].transform.rotation);
            }
            GameObject[] roadObjects3 = GameObject.FindGameObjectsWithTag("Road3");
            foreach (GameObject roadObject3 in roadObjects3)
            {
                Instantiate(car[3], roadObject3.transform.position + new Vector3(posXArray[Random.Range(9, 12)], 0, 0), car[3].transform.rotation);
            }
        }
    }
}