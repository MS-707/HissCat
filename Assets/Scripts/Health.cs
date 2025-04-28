using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] private int maxHealth = 10;
    [SerializeField] private int currentHealth;
    
    [Header("Events")]
    public UnityEvent OnDamage;
    public UnityEvent OnDeath;
    
    void Start()
    {
        // Initialize health at start
        currentHealth = maxHealth;
    }
    
    public void TakeDamage(int amount)
    {
        // Reduce health by the damage amount
        currentHealth -= amount;
        
        // Invoke the damage event
        OnDamage?.Invoke();
        
        // Check if health is depleted
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
        // Invoke the death event
        OnDeath?.Invoke();
        
        // Check if this is the player
        if (gameObject.CompareTag("Player"))
        {
            // Handle player death differently
            Debug.Log("Game Over!");
            // Could add scene reload after delay here
        }
        else
        {
            // Destroy non-player objects
            Destroy(gameObject);
        }
    }
    
    // Public accessor for current health
    public int GetCurrentHealth()
    {
        return currentHealth;
    }
    
    // Public accessor for max health
    public int GetMaxHealth()
    {
        return maxHealth;
    }
}