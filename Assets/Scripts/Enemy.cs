using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float maxSpeedVariation = 0.5f;
    
    [Header("Attack Settings")]
    [SerializeField] private int contactDamage = 1;
    
    [Header("Target Settings")]
    [SerializeField] private Transform targetTransform;
    
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    private float actualSpeed;
    private Health targetHealth;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        // Randomly vary the speed to create more natural movement patterns
        actualSpeed = moveSpeed + Random.Range(-maxSpeedVariation, maxSpeedVariation);
        
        // Find player if target not manually set
        if (targetTransform == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                targetTransform = player.transform;
                targetHealth = player.GetComponent<Health>();
            }
        }
    }
    
    void Update()
    {
        if (targetTransform != null)
        {
            // Calculate direction towards player
            Vector2 targetPosition = targetTransform.position;
            Vector2 currentPosition = transform.position;
            movementDirection = (targetPosition - currentPosition).normalized;
        }
    }
    
    void FixedUpdate()
    {
        if (targetTransform != null)
        {
            // Move towards the player
            rb.velocity = movementDirection * actualSpeed;
        }
        else
        {
            // If no target, stop moving
            rb.velocity = Vector2.zero;
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy collided with player!");
            
            // Damage the player on contact
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(contactDamage);
            }
        }
    }
}