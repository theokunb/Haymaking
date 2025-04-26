using UnityEngine;

public class LayoutChanger : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _targetSpriteRenderer;

    private int _orderLayout;

    private void Start()
    {
        _orderLayout = _targetSpriteRenderer.sortingOrder;
    }

    private void OnTriggerEnter(Collider other)
    {
        var spriteRenderers = other.GetComponentsInChildren<SpriteRenderer>();

        if (spriteRenderers == null)
        {
            return;
        }

        foreach (var spriteRenderer in spriteRenderers)
        {
            spriteRenderer.sortingOrder = _orderLayout + 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var spriteRenderers = other.GetComponentsInChildren<SpriteRenderer>();

        if (spriteRenderers == null)
        {
            return;
        }

        foreach (var spriteRenderer in spriteRenderers)
        {
            spriteRenderer.sortingOrder = _orderLayout;
        }
    }
}
