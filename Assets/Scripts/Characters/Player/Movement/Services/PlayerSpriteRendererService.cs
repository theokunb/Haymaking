using UnityEngine;

public class PlayerSpriteRendererService : MonoBehaviour, IService
{
    private SpriteRenderer _spriteRenderer;

    public int SortingOrder => _spriteRenderer.sortingOrder;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        ServiceLocator.Instance.Register(this);
    }

    private void OnDestroy()
    {
        ServiceLocator.Instance.Unregister<PlayerSpriteRendererService>();
    }
}
