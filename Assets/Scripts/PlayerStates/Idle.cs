using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : PlayerBaseState
{
    public override void EnterState(ThirdPersonMovement player)
    {   
        player.playerAnimator.SetBool("Idle" , true);
        Debug.Log("entered idle");   
    }
    public override void Update(ThirdPersonMovement player)
    {
        if(player.playerSpeed > 0.0f){
            ExitState(player);
            player.TransitionToState(player.walk);
        }
        // if( Input.GetButtonDown("Jump")){
        //     player.controller.Move(Vector3.up * 2.0f);
        //     player.TransitionToState(player.jump);
        // }
        if( Input.GetMouseButtonDown(2)){
            ExitState(player);
            player.TransitionToState(player.gunIdle);
        }
    }
    public override void ExitState(ThirdPersonMovement player)
    {   
        player.playerAnimator.SetBool("Idle" , false);   
        Debug.Log("exit idle");   
    }

    
}
