using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject player;
    Vector3 cameraPos;
    Vector3 playerPos;

    void Start()
    {
        cameraPos = transform.position;
        playerPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void LateUpdate()
    {
        transform.position = new Vector3(cameraPos.x, cameraPos.y + player.transform.position.y - playerPos.y, cameraPos.z);
    }
}
