using System.Linq;
using UnityEngine;

public class Scythe : IHayItem
{
    public float CutRadius { get; set; }
    public int CutHaysCount { get; set; }
    public float Speed { get; set; }
    public float Damage { get; set; }

    public void ProcessHays(params Hay[] hays)
    {
        var cutHays = hays.Take(CutHaysCount);

        foreach(var hay in cutHays)
        {
            if(hay.TryGetComponent(out DamagableHay damagableHay))
            {
                damagableHay.TakeDamageFrom(this);
            }
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

    public float GetSpeed()
    {
        return Speed;
    }

    public void Accept(IHandItemVisitor handItemVisitor)
    {
        handItemVisitor.Visit(this);
    }
}
