using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimaSceneEntryPoint : EntryPoint
{
    private void Awake()
    {
        var playerMovementService = new PlayerMovementService();
        var hayService = new HayService();
        var walletService = new WalletService();
        var heapOnPitchfork = new HeapOnPitchfork();
        var sellShopService = new SellShopService(walletService, heapOnPitchfork);
        var buyShopService = new BuyShopService();
        ServiceLocator.Instance.Register(playerMovementService);
        ServiceLocator.Instance.Register(walletService);
        ServiceLocator.Instance.Register(heapOnPitchfork);
        ServiceLocator.Instance.Register(sellShopService);
        ServiceLocator.Instance.Register(buyShopService);
        ServiceLocator.Instance.Register(hayService);
    }

    private void OnDestroy()
    {
        ServiceLocator.Instance.Unregister<PlayerMovementService>();
        ServiceLocator.Instance.Unregister<WalletService>();
        ServiceLocator.Instance.Unregister<HeapOnPitchfork>();
        ServiceLocator.Instance.Unregister<SellShopService>();
        ServiceLocator.Instance.Unregister<BuyShopService>();
        ServiceLocator.Instance.Unregister<HayService>();
    }
}
