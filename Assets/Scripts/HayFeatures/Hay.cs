using UnityEngine;

public class Hay : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _animator;

    protected HayStatus _hayStatus;
    public HayStatus HayStatus => _hayStatus;


    private void Start()
    {
        _hayStatus = HayStatus.Normal;
        _spriteRenderer.color = new Color(1, 1, 1, 1);
    }

    public void Cut() 
    {
        _hayStatus = HayStatus.Cutted;
        _animator.SetTrigger("Cut");
    }

    public void Grab()
    {
        _hayStatus = HayStatus.Grabbed;
        _spriteRenderer.color = new Color(0, 0, 0, 0);

    }
}