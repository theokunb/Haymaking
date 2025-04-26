using UnityEngine;

public class HandItem : MonoBehaviour, IHandItemVisitor
{
    [SerializeField] private GameObject _scythe;
    [SerializeField] private GameObject _rake;
    [SerializeField] private GameObject _pitchforks;

    private Animator _currentAnimator;

    private void Awake()
    {
        ServiceLocator.Instance.Register<IHandItemVisitor>(this);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(_currentAnimator != null)
            {
                _currentAnimator.SetTrigger("Perform");
            }
        }
    }

    public void Visit(Rake rake)
    {
        _scythe.SetActive(false);
        _pitchforks.SetActive(false);
        _rake.SetActive(true);

        _currentAnimator = _rake.GetComponent<Animator>();
    }

    public void Visit(Scythe scythe)
    {
        _scythe.SetActive(true);
        _pitchforks.SetActive(false);
        _rake.SetActive(false);

        _currentAnimator = _scythe.GetComponent<Animator>();
    }

    public void Visit(Pitchforks pitchforks)
    {
        _scythe.SetActive(false);
        _pitchforks.SetActive(true);
        _rake.SetActive(false);

        _currentAnimator = _pitchforks.GetComponent<Animator>();
    }
}

public interface IHandItemVisitor: IService
{
    void Visit(Rake rake);
    void Visit(Scythe scythe);
    void Visit(Pitchforks pitchforks);
}