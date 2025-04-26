using TMPro;
using UnityEngine;

public class HayHeap : Hay, IService
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private Canvas _canvas;

    public int Score { get; private set; }

    private void Start()
    {
        var camera = Camera.main;
        _canvas.worldCamera = camera;
        _hayStatus = HayStatus.Heap;
    }

    public void SetHeapScore(int score)
    {
        Score = score;
        _scoreText.text = score.ToString();
    }
}
