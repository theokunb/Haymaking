using UnityEngine;
using UnityEngine.UI;

public class DamagableHay : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    [SerializeField] private float _baseHealth;

    private float _currentHealth;

    private void Start()
    {
        _currentHealth = _baseHealth;
    }

    public void TakeDamageFrom(Scythe scythe)
    {
        _currentHealth -= scythe.Damage;
        _healthBar.fillAmount = _currentHealth / _baseHealth;

        Debug.Log($"{gameObject.name} taking damage health: {_currentHealth}");

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;

            if (!TryGetComponent<Hay>(out var hay))
            {
                return;
            }
            hay.Cut();
        }
    }
}