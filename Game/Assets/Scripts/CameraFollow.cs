using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject player;
    Vector3 cameraPos;
    Vector3 playerPos;
    private AudioSource cameraAudio;
    private Move moveScript;
    void Start()
    {
        cameraPos = transform.position;
        playerPos = player.transform.position;
        cameraAudio = GetComponent<AudioSource>();
        moveScript = GameObject.Find("Chicken").GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveScript.gameOver)
        {
            cameraAudio.Stop();
        }
    }
    private void LateUpdate()
    {
        transform.position = new Vector3(cameraPos.x, cameraPos.y + player.transform.position.y - playerPos.y, cameraPos.z);
    }

}
