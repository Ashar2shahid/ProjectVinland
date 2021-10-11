using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunIdleWalk : PlayerBaseState
{
    // float player.playerSpeed = 0.0f;
    public override void EnterState(ThirdPersonMovement player)
    {
        player.playerAnimator.SetBool("RifleIdleWalk" , true);
        Debug.Log("Gone in rifle idle walk");
    }
    public override void Update(ThirdPersonMovement player)
    {
        // float targetAngle ;
        // float angle ;
        // Vector3 moveDir;
        if( Input.GetMouseButtonDown(2)){
            ExitState(player);
            player.TransitionToState(player.walk);
        }
        if( Input.GetMouseButtonDown(1)){
            if(player.playerSpeed > player.speed  ){
                // player.playerAnimator.SetBool("RifleIdleWalk" , false);
                // player.playerAnimator.SetBool("RifleIdle" , false); 
                player.playerAnimator.SetBool("RifleAimWalk" , true); 
                player.playerSpeed = 0.0f;
                player.TransitionToState(player.gunAim);
            }
            else{
            ExitState(player);
            player.TransitionToState(player.gunAim);    
            }
        }
        
        // float horizontal = Input.GetAxisRaw("Horizontal");
        // float vertical = Input.GetAxisRaw("Vertical");
        // Vector3 direction = new Vector3(horizontal , 0f, vertical).normalized;
        // if( direction.magnitude >= 0.1f ){
        //     targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + player.cam.eulerAngles.y;
        //     angle = Mathf.SmoothDampAngle(player.transform.eulerAngles.y , targetAngle , ref player.smoothVelocity , player.smoothTime);
        //     player.transform.rotation = Quaternion.Euler(0f , angle , 0f);
        //     moveDir = Quaternion.Euler(0f , targetAngle , 0f) * Vector3.forward ;
        //     player.playerAnimator.SetFloat(player.moveXAnimation , horizontal );
        //     player.playerAnimator.SetFloat(player.moveXAnimation , vertical );
        //     player.playerAnimator.SetFloat("playerSpeed",player.playerSpeed/8.0f);
        //     // Debug.Log(player.playerSpeed);
        //     // if(Input.GetKey(KeyCode.LeftShift)){
        //     //     player.controller.Move(moveDir.normalized * player.sprintSpeed * Time.deltaTime);
        //     // }
        //     // else{
        //     //     player.controller.Move(moveDir.normalized * player.speed * Time.deltaTime); 
        //     //     }
        //     if (player.playerSpeed < player.speed){
        //             player.playerSpeed = player.playerSpeed + .1f ;
        //         }
        //     if(Input.GetKey(KeyCode.LeftShift) && player.playerSpeed <= player.sprintSpeed){
        //         player.playerSpeed = player.playerSpeed + .2f ;
        //         if( Input.GetMouseButtonDown(2)){
        //             ExitState(player);
        //             player.TransitionToState(player.gunIdle);
        //         }
        //     }
        //     else if( player.playerSpeed >= (player.speed + 0.2f) ){
        //         player.playerSpeed = player.playerSpeed - .2f ;
        //     }
        //     if(player.playerSpeed > 1.0f){
        //         player.controller.Move(moveDir.normalized * player.playerSpeed * Time.deltaTime); 
        //     }

        // }
        // else{
        //     if( Input.GetMouseButtonDown(1)){
        //     ExitState(player);
        //     player.TransitionToState(player.gunAim);    
        // }
        //     if (player.playerSpeed > 0.0f ){
        //             player.playerSpeed = player.playerSpeed - .2f ;
        //             targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + player.cam.eulerAngles.y;
        //         angle = Mathf.SmoothDampAngle(player.transform.eulerAngles.y , targetAngle , ref player.smoothVelocity , player.smoothTime);
        //         player.transform.rotation = Quaternion.Euler(0f , angle , 0f);
        //         moveDir = Quaternion.Euler(0f , targetAngle , 0f) * Vector3.forward ;
        //         if(player.playerSpeed > 1.5f){
        //             player.controller.Move(moveDir.normalized * player.playerSpeed * Time.deltaTime);
        //         }
        //         player.playerAnimator.SetFloat("playerSpeed",player.playerSpeed/8.0f);
        //             }
        //         else {
        //             player.playerAnimator.SetFloat("playerSpeed",0.0f);
        //             // player.playerAnimator.SetBool("Walking" , false );
        //             player.playerAnimator.SetBool("RifleIdle" , true );
        //             ExitState(player);
        //             Debug.Log("entering in Idle");
        //             player.TransitionToState(player.gunIdle);
        //         }
        //     // ExitState(player);
        //     // player.TransitionToState(player.gunIdle);
        // }
    }
    public override void ExitState(ThirdPersonMovement player)
    {   
        player.playerAnimator.SetBool("RifleIdleWalk" , false);
        player.playerAnimator.SetBool("RifleIdle" , false);  
        Debug.Log(" exiting RifleIdleWalk state");
    }
}
