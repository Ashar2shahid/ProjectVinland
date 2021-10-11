using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam ;
    public float speed = 6f;
    public float sprintSpeed = 12f;
    public float jumpSpeed = 6f;
    public float smoothTime= 0.1f;
    public float smoothVelocity= 0.1f;
    public float playerSpeed;
    public Animator playerAnimator;
    public Canvas rdPerson;
    public Canvas aimCamera;
    //player variables
    private PlayerBaseState currentState;
    [SerializeField]
    public Transform aimTarget;
    public GameObject Gun;
    public readonly Idle idle = new Idle();
    public readonly Walk walk = new Walk();
    public readonly GunIdle gunIdle = new GunIdle();
    public readonly GunIdleWalk gunIdleWalk  = new GunIdleWalk();
    public readonly GunAim gunAim = new GunAim();

    public int moveXAnimation;
    public int moveZAnimation;
    private Token token = new Token();

    public float horizontal;
    public float vertical;
    public Vector3 directionBackup;

    PhotonView view;
    // private Token token;
    // public readonly  = new ;
    // Start is called before the first frame update
    private void Start()
    {   
        
        playerAnimator= GetComponentInChildren<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        moveXAnimation = Animator.StringToHash("MoveX");
        moveZAnimation = Animator.StringToHash("MoveZ");
        
        token.GetAccount();
        token.GetBlockNumber(token.chain,token.network);
        token.GetBalanceOfChain(token.chain,token.network,token.account);

        TransitionToState(idle);
        view = GetComponent<PhotonView>();
    }
    
    private void OnCollisionEnter(Collision other) {
        // currentState.OnCollisionEnter(this);
    }
    public void TransitionToState(PlayerBaseState state){
        currentState = state;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            currentState.Update(this);
            controller.Move(new Vector3(0.0f, -9.8f, 0.0f));
            playerMovement();
            // playerRotationControler();
        }
    }
    void playerMovement(){
        this.playerAnimator.SetFloat("playerSpeed",this.playerSpeed/this.sprintSpeed);                    
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal , 0f, vertical).normalized;
        float targetAngle ;
        float angle;
        Vector3 moveDir;

        //for taking input
        if( direction.magnitude >= 0.1f ){
            directionBackup = direction ;
            targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + this.cam.eulerAngles.y;
            angle = Mathf.SmoothDampAngle(this.transform.eulerAngles.y , targetAngle , ref this.smoothVelocity , this.smoothTime);
            if(this.currentState != gunAim ){
            this.transform.rotation = Quaternion.Euler(0f , angle , 0f);
            }
            else{
                var CharacterRotation = cam.transform.rotation;
                CharacterRotation.x = 0;
                CharacterRotation.z = 0;
                this.transform.rotation = CharacterRotation; 
            }
            moveDir = Quaternion.Euler(0f , targetAngle , 0f) * Vector3.forward ;
            if (playerSpeed < this.speed){
                    playerSpeed = playerSpeed + .1f ;
                }
            if(Input.GetKey(KeyCode.LeftShift) && playerSpeed < this.sprintSpeed && this.currentState != gunAim ){
                playerSpeed = playerSpeed + .15f ;
            }
            else if ( playerSpeed > (this.speed + 0.15f) ){
                playerSpeed = playerSpeed - .15f ;
            }
            //motion damping when starting
            if(playerSpeed > 1.0f){
                this.controller.Move(moveDir.normalized * playerSpeed * Time.deltaTime); 
            }
            this.playerAnimator.SetFloat("playerSpeed",playerSpeed/this.sprintSpeed);
        }
        //input block ends
        else{
            if (playerSpeed > 0.0f ){
                if (playerSpeed > this.speed ){
                    playerSpeed = playerSpeed - .15f ;
                }
                else if(playerSpeed <= this.speed){
                    playerSpeed = playerSpeed - .10f ;
                }   
                // targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + this.cam.eulerAngles.y;
                targetAngle = Mathf.Atan2(directionBackup.x, directionBackup.z) * Mathf.Rad2Deg + this.cam.eulerAngles.y;
                angle = Mathf.SmoothDampAngle(this.transform.eulerAngles.y , targetAngle , ref this.smoothVelocity , this.smoothTime);
                if(this.currentState != gunAim ){
                    this.transform.rotation = Quaternion.Euler(0f , angle , 0f);
                }
                if(this.currentState == gunAim){
                    var CharacterRotation = cam.transform.rotation;
                    CharacterRotation.x = 0;
                    CharacterRotation.z = 0;
                    this.transform.rotation = CharacterRotation; 
                }
                // this.transform.rotation = Quaternion.Euler(0f , angle , 0f);
                moveDir = Quaternion.Euler(0f , targetAngle , 0f) * Vector3.forward ;
                if(playerSpeed > 1.5f){
                    this.controller.Move(moveDir.normalized * playerSpeed * Time.deltaTime);
                }
            } 
        }
    }
}
