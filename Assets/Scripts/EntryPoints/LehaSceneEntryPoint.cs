public class LehaSceneEntryPoint : EntryPoint
{
    private void Awake()
    {
        var hayService = new HayService();

        //read config file

        var scythe = new Scythe()
        {
            CutRadius = 2,
            CutHaysCount = 2,
        };
        hayService.Add(scythe);

        ServiceLocator.Instance.Register(hayService);
    }

    private void OnDestroy()
    {
        ServiceLocator.Instance.Unregister<HayService>();
    }
}
