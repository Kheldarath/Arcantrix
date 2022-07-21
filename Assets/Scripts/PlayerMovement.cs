using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput; //what controls are registered

    [SerializeField] private float runSpeed = 5f;

    private Rigidbody2D playerBox; //so we can affect the player's body for hits and movement
    private BoxCollider2D myBody; //So we know where the player is
    private SpriteRenderer mySprite; //so we can alter the sprite if required
    private Animator myAnims;  //so we can trigger animations

    private Vector2 playerMovement;

    public bool canMove = true;

    private void Awake()
    {
        playerBox = GetComponent<Rigidbody2D>();
        myBody = GetComponent<BoxCollider2D>();
        mySprite = GetComponent<SpriteRenderer>();
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
            CheckCam();
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
        playerBox.velocity = playerMovement * runSpeed;
    }

    void CheckCam()
    {
        if(playerBox.velocity.x > 0)
        {
            mySprite.flipX = false;
        }
        else
        {
            mySprite.flipX = true;
        }
    }
}
