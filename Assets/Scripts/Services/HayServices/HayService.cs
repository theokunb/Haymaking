using System.Collections.Generic;
using UnityEngine;

public class HayService : IService
{
    private Dictionary<int, IHayItem> _allHayItems;

    public IHayItem CurrentHayItem { get; private set; }

    public HayService()
    {
        _allHayItems = new Dictionary<int, IHayItem>();
    }

    public void Add(int index, IHayItem item)
    {
        if(_allHayItems.ContainsKey(index))
        {
            _allHayItems[index] = item;
        }
        else
        {
            _allHayItems.Add(index, item);
        }
    }

    public void SelectItem(int index)
    {
        if (index >= _allHayItems.Count)
        {
            Debug.Log("invalid item index");
            return;
        }

        CurrentHayItem = _allHayItems[index];

        var handItemVisitor = ServiceLocator.Instance.GetService<IHandItemVisitor>();
        if(handItemVisitor != null)
        {
            CurrentHayItem.Accept(handItemVisitor);
        }
    }

    public void SetHayItem (int index, IHayItem item) 
    {
        _allHayItems[index] = item;
        Debug.Log($"{index} заменена");
    }
}
