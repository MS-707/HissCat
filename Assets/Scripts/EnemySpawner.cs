using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float minSpawnRate = 2f;
    [SerializeField] private float maxSpawnRate = 5f;
    [SerializeField] private int maxEnemiesAlive = 30;
    
    [Header("Spawn Area")]
    [SerializeField] private float minSpawnDistance = 10f;
    [SerializeField] private float maxSpawnDistance = 15f;
    
    [Header("Difficulty Scaling")]
    [SerializeField] private float difficultyScaleRate = 0.05f;
    [SerializeField] private float minTimeBetweenSpawns = 0.5f; // Fastest possible spawn rate
    
    // Runtime variables
    private Transform playerTransform;
    private float nextSpawnTime;
    private float gameDuration = 0f;
    private List<GameObject> activeEnemies = new List<GameObject>();
    
    void Start()
    {
        // Find player
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        
        // Set initial spawn time
        SetNextSpawnTime();
    }
    
    void Update()
    {
        // Track game duration for difficulty scaling
        gameDuration += Time.deltaTime;
        
        // Only spawn if player exists
        if (playerTransform == null)
        {
            return;
        }
        
        // Clean up destroyed enemies from our list
        CleanupDestroyedEnemies();
        
        // Spawn enemy when it's time and we're under the enemy limit
        if (Time.time >= nextSpawnTime && activeEnemies.Count < maxEnemiesAlive)
        {
            SpawnEnemy();
            SetNextSpawnTime();
        }
    }
    
    private void SpawnEnemy()
    {
        // Calculate a random spawn position around the player
        Vector2 spawnPosition = GetRandomSpawnPosition();
        
        // Spawn the enemy
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        
        // Track the enemy
        activeEnemies.Add(enemy);
    }
    
    private Vector2 GetRandomSpawnPosition()
    {
        // Get a random direction
        float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
        
        // Get a random distance
        float distance = Random.Range(minSpawnDistance, maxSpawnDistance);
        
        // Calculate the spawn position
        Vector2 playerPosition = playerTransform.position;
        Vector2 spawnPosition = playerPosition + (direction * distance);
        
        return spawnPosition;
    }
    
    private void SetNextSpawnTime()
    {
        // Calculate how much to reduce the spawn rate based on game duration
        float difficultyMultiplier = 1f / (1f + (gameDuration * difficultyScaleRate));
        
        // Calculate a random spawn delay that decreases over time (but not below minimum)
        float currentMinRate = Mathf.Max(minTimeBetweenSpawns, minSpawnRate * difficultyMultiplier);
        float currentMaxRate = Mathf.Max(currentMinRate + 0.1f, maxSpawnRate * difficultyMultiplier);
        
        float delay = Random.Range(currentMinRate, currentMaxRate);
        
        // Set next spawn time
        nextSpawnTime = Time.time + delay;
    }
    
    private void CleanupDestroyedEnemies()
    {
        // Remove null references (destroyed enemies) from our list
        activeEnemies.RemoveAll(enemy => enemy == null);
    }
    
    // For debugging and testing
    void OnDrawGizmosSelected()
    {
        if (playerTransform != null)
        {
            // Draw the min spawn radius
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(playerTransform.position, minSpawnDistance);
            
            // Draw the max spawn radius
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(playerTransform.position, maxSpawnDistance);
        }
    }
}