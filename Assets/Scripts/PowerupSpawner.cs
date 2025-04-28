using System.Collections;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    [Header("Powerup Prefabs")]
    [SerializeField] private GameObject[] powerupPrefabs;
    
    [Header("Spawn Settings")]
    [SerializeField] private float initialSpawnDelay = 5f;
    [SerializeField] private float minSpawnInterval = 10f;
    [SerializeField] private float maxSpawnInterval = 20f;
    [SerializeField] private int maxPowerupsOnScreen = 3;
    
    [Header("Spawn Area")]
    [SerializeField] private float minSpawnDistance = 5f;
    [SerializeField] private float maxSpawnDistance = 15f;
    
    private Transform playerTransform;
    private ArrayList activePowerups = new ArrayList();
    
    void Start()
    {
        // Find the player
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        
        // Start spawning powerups
        if (powerupPrefabs.Length > 0)
        {
            StartCoroutine(SpawnPowerupRoutine());
        }
        else
        {
            Debug.LogWarning("No powerup prefabs assigned to PowerupSpawner!");
        }
    }
    
    IEnumerator SpawnPowerupRoutine()
    {
        // Initial delay before first powerup spawns
        yield return new WaitForSeconds(initialSpawnDelay);
        
        while (true)
        {
            // Only spawn if we're under the limit and player exists
            if (activePowerups.Count < maxPowerupsOnScreen && playerTransform != null)
            {
                SpawnRandomPowerup();
            }
            
            // Wait for a random interval before spawning the next powerup
            float waitTime = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(waitTime);
        }
    }
    
    void SpawnRandomPowerup()
    {
        // Clean up destroyed powerups from our tracking list
        CleanupDestroyedPowerups();
        
        // Choose a random powerup prefab
        int prefabIndex = Random.Range(0, powerupPrefabs.Length);
        GameObject powerupPrefab = powerupPrefabs[prefabIndex];
        
        // Get a spawn position around the player
        Vector2 spawnPosition = GetRandomSpawnPosition();
        
        // Spawn the powerup
        GameObject powerup = Instantiate(powerupPrefab, spawnPosition, Quaternion.identity);
        
        // Track the powerup
        activePowerups.Add(powerup);
    }
    
    Vector2 GetRandomSpawnPosition()
    {
        // Get a random direction
        float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
        
        // Get a random distance
        float distance = Random.Range(minSpawnDistance, maxSpawnDistance);
        
        // Calculate the spawn position based on player's position
        Vector2 playerPosition = playerTransform.position;
        Vector2 spawnPosition = playerPosition + (direction * distance);
        
        return spawnPosition;
    }
    
    void CleanupDestroyedPowerups()
    {
        for (int i = activePowerups.Count - 1; i >= 0; i--)
        {
            if (activePowerups[i] == null)
            {
                activePowerups.RemoveAt(i);
            }
        }
    }
    
    // For debugging and testing
    void OnDrawGizmosSelected()
    {
        if (playerTransform != null)
        {
            // Draw the min spawn radius
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(playerTransform.position, minSpawnDistance);
            
            // Draw the max spawn radius
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(playerTransform.position, maxSpawnDistance);
        }
    }
}