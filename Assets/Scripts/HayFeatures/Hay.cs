using System;
using System.IO;
using UnityEngine;

public class Hay : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    
    private Sprite _normalHay;
    private Sprite _cuttedHay;

    protected HayStatus _hayStatus;
    public HayStatus HayStatus => _hayStatus;

    private void Start()
    {
        _normalHay = Resources.Load<Sprite>(Path.Combine("Hay"));
        _cuttedHay = Resources.Load<Sprite>(Path.Combine("HayCutted"));

        _hayStatus = HayStatus.Normal;
        _spriteRenderer.sprite = _normalHay;
        _spriteRenderer.color = new Color(1, 1, 1, 1);
    }

    public void Cut()
    {
        _hayStatus = HayStatus.Cutted;
        _spriteRenderer.sprite = _cuttedHay;
    }

    public void Grab()
    {
        _hayStatus = HayStatus.Grabbed;
        _spriteRenderer.color = new Color(0, 0, 0, 0);
    }
}