using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimaSceneEntryPoint : EntryPoint
{
    [SerializeField] HayHeap _heapPrefab;
    private void Awake()
    {
        var inventoryConfig = Resources.Load<InventorySettings>("InventoryConfig");
        var playerMovementService = new PlayerMovementService();
        var hayService = new HayService();
        var scythe = new Scythe()
        {
            CutRadius = 2f,
            CutHaysCount = 2,
            Speed = 1,
            Damage = 1,
            AudioClip = inventoryConfig.Scythe
        };

        hayService.Add(inventoryConfig.ScytheIndex, scythe);
        var rake = new Rake()
        {
            Radius = 2,
            GrabCount = 9,
            Speed = 1,
            AudioClip = inventoryConfig.Rake
        };

        hayService.Add(inventoryConfig.RakeIndex, rake);
        var pitchforks = new Pitchforks()
        {
            Radius = 2,
            Speed = 10,
            AudioClip = inventoryConfig.Pitchforks
        };

        hayService.Add(inventoryConfig.PitchforksIndex, pitchforks);

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
        ServiceLocator.Instance.Register(_heapPrefab);
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
