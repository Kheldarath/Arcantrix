using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.EventSystems.ExecuteEvents;

public enum MOVESTATE { Idle, Up, Right, Down, Left};

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput; //what controls are registered

    [SerializeField] private float runSpeed = 5f;

    public static PlayerMovement instance;

    private Rigidbody2D myBody; //so we can affect the player's body for hits and movement
    private BoxCollider2D playerBox; //So we know where the player is
    private SpriteRenderer mySprite; //so we can alter the sprite if required
    private Animator myAnims;  //so we can trigger animations
    

    private Vector2 playerMovement;
    private InputAction move;
    private InputAction interact;

    public bool canMove = true;
    public Arcanatrix playerControls;
    public MOVESTATE playerState;
    public bool itemActivate = false;




    private void Awake()
    {
        playerControls = new Arcanatrix();
        myBody = GetComponent<Rigidbody2D>();
        playerBox = GetComponent<BoxCollider2D>();
        mySprite = GetComponent<SpriteRenderer>();
        playerState = 0;
    }

    void Start()
    {
        myAnims = GetComponent<Animator>();
        instance =this;
        canMove = true;
    }

    void Update()
    {
        
        if (canMove)
        {
            OnEnable();
            Run(); //checks for movement            
            CheckAnim();
        }    
    }

   

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();

        interact = playerControls.Player.Activate;
        interact.Enable();
        interact.performed += Activate; //this calls for a method named "Activate" so doesn't need to implicitly execute "Activate()" as it sends a message rather than executes it
    }

    private void OnDisable()
    {        
        move.Disable();
    }
   

    void OnMove(InputValue value)
    {
        //playerMovement = move.ReadValue<Vector2>();
        //myBody.velocity = playerMovement * runSpeed;
    }

    
    void Run()
    {
        //may need "if(!canMove){}

        playerMovement = move.ReadValue<Vector2>();
        myBody.velocity = playerMovement * runSpeed;
        
    }

    void CheckAnim()
    {
        myAnims.SetFloat("Horizontal", myBody.velocity.x);
        myAnims.SetFloat("Vertical", myBody.velocity.y);
        myAnims.SetFloat("Speed", myBody.velocity.sqrMagnitude); //sets speed to square of vector of movement x+y
    }

    private void Activate(InputAction.CallbackContext activated)
    {
        Debug.Log("We Activated");
        itemActivate = true;
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
