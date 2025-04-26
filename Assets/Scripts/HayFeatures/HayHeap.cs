using TMPro;
using UnityEngine;

public class HayHeap : MonoBehaviour, IService
{
    [SerializeField] private TMP_Text _score;
    [SerializeField] private Canvas _canvas;


    private void Start()
    {
        var camera = Camera.main;
        _canvas.worldCamera = camera;
    }

    public void SetHeapScore(int score)
    {
        _score.text = score.ToString();
    }
}
