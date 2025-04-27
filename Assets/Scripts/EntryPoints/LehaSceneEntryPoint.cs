using UnityEngine;

public class LehaSceneEntryPoint : EntryPoint
{
    [SerializeField] HayHeap _heapPrefab;
    [SerializeField] private SoundService _soundService;

    private void Awake()
    {
        var inventoryConfig = Resources.Load<InventorySettings>("InventoryConfig");

        var hayService = new HayService();
        var heapOnPitchfork = new HeapOnPitchfork();
        var stepService = new StepSoundService(inventoryConfig.Steps);

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

        ServiceLocator.Instance.Register(hayService);
        ServiceLocator.Instance.Register(_heapPrefab);
        ServiceLocator.Instance.Register(heapOnPitchfork);
        ServiceLocator.Instance.Register(_soundService);
        ServiceLocator.Instance.Register(stepService);
    }

    private void OnDestroy()
    {
        ServiceLocator.Instance.Unregister<HayService>();
        ServiceLocator.Instance.Unregister<HayHeap>();
        ServiceLocator.Instance.Unregister<HeapOnPitchfork>();
        ServiceLocator.Instance.Unregister<SoundService>();
        ServiceLocator.Instance.Unregister<StepSoundService>();
    }
}
