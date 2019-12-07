using UnityEngine;

public class Health : MonoBehaviour
{
    public int MaxHealth = 100;
    public bool isDead = false;
    public int CurrentHealth { get; private set; }

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(int amount)
    {
        CurrentHealth -= amount;
        Debug.Log($"[Health] {gameObject.ToString()} taken damage, current health = {CurrentHealth.ToString()}");
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            isDead = true;
            Debug.Log($"[Health] {gameObject.ToString()} is DEAD");
        }
    }
}
