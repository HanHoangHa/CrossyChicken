using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] car;
    public GameObject[] grassAndRoad;
    private Move MoveScript;
    private float startDelay = 2f;
    private float spawnInterval = 2f;
    private float previousY;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCar", startDelay, spawnInterval);
        MoveScript = GameObject.Find("Chicken").GetComponent<Move>();
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
        if (MoveScript.gameOver == false && rangeY > 0)
        {
            int randomGrassRoad = Random.Range(0, grassAndRoad.Length);
            Vector3 spawnPosition = new Vector3(0, 8, 0) + new Vector3(0, currentY + 4, 0);
            Instantiate(grassAndRoad[randomGrassRoad], spawnPosition, grassAndRoad[randomGrassRoad].transform.rotation);
            previousY = currentY;
        }
    }
    void SpawnCar()
    {
        if (MoveScript.gameOver == false)
        {
            GameObject[] roadObjects = GameObject.FindGameObjectsWithTag("Road");
            foreach (GameObject roadObject in roadObjects)
            {
                Instantiate(car[0], roadObject.transform.position + new Vector3(Random.Range(11, 15), 0, 0), car[0].transform.rotation);
            }
            GameObject[] roadObjects1 = GameObject.FindGameObjectsWithTag("Road1");
            foreach (GameObject roadObject1 in roadObjects1)
            {
                Instantiate(car[1], roadObject1.transform.position + new Vector3(Random.Range(15, 19), 0, 0), car[1].transform.rotation);
            }
            GameObject[] roadObjects2 = GameObject.FindGameObjectsWithTag("Road2");
            foreach (GameObject roadObject2 in roadObjects2)
            {
                Instantiate(car[2], roadObject2.transform.position + new Vector3(Random.Range(-14, -10), 0, 0), car[2].transform.rotation);
            }
            GameObject[] roadObjects3 = GameObject.FindGameObjectsWithTag("Road3");
            foreach (GameObject roadObject3 in roadObjects3)
            {
                Instantiate(car[3], roadObject3.transform.position + new Vector3(Random.Range(-18, -14), 0, 0), car[3].transform.rotation);
            }
        }
    }
}