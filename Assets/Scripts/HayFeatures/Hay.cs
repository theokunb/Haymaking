using System.Collections;
using UnityEngine;

public class Hay : MonoBehaviour
{
    [SerializeField] private float _minRespawnTime;
    [SerializeField] private float _maxRespawnTime;
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

        StartCoroutine(RespawnTask());
    }

    private IEnumerator RespawnTask()
    {
        var spawnTine = Random.Range(_minRespawnTime, _maxRespawnTime);
        var elapsedTime = 0f;

        while (elapsedTime < spawnTine)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _hayStatus = HayStatus.Normal;
        _spriteRenderer.color = new Color(1, 1, 1, 1);
        _animator.SetTrigger("Rost");
    }
}