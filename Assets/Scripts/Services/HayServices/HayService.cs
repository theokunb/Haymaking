using System.Collections.Generic;
using UnityEngine;

public class HayService : IService
{
    private List<IHayItem> _allHayItems;

    public IHayItem CurrentHayItem { get; private set; }

    public HayService()
    {
        _allHayItems = new List<IHayItem>();
    }

    public void Add(IHayItem item)
    {
        _allHayItems.Add(item);
    }

    public void SelectItem(int index)
    {
        if (index >= _allHayItems.Count)
        {
            Debug.Log("invalid item index");
            return;
        }

        CurrentHayItem = _allHayItems[index];
    }
}
