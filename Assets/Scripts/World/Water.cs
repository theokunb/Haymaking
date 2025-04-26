using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] private float _changeAnimationSpeedDelay;
    [SerializeField] private float _minAnimationSpeed;
    [SerializeField] private float _maxAnimationSpeed;

    private Animator[] _animators;
    private float _elapsedTime;

    private void Start()
    {
        _animators = GetComponentsInChildren<Animator>();
        _elapsedTime = 0;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _changeAnimationSpeedDelay)
        {
            _elapsedTime = 0;
            foreach (var animator in _animators)
            {
                float randomSpeed = Random.Range(_minAnimationSpeed, _maxAnimationSpeed);
                animator.speed = randomSpeed;
            }
        }
    }
}
