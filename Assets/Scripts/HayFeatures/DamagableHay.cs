using UnityEngine;

public class DamagableHay : MonoBehaviour
{
    [SerializeField] private float _baseHealth;

    private float _currentHealth;

    private void Start()
    {
        _currentHealth = _baseHealth;
    }

    public void TakeDamageFrom(Scythe scythe)
    {
        _currentHealth -= scythe.Damage;

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