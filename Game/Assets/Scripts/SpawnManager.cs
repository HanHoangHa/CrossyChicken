using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject carPrefabsRight;
    public GameObject carPrefabsLeft;
    private Move MoveScript;
    private Vector3 newPrefabsPos = new Vector3(1, 0, 0);
    public float startDelay = 2f;
    public float spawnInterval = 3f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCar", startDelay, spawnInterval);
        MoveScript = GameObject.Find("Chicken").GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(carPrefabsRight.transform.position);
    }
    void SpawnCar()
    {
        if(MoveScript.gameOver == false)
        {
            Instantiate(carPrefabsRight, carPrefabsRight.transform.position, carPrefabsRight.transform.rotation);
            Instantiate(carPrefabsLeft, carPrefabsLeft.transform.position, carPrefabsLeft.transform.rotation);
            
        }
        
    }
    
}
