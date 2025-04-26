using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimaSceneEntryPoint : EntryPoint
{
    private void Awake()
    {
        var playerMovementService = new PlayerMovementService();
        var walletService = new WalletService();
        var heapOnPitchfork = new HeapOnPitchfork();
        var sellShopService = new SellShopService(walletService, heapOnPitchfork);
        ServiceLocator.Instance.Register(playerMovementService);
        ServiceLocator.Instance.Register(walletService);
        ServiceLocator.Instance.Register(heapOnPitchfork);
        ServiceLocator.Instance.Register(sellShopService);
    }

    private void OnDestroy()
    {
        ServiceLocator.Instance.Unregister<PlayerMovementService>();
        ServiceLocator.Instance.Unregister<WalletService>();
        ServiceLocator.Instance.Unregister<HeapOnPitchfork>();
        ServiceLocator.Instance.Unregister<SellShopService>();
    }
}
