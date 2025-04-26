using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerMovement
{
    public void Movement(float forwardAxis, float horizontalAxis, float timeDeltaTime, Transform transform, float speed);
}
