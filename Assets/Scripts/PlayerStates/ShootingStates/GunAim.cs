using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Animations.Rigging;
public class GunAim : PlayerBaseState
{
    private CinemachineVirtualCamera virtualCamera;
    public Canvas cameraCanvas;
    public Transform cameraTransform ; 
    public GunScript gunScript ;
    public override void EnterState(ThirdPersonMovement player)
    {    
        Debug.Log("Enter Gun aim");
        virtualCamera = player.transform.parent.FindChild("AimCinemachine").GetComponent<CinemachineVirtualCamera>();
        Debug.Log(virtualCamera);
        player.aimCamera.enabled = true;
        player.rdPerson.enabled = false;
        virtualCamera.transform.Rotate(Vector3.up , (player.transform.localRotation.y - 360.0f ) ) ;
        virtualCamera.Priority += 10;  
        gunScript = player.GetComponent<GunScript>();
        player.GetComponent<RigBuilder>().enabled = true; 
        player.playerAnimator.SetBool("RifleAim" , true);
        player.playerAnimator.SetBool("RifleAimWalk" , true);
        //
        // player.aimTarget.position = player.transform.position + player.transform.forward*5.0f;
    }
    public override void Update(ThirdPersonMovement player)
    {   
        
        if( Input.GetMouseButtonUp(1)){
            ExitState(player);
            player.TransitionToState(player.gunIdle); 
            
        }
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        //strafe animation
        player.playerAnimator.SetFloat(player.moveXAnimation , horizontal );
        player.playerAnimator.SetFloat(player.moveZAnimation , vertical );
        //shooting
        if( Input.GetMouseButtonDown(0)){
            gunScript.StartFire();
        }
        if( gunScript.isFiring){
            gunScript.UpdateFire(Time.deltaTime);
        }
        gunScript.UpdateBullets(Time.deltaTime);
        if( Input.GetMouseButtonUp(0) ){
            gunScript.StopShoot();
        }
        //rotate
        // if( (Input.GetAxis("Mouse X") != 0) || (Input.GetAxis("Mouse Y") != 0)){
            var CharacterRotation = virtualCamera.transform.rotation;
            CharacterRotation.x = 0;
            CharacterRotation.z = 0;
            player.transform.rotation = CharacterRotation; 
            // player.aimTarget.position = virtualCamera.transform.position + virtualCamera.transform.forward*5.0f;
        // }
    }
    public override void ExitState(ThirdPersonMovement player)
    {   
        Debug.Log(" exiting gun aim");
        player.playerAnimator.SetBool("RifleAim" , false);
        player.playerAnimator.SetBool("RifleAimWalk" , false); 
        virtualCamera.Priority -= 10;
        player.GetComponent<RigBuilder>().enabled = false;
        player.aimCamera.enabled = false;
        player.rdPerson.enabled = true;
    }
}
