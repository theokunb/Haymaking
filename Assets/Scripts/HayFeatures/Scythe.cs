using System.Linq;
using UnityEngine;

public class Scythe : IHayItem
{
    public float CutRadius { get; set; }
    public int CutHaysCount { get; set; }

    public void ProcessHays(params Hay[] hays)
    {
        var cutHays = hays.Take(CutHaysCount);

        foreach(var hay in cutHays)
        {
            hay.Cut();
        }
    }

    public int GetPerformHaysCount()
    {
        return CutHaysCount;
    }

    public float GetRadius()
    {
        return CutRadius;
    }

    public HayStatus GetTargetHasyStatus()
    {
        return HayStatus.Normal;
    }
}

public class Rake : IHayItem
{
    public float Radius { get; set; }
    public int GrabCount { get; set; }

    public int GetPerformHaysCount()
    {
        return GrabCount;
    }

    public float GetRadius()
    {
        return Radius;
    }

    public HayStatus GetTargetHasyStatus()
    {
        return HayStatus.Cutted;
    }

    public void ProcessHays(params Hay[] hays)
    {
        var cutHays = hays.Take(GrabCount);

        foreach (var hay in cutHays)
        {
            hay.Grab();
        }

        var firstHay = hays.FirstOrDefault();
        if(firstHay == null)
        {
            return;
        }

        var score = cutHays.Count();
        var heapPrefab = ServiceLocator.Instance.GetService<HayHeap>();
        var heap = Object.Instantiate(heapPrefab, firstHay.transform.position, Quaternion.identity);
        heap.SetHeapScore(score);
    }
}