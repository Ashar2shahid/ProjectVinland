using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GunIdle : PlayerBaseState
{   
    
     public override void EnterState(ThirdPersonMovement player)
    {
        player.playerAnimator.SetBool("RifleIdle" , true);
        Debug.Log("enter GunIdle"); 
        // if(player.playerSpeed > player.speed ){
        //     player.TransitionToState(player.gunAim);
        // }  
    }
    public override void Update(ThirdPersonMovement player)
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if( horizontal != .0f || vertical != .0f){
            player.TransitionToState(player.gunIdleWalk);
        }
        if( Input.GetMouseButtonDown(1)){
            ExitState(player);
            player.TransitionToState(player.gunAim);
        }
        if( Input.GetMouseButtonDown(2)){
            ExitState(player);
            player.TransitionToState(player.idle);
        }
    }
    public override void ExitState(ThirdPersonMovement player)
    {   
        player.playerAnimator.SetBool("RifleIdle" , false);

        Debug.Log(" exiting state gunidle");
    }
}
