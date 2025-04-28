using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    
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
        // TODO: Implement actual hiss attack with particles and damage
    }
}