using UnityEngine;

public class VerticalFlip : MonoBehaviour
{
    private bool facingRight = true;
    private SpriteRenderer mySpriteRenderer;
    private PlayerSpriteRendererService playerSpriteRendererService;

    private void Start()
    {
        playerSpriteRendererService = ServiceLocator.Instance.GetService<PlayerSpriteRendererService>();
        mySpriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetAxisRaw("Vertical") < 0 && !facingRight)
        {
            mySpriteRenderer.flipX = false;
            facingRight = !facingRight;
            mySpriteRenderer.sortingOrder = playerSpriteRendererService.SortingOrder + 1;
        }

        if (Input.GetAxisRaw("Vertical") > 0 && facingRight)
        {
            mySpriteRenderer.flipX = true;
            facingRight = !facingRight;
            mySpriteRenderer.sortingOrder = playerSpriteRendererService.SortingOrder - 1;
        }
    }
}
