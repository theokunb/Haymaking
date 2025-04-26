using System.Linq;
using UnityEngine;

public class Pitchforks : IHayItem
{
    public float Radius { get; set; }
    public float Speed { get; set; }

    public int GetPerformHaysCount()
    {
        return 1;
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
        return HayStatus.Heap;
    }

    public void ProcessHays(params Hay[] hays)
    {
        var first = hays.Select(x => x as HayHeap).FirstOrDefault();

        if(first == null)
        {
            return;
        }

        var heapOnPitchfork = ServiceLocator.Instance.GetService<HeapOnPitchfork>();
        heapOnPitchfork.AddHeap(first.Score);

        Object.Destroy(first.gameObject);
    }
}
