using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{

    public GameObject player;
    public Vector2 min;
    public Vector2 max;
    public float suavizado;
    Vector2 speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref speed.x, suavizado);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref speed.y, suavizado);

        transform.position = new Vector3(Mathf.Clamp(posX,min.x,max.x),Mathf.Clamp(posY,min.y,max.y),transform.position.z);
        
    }
}
