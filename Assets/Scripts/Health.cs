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
    public UnityEvent OnHeal;
    
    // Invulnerability flag (for shield powerup)
    private bool isInvulnerable = false;
    
    void Start()
    {
        // Initialize health at start
        currentHealth = maxHealth;
    }
    
    public void TakeDamage(int amount)
    {
        // Skip damage if invulnerable
        if (isInvulnerable)
            return;
            
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
    
    public void Heal(int amount)
    {
        // Calculate new health value
        int newHealth = currentHealth + amount;
        
        // Cap at max health
        currentHealth = Mathf.Min(newHealth, maxHealth);
        
        // Invoke the heal event
        OnHeal?.Invoke();
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
    
    // Set invulnerability (used by shield powerup)
    public void SetInvulnerable(bool invulnerable)
    {
        isInvulnerable = invulnerable;
    }
    
    // Get invulnerability status
    public bool IsInvulnerable()
    {
        return isInvulnerable;
    }
}