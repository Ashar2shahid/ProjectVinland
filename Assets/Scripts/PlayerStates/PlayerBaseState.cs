using UnityEngine;

public abstract class PlayerBaseState
{
    public abstract void EnterState(ThirdPersonMovement player);

    public abstract void Update(ThirdPersonMovement player);

    // public abstract void OnCollisionEnter(ThirdPersonMovement player);

    public abstract void ExitState(ThirdPersonMovement player);

        
}
