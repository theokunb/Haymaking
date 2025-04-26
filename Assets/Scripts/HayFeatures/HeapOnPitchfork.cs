using UnityEngine;

public class HeapOnPitchfork : IService
{
    private int AccumulatedHeap;

    public HeapOnPitchfork()
    {
        AccumulatedHeap = 0;
    }

    public void AddHeap(int count)
    {
        AccumulatedHeap += count;
        Debug.Log($"AccumulatedHeap {AccumulatedHeap}");
    }

    public void DropHeap()
    {
        if(AccumulatedHeap == 0)
        {
            return;
        }

        var heapPrefab = ServiceLocator.Instance.GetService<HayHeap>();
        var haymaker = ServiceLocator.Instance.GetService<Haymaker>();

        var heap = Object.Instantiate(heapPrefab, haymaker.transform.position, Quaternion.identity);
        heap.SetHeapScore(AccumulatedHeap);

        AccumulatedHeap = 0;
    }

    public void PassHeap()
    {

    }

    public void SellSay()
    {
        AccumulatedHeap = 0;
        Debug.Log("Всё сено продано");
    }

    public int GetAccumulatedHeap()
    {
        return AccumulatedHeap;
    }
}
