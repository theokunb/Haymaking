using UnityEngine;

public class LayoutChanger : MonoBehaviour
{
    [SerializeField] private ActionType _actionType;
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
            if(_actionType == ActionType.Adding)
            {
                spriteRenderer.sortingOrder = _orderLayout + 2;
            }
            else
            {
                spriteRenderer.sortingOrder = _orderLayout - 2;
            }
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

public enum ActionType
{
    Adding,
    Substracting
}