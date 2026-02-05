using System;

public class Health
{
    private readonly int _maxHealth;

    private int _currentHealth;

    public event Action Died;

    public Health(int maxHealth)
    {
        _maxHealth = maxHealth;
        _currentHealth = maxHealth;
    }

    public bool IsAlive => _currentHealth > 0;
    public int CurrentHealth => _currentHealth;

    public void TakeDamage(int damage)
    {
        if (damage <= 0 || IsAlive == false)
            return;

        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            Died?.Invoke();
            return;
        }
    }
}
