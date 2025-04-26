public interface IHayItem
{
    void ProcessHays(params Hay[] hays);
    float GetRadius();
    int GetPerformHaysCount();
    HayStatus GetTargetHasyStatus();
}
