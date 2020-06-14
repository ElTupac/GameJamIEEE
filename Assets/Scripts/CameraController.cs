using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject followTarget;
    private Vector3 targetPos;
    private float moveSpeed; //Agregar GetComponent para saber si el jugador corre o camina y cambiar la velocidad de la camara
    private MoveController playerStates;

    private static bool cameraExists;

    // Start is called before the first frame update
    void Start()
    {
        playerStates = followTarget.GetComponent<MoveController>();

        if(!cameraExists)
        {
            cameraExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerStates.playerRan) moveSpeed = 7f;
        else moveSpeed = 2f;

        targetPos = new Vector3(
            Mathf.Clamp(followTarget.transform.position.x, -2f, 7f), 
            Mathf.Clamp(followTarget.transform.position.y, -11f, -4f),
            transform.position.z);
        transform.position = Vector3.Lerp (transform.position, targetPos, moveSpeed * Time.deltaTime);
    }
}
