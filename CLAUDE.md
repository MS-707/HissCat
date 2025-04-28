# HissCat Game Project - Claude Context & Development Guidelines

## Project Overview
This file contains critical context for Claude AI to maintain full understanding of the HissCat game project across sessions. It includes development decisions, code organization patterns, and current state tracking.

## Repository Structure
- **Main Repo**: https://github.com/MS-707/HissCat
- **Branch Strategy**: 
  - `main` = production-ready code
  - `dev` = active development (current working branch)
  - Feature branches as needed

## Core Systems Status

### Player (Status: Implemented)
- `PlayerController.cs`: 8-directional movement, spatial attack (Hiss)
- Getter/setter access methods for attributes to support powerups
- Basic collision handling

### Enemy System (Status: Implemented)
- `Enemy.cs`: Basic enemy AI with player-seeking behavior
- `EnemySpawner.cs`: Spawns enemies around player with scaling difficulty

### Health System (Status: Implemented)
- `Health.cs`: Tracks health, damage taking, invulnerability
- Handles player death vs. enemy death differently
- Includes healing capability for powerups

### Powerup System (Status: Implemented)
- `Powerup.cs`: Base class for all powerups with bobbing animation
- `PowerupController.cs`: Manages applying powerup effects to player
- `PowerupSpawner.cs`: Manages random spawning of powerups
- Current powerup types: Health, Speed

## Code Style & Patterns
- MonoBehaviour components are designed to be modular and focused
- Systems communicate via direct references (set in inspector) or tags
- Powerups use enum-based typing for easy extension
- Coroutines used for timed effects (powerups)
- Values exposed as SerializeField for Unity inspector tuning

## Asset Organization
- Scripts: `/Assets/Scripts/`
- Prefabs: `/Assets/Prefabs/`
- Scenes: `/Assets/Scenes/` (Main scene: MainScene.unity)
- Sprites (planned): `/Assets/Sprites/`

## Next Development Areas
1. **Scaling Difficulty Manager**: Adjust spawn rates and enemy strength over time
2. **Basic UI**: Health display, score, timer
3. **Additional Powerups**: Attack damage, attack range
4. **Visual Feedback**: Damage indicators, powerup effects

## Build & Run Instructions
- Unity Version: 2D URP (Universal Render Pipeline)
- Target Platform: iOS (iPhone 16 Pro Max and newer)
- Dev Platform: MacBook Pro M4 Max

## Command Reference
- **Git commits**: Use conventional commit format
  - Example: `feat: add player controller`
  - Example: `fix: resolve enemy collision bug`
- **Test before commit**: Ensure all systems work before pushing

## Critical Code Dependencies
- Player → Health (for taking damage)
- Player → PowerupController (for powerup effects)
- Enemy → Player (for targeting)
- PowerupSpawner → Player (for positioning powerups)

## Important Unity Configurations
- Rigidbody2D settings: No gravity, constraints on rotation
- Collision2D layers: Player (0), Enemy (7), Powerup (8)
- Camera follows player with smooth transition

---

**Last Updated**: Monday, April 28, 2025