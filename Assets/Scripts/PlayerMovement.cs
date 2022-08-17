using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum MOVESTATE { Idle, Up, Right, Down, Left};

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput; //what controls are registered

    [SerializeField] private float runSpeed = 5f;

    private Rigidbody2D myBody; //so we can affect the player's body for hits and movement
    private BoxCollider2D playerBox; //So we know where the player is
    private SpriteRenderer mySprite; //so we can alter the sprite if required
    private Animator myAnims;  //so we can trigger animations

    private Vector2 playerMovement;

    public bool canMove = true;
    public MOVESTATE playerState;
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        playerBox = GetComponent<BoxCollider2D>();
        mySprite = GetComponent<SpriteRenderer>();
        playerState = 0;
    }

    void Start()
    {
        myAnims = GetComponent<Animator>();        
    }

    void Update()
    {
        if (canMove)
        {
            Run(); //checks for movement            
            CheckAnim();
        }    
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }

    void Run()
    {
        //may need "if(!canMove){}

        playerMovement = new Vector2(moveInput.x, moveInput.y);
        myBody.velocity = playerMovement * runSpeed;
    }

    void CheckAnim()
    {
        myAnims.SetFloat("Horizontal", myBody.velocity.x);
        myAnims.SetFloat("Vertical", myBody.velocity.y);
        myAnims.SetFloat("Speed", myBody.velocity.sqrMagnitude); //sets speed to square of vector of movement x+y
    }

    void CheckCam()
    {
        if(myBody.velocity.x > 0)
        {
            mySprite.flipX = false;
        }
        else
        {
            mySprite.flipX = true;
        }
    }
}
