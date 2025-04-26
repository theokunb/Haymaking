using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementService : IService, IPlayerMovement
{
    public void Movement(float forwardAxis, float horizontalAxis, float timeDeltaTime, Transform transform, float speed)
    {
        var forward = Input.GetAxisRaw("Vertical");

        transform.position += Vector3.forward * speed * forward * Time.deltaTime;

        var horizontal = Input.GetAxisRaw("Horizontal");

        transform.position += Vector3.right * speed * horizontal * Time.deltaTime;
    }
}
