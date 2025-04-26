public interface IHayItem
{
    void ProcessHays(params Hay[] hays);
    float GetRadius();
    int GetPerformHaysCount();
    float GetSpeed();
    HayStatus GetTargetHasyStatus();

    public void Accept(IHandItemVisitor handItemVisitor);
}
