using UnityEngine;

public class LehaSceneEntryPoint : EntryPoint
{
    [SerializeField] HayHeap _heapPrefab;

    private void Awake()
    {
        var hayService = new HayService();
        var heapOnPitchfork = new HeapOnPitchfork();

        //read config file

        var scythe = new Scythe()
        {
            CutRadius = 10,
            CutHaysCount = 2,
            Speed = 1,
            Damage = 1,
        };
        hayService.Add(scythe);
        var rake = new Rake()
        {
            Radius = 10,
            GrabCount = 9,
            Speed = 1
        };
        hayService.Add(rake);
        var pitchforks = new Pitchforks()
        {
            Radius = 5,
            Speed = 10
        };
        hayService.Add(pitchforks);

        ServiceLocator.Instance.Register(hayService);
        ServiceLocator.Instance.Register(_heapPrefab);
        ServiceLocator.Instance.Register(heapOnPitchfork);
    }

    private void OnDestroy()
    {
        ServiceLocator.Instance.Unregister<HayService>();
        ServiceLocator.Instance.Unregister<HayHeap>();
        ServiceLocator.Instance.Unregister<HeapOnPitchfork>();
    }
}
