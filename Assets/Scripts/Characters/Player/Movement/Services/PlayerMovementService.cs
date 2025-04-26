using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementService : IService, IPlayerMovement
{
    public void Movement(float forwardAxis, float horizontalAxis, float timeDeltaTime, Transform transform, float speed, Animator animator)
    {
        var forward = Input.GetAxisRaw("Vertical");

        transform.position += Vector3.forward * speed * forward * Time.deltaTime;

        var horizontal = Input.GetAxisRaw("Horizontal");

        transform.position += Vector3.right * speed * horizontal * Time.deltaTime;

        //animation
        if (horizontal != 0 || forward != 0)
        {
            animator.SetBool("IsWalk", true);
        }
        else
        {
            animator.SetBool("IsWalk", false);
        }
        if (horizontal != 0 || forward != 0)
            animator.SetBool("IsBack", forward > 0);
    }
}
