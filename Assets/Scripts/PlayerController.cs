using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    
    [Header("Attack Settings")]
    [SerializeField] private float hissRadius = 2f;
    [SerializeField] private int hissDamage = 1;
    [SerializeField] private LayerMask enemyLayer;
    
    private Rigidbody2D rb;
    private Vector2 movement;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        // Input handling
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        // Normalize diagonal movement to prevent faster diagonal speed
        if (movement.magnitude > 0.1f)
        {
            movement.Normalize();
        }
        
        // Handle attack input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Hiss();
        }
    }
    
    void FixedUpdate()
    {
        // Movement in FixedUpdate for consistent physics
        rb.velocity = movement * moveSpeed;
    }
    
    void Hiss()
    {
        Debug.Log("HissCat used Hiss attack!");
        
        // Get all enemies in the hiss radius
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, hissRadius, enemyLayer);
        
        // Apply damage to all enemies in radius
        foreach (Collider2D enemy in hitEnemies)
        {
            Health enemyHealth = enemy.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(hissDamage);
            }
        }
        
        // TODO: Add visual and audio effects for hiss
    }
    
    // Draw the hiss radius in the editor for debugging
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, hissRadius);
    }
}