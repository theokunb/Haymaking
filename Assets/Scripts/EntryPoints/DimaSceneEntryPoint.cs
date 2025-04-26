using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimaSceneEntryPoint : EntryPoint
{
    private void Awake()
    {
        var playerMovementService = new PlayerMovementService();

        ServiceLocator.Instance.Register(playerMovementService);
    }

    private void OnDestroy()
    {
        ServiceLocator.Instance.Unregister<PlayerMovementService>();
    }
}
