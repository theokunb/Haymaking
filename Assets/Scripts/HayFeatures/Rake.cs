using System.Linq;
using UnityEngine;

public class Rake : IHayItem
{
    public float Radius { get; set; }
    public int GrabCount { get; set; }
    public float Speed { get; set; }

    public void Accept(IHandItemVisitor handItemVisitor)
    {
        handItemVisitor.Visit(this);
    }

    public int GetPerformHaysCount()
    {
        return GrabCount;
    }

    public float GetRadius()
    {
        return Radius;
    }

    public float GetSpeed()
    {
        return Speed;
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