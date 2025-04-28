# HissCat Game Project

A 2D iOS video game featuring a cat protagonist with various animations and actions.

## Project Structure

```
/HissCatGameProject
│
├── assets/
│   ├── sprites/
│   │   ├── idle/
│   │   ├── walk/
│   │   ├── attack/
│   │   ├── hurt/
│   │   └── special/
│   └── animations/
│
├── scripts/
│   ├── organize_sprites.py
│   ├── interpolate_frames.py
│   ├── generate_animation_json.py
│
├── README.md
├── .gitignore
└── LICENSE
```

## Setup

1. Clone this repository
2. Place sprite assets in the appropriate folders under `assets/sprites/`
3. Use the utility scripts to help organize and process assets

## 📌 Project Summary
**Title:** HissCat  
**Concept:**  
A 2D bullet-heaven style iOS game starring a brave tabby cat named HissCat (based on the real cat Gus).  
The cat fights waves of quirky enemies (mice, vacuums, squirrels, birds, spiders, etc.) using sonic hisses, tuna breath blasts, swipes, and growls.

**Tone:**  
Heartfelt, whimsical, cozy gothic (NOT horror).  
Inspired by the forested riverlands of Northern California.  
A love letter to a beloved pet — emotional resonance is critical.

---

## 🎨 Art Style
- Pixel/2D art with clean, slightly stylized retro vibe (think Vampire Survivors x Ghibli warmth).
- Sprites must be polished but lightweight for mobile optimization.
- Particle effects (dust, breeze, sparkles) should feel natural and emotionally supportive.

---

## 🧰 Development Stack
- **Engine:** Unity 2D URP (Universal Render Pipeline)
- **Programming Language:** C#
- **Target Platform:** iOS (iPhone 16 Pro Max and newer)
- **Version Control:** GitHub (SSH configured, private repo)
- **Dev AI:** Claude Code (primary), GPT-4o/4.5 (review/supervision)
- **Local Machine:** MacBook Pro M4 Max (Sonoma OS)

---

## 💻 Hardware Context
- **Development Machine:** MacBook Pro M4 Max
- **Primary Test Device:** iPhone 16 Pro Max
- **IDE:** Visual Studio Code + Xcode (for iOS building and signing)
- **Asset Tools:** Leonardo AI (art generation), Canva (promo design), Sora (video editing)

---

## 📂 Repository Information
- **GitHub Repo:** [MS-707/HissCat](https://github.com/MS-707/HissCat)
- **SSH Access:** Deploy key configured, fingerprint: `SHA256:FZUielKkjBkzqt5XR77oFng17Sli3zXBTfVlyIxZ+BM`
- **Branch Strategy:**
  - `main` = production-ready code
  - `dev` = active development
  - Feature branches for specific systems: `feature/player-controller`, etc.
- **Commit Message Style:** 
  - `feat: add basic player movement`
  - `fix: adjust sprite collision size`
  - `chore: update project settings`

---

## 🎮 Gameplay Loop (MVP Focus)
- Player moves HissCat freely (8-directional movement)
- Waves of enemies spawn and chase player
- Player attacks using abilities (Hiss, Tuna Breath, Swipe, Growl)
- Powerups collected enhance abilities over time
- Endless scaling of enemy difficulty and player power

---

## 🛡️ Core Systems Roadmap
1. Project setup (Unity 2D URP + base folders)
2. Basic Player Controller (movement, placeholder attack)
3. Enemy Spawner (dummy enemies)
4. Collision and Damage Detection
5. Powerup Collection System
6. Scaling Difficulty Manager
7. Basic UI (health, score, timer)
8. Pause, Resume, Restart functions

---

## 🎼 Music and Sound Plan
- Music and SFX to be developed in Phase 2.
- Placeholder sounds optional in MVP.

---

## 🛠️ Best Practices
- Modular, clean C# scripts
- Optimized mobile sprites (powers of 2 sizes)
- Efficient particle systems to avoid GPU bottlenecks
- Use Unity Addressables for dynamic asset loading if project scales up

---

## 🛣️ Future-Proofing (Phase 2 and Beyond)
- Multiplayer (possible sequel version)
- Tilt/swipe controls via iPhone gyroscope
- Leaderboards and player achievements
- Special "Memorial Mode" tribute content

---

## 📜 Developer Note
> This project honors a real cat named Gus.  
> Every movement, sound, and visual should embody warmth, courage, and heart.  
> This game is a living memory, not just a game.

---
# End of Context

This project is licensed under the MIT License - see the LICENSE file for details.
