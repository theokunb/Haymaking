using System.IO;
using UnityEngine;

public class Hay : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    
    private bool _performed;
    private Sprite _normalHay;
    private Sprite _cuttedHay;

    public bool Performed => _performed;

    private void Start()
    {
        _normalHay = Resources.Load<Sprite>(Path.Combine("Hay"));
        _cuttedHay = Resources.Load<Sprite>(Path.Combine("HayCutted"));

        _performed = false;
        _spriteRenderer.sprite = _normalHay;
    }

    public void Cut()
    {
        _performed = true;
        _spriteRenderer.sprite = _cuttedHay;
    }
}
