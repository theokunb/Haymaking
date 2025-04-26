using System.Linq;

public interface IHayItem
{
    void Cut(params Hay[] hays);
    float GetRadius();
    int GetCutHaysCount();
}

public class Scythe : IHayItem
{
    public float CutRadius { get; set; }
    public int CutHaysCount { get; set; }

    public void Cut(params Hay[] hays)
    {
        for(int i = 0;i < CutHaysCount;i++)
        {
            if(hays.Length < i)
            {
                return;
            }

            hays[i].Cut();
        }
    }

    public int GetCutHaysCount()
    {
        return CutHaysCount;
    }

    public float GetRadius()
    {
        return CutRadius;
    }
}