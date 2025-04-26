using UnityEngine;

public class LehaSceneEntryPoint : EntryPoint
{
    [SerializeField] HayHeap _heapPrefab;

    private void Awake()
    {
        var hayService = new HayService();

        //read config file

        var scythe = new Scythe()
        {
            CutRadius = 10,
            CutHaysCount = 2,
        };
        hayService.Add(scythe);
        var rake = new Rake()
        {
            Radius = 10,
            GrabCount = 9
        };
        hayService.Add(rake);

        ServiceLocator.Instance.Register(hayService);
        ServiceLocator.Instance.Register(_heapPrefab);
    }

    private void OnDestroy()
    {
        ServiceLocator.Instance.Unregister<HayService>();
        ServiceLocator.Instance.Unregister<HayHeap>();
    }
}
