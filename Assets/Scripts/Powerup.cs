using UnityEngine;

public class Powerup : MonoBehaviour
{
    [Header("Powerup Settings")]
    [SerializeField] private PowerupType powerupType = PowerupType.HealthBoost;
    [SerializeField] private float effectValue = 1f;
    [SerializeField] private float lifetime = 10f; // Seconds until auto-despawn
    
    [Header("Visual Settings")]
    [SerializeField] private float bobHeight = 0.5f;
    [SerializeField] private float bobSpeed = 2f;
    [SerializeField] private float rotationSpeed = 45f;
    
    private Vector3 startPosition;
    private float timeAlive = 0f;
    
    void Start()
    {
        startPosition = transform.position;
        
        // Start lifetime countdown
        if (lifetime > 0)
        {
            Invoke("Despawn", lifetime);
        }
    }
    
    void Update()
    {
        timeAlive += Time.deltaTime;
        
        // Simple bobbing motion
        transform.position = startPosition + new Vector3(0, Mathf.Sin(timeAlive * bobSpeed) * bobHeight, 0);
        
        // Simple rotation
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Get the player's powerup controller
            PowerupController powerupController = other.GetComponent<PowerupController>();
            
            if (powerupController != null)
            {
                // Apply the powerup effect
                powerupController.ApplyPowerup(powerupType, effectValue);
                
                // Destroy the powerup object
                Destroy(gameObject);
            }
        }
    }
    
    void Despawn()
    {
        // Optional: Add a fade-out or shrink effect here
        Destroy(gameObject);
    }
}

// Define powerup types - easy to extend
public enum PowerupType
{
    HealthBoost,     // Restore player health
    SpeedBoost,      // Temporarily increase player speed
    DamageBoost,     // Temporarily increase player attack damage
    HissRadius,      // Temporarily increase attack radius
    ShieldEffect     // Temporarily make player invulnerable
}