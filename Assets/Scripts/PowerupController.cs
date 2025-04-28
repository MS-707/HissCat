using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Health playerHealth;
    
    [Header("Powerup Settings")]
    [SerializeField] private float speedBoostDuration = 5f;
    [SerializeField] private float damageBoostDuration = 10f;
    [SerializeField] private float hissRadiusBoostDuration = 8f;
    [SerializeField] private float shieldDuration = 3f;
    
    [Header("Effect Icons")]
    [SerializeField] private GameObject speedBoostIcon;
    [SerializeField] private GameObject damageBoostIcon;
    [SerializeField] private GameObject hissRadiusIcon;
    [SerializeField] private GameObject shieldIcon;
    
    // Track active powerups
    private Dictionary<PowerupType, Coroutine> activePowerups = new Dictionary<PowerupType, Coroutine>();
    
    // Store original values
    private float originalSpeed;
    private float originalDamage;
    private float originalHissRadius;
    
    void Start()
    {
        // If not assigned, get references
        if (playerController == null)
        {
            playerController = GetComponent<PlayerController>();
        }
        
        if (playerHealth == null)
        {
            playerHealth = GetComponent<Health>();
        }
        
        // Store original values
        originalSpeed = playerController.GetMoveSpeed();
        originalDamage = playerController.GetHissDamage();
        originalHissRadius = playerController.GetHissRadius();
        
        // Initially hide all icons
        if (speedBoostIcon != null) speedBoostIcon.SetActive(false);
        if (damageBoostIcon != null) damageBoostIcon.SetActive(false);
        if (hissRadiusIcon != null) hissRadiusIcon.SetActive(false);
        if (shieldIcon != null) shieldIcon.SetActive(false);
    }
    
    public void ApplyPowerup(PowerupType type, float value)
    {
        // Handle the powerup based on its type
        switch (type)
        {
            case PowerupType.HealthBoost:
                ApplyHealthBoost((int)value);
                break;
                
            case PowerupType.SpeedBoost:
                ApplyTimedEffect(
                    PowerupType.SpeedBoost, 
                    () => playerController.SetMoveSpeed(originalSpeed * value),
                    () => playerController.SetMoveSpeed(originalSpeed),
                    speedBoostDuration,
                    speedBoostIcon
                );
                break;
                
            case PowerupType.DamageBoost:
                ApplyTimedEffect(
                    PowerupType.DamageBoost, 
                    () => playerController.SetHissDamage((int)(originalDamage * value)),
                    () => playerController.SetHissDamage((int)originalDamage),
                    damageBoostDuration,
                    damageBoostIcon
                );
                break;
                
            case PowerupType.HissRadius:
                ApplyTimedEffect(
                    PowerupType.HissRadius, 
                    () => playerController.SetHissRadius(originalHissRadius * value),
                    () => playerController.SetHissRadius(originalHissRadius),
                    hissRadiusBoostDuration,
                    hissRadiusIcon
                );
                break;
                
            case PowerupType.ShieldEffect:
                ApplyTimedEffect(
                    PowerupType.ShieldEffect, 
                    () => playerHealth.SetInvulnerable(true),
                    () => playerHealth.SetInvulnerable(false),
                    shieldDuration,
                    shieldIcon
                );
                break;
        }
        
        // Log the powerup for debugging
        Debug.Log($"Applied {type} powerup with value {value}");
    }
    
    private void ApplyHealthBoost(int amount)
    {
        if (playerHealth != null)
        {
            playerHealth.Heal(amount);
        }
    }
    
    private void ApplyTimedEffect(PowerupType type, System.Action applyEffect, System.Action removeEffect, float duration, GameObject icon)
    {
        // If this powerup is already active, stop the current one
        if (activePowerups.ContainsKey(type) && activePowerups[type] != null)
        {
            StopCoroutine(activePowerups[type]);
        }
        
        // Start the new powerup effect
        activePowerups[type] = StartCoroutine(TimedPowerupRoutine(applyEffect, removeEffect, duration, icon));
    }
    
    private IEnumerator TimedPowerupRoutine(System.Action applyEffect, System.Action removeEffect, float duration, GameObject icon)
    {
        // Apply the effect
        applyEffect?.Invoke();
        
        // Show the icon if available
        if (icon != null)
        {
            icon.SetActive(true);
        }
        
        // Wait for the duration
        yield return new WaitForSeconds(duration);
        
        // Remove the effect
        removeEffect?.Invoke();
        
        // Hide the icon
        if (icon != null)
        {
            icon.SetActive(false);
        }
    }
}