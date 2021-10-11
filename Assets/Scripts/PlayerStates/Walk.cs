using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : PlayerBaseState
{
    float playerSpeed;
    public override void EnterState(ThirdPersonMovement player)
    {
        player.playerAnimator.SetBool("Walking" , true );
        Debug.Log("enter walk");   
    }
    public override void Update(ThirdPersonMovement player)
    {
        if(player.playerSpeed < 0.0f){
            ExitState(player);
            player.TransitionToState(player.idle);
        }
        
        // float horizontal = Input.GetAxisRaw("Horizontal");
        // float vertical = Input.GetAxisRaw("Vertical");
        // Vector3 direction = new Vector3(horizontal , 0f, vertical).normalized;
        // float targetAngle ;
        // float angle;
        // Vector3 moveDir;

        if( Input.GetMouseButtonDown(2)){
            ExitState(player);
            player.TransitionToState(player.gunIdle);
        }
        // //for taking input
        // if( direction.magnitude >= 0.1f ){
        //     targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + player.cam.eulerAngles.y;
        //     angle = Mathf.SmoothDampAngle(player.transform.eulerAngles.y , targetAngle , ref player.smoothVelocity , player.smoothTime);
        //     player.transform.rotation = Quaternion.Euler(0f , angle , 0f);
        //     moveDir = Quaternion.Euler(0f , targetAngle , 0f) * Vector3.forward ;
            
        //     // Debug.Log( "1 " + playerSpeed);
        //     if (playerSpeed < player.speed){
        //             playerSpeed = playerSpeed + .1f ;
        //         }
        //     // Debug.Log( "2 " + playerSpeed);  
        //     if(Input.GetKey(KeyCode.LeftShift) && playerSpeed < player.sprintSpeed ){
        //         playerSpeed = playerSpeed + .2f ;
        //     }
        //     else if ( playerSpeed > (player.speed + 0.2f) ){
        //         playerSpeed = playerSpeed - .2f ;
        //     }
        //     // else if( playerSpeed > player.speed  &&  playerSpeed != player.speed){
        //     //     playerSpeed = playerSpeed - .1f ;
        //     // }
        //     // Debug.Log( "3 " + playerSpeed);
        //     //motion damping when starting
        //     if(playerSpeed > 1.0f){
        //         player.controller.Move(moveDir.normalized * playerSpeed * Time.deltaTime); 
        //     }
        //     // Debug.Log( "4 " + playerSpeed/player.sprintSpeed);
        //     player.playerAnimator.SetFloat("playerSpeed",playerSpeed/player.sprintSpeed);
        // }
        // //input block ends
        // else{
        //     if (playerSpeed > 0.0f ){
        //             playerSpeed = playerSpeed - .2f ;
        //             targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + player.cam.eulerAngles.y;
        //         angle = Mathf.SmoothDampAngle(player.transform.eulerAngles.y , targetAngle , ref player.smoothVelocity , player.smoothTime);
        //         player.transform.rotation = Quaternion.Euler(0f , angle , 0f);
        //         moveDir = Quaternion.Euler(0f , targetAngle , 0f) * Vector3.forward ;
        //         if(playerSpeed > 1.5f){
        //             player.controller.Move(moveDir.normalized * playerSpeed * Time.deltaTime);
        //         }
        //         player.playerAnimator.SetFloat("playerSpeed",playerSpeed/8.0f);
        //             }
        //         else {
        //             player.playerAnimator.SetFloat("playerSpeed",0.0f);
        //             player.playerAnimator.SetBool("Walking" , false );
        //             player.playerAnimator.SetBool("Idle" , true );
        //             ExitState(player);
        //             Debug.Log("entering in Idle");
        //             player.TransitionToState(player.idle);
        //         }
             
        //     }
    }
    public override void ExitState(ThirdPersonMovement player)
    {   
        Debug.Log("exit walk");
        player.playerAnimator.SetBool("Walking" , false ); 
    }
}
