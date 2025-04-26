using System;
using System.Collections.Generic;
using System.Linq;

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

    public void SelectCurrent()
    {
        CurrentHayItem = _allHayItems.FirstOrDefault();
    }
}
