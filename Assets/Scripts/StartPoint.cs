using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    private MoveController MainPlayer;
    private CameraController Camera;

    // Start is called before the first frame update
    void Start()
    {
        MainPlayer = FindObjectOfType<MoveController>();
        MainPlayer.transform.position = transform.position;

        Camera = FindObjectOfType<CameraController>();
        Camera.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
