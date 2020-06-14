using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    //Stats Generales
    private float moveSpeed;

    //Estados, movimientos, direccion
    public bool playerRan;
    private bool playerMove;
    private Vector2 lastMove;

    private Animator anim;
    private Rigidbody2D rBody;

    private static bool playerExists;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();

        if(!playerExists)
        {
            playerExists = true;
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
        playerMove = false;

        if(Input.GetKeyDown(KeyCode.LeftShift)) playerRan=true;
        if(Input.GetKeyUp(KeyCode.LeftShift)) playerRan=false;
        if(playerRan)moveSpeed=4f;
        else moveSpeed=2f;

        if(Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            rBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rBody.velocity.y);
            playerMove = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }

        if(Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            rBody.velocity = new Vector2(rBody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
            playerMove = true;
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }

        if(Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
        {
            rBody.velocity = new Vector2(0f, rBody.velocity.y);
        }

        if(Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
        {
            rBody.velocity = new Vector2(rBody.velocity.x, 0f);
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMove);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }
}
