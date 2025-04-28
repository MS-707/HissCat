#!/usr/bin/env python3

"""
Generate animation JSON configuration files from sprite directories.
"""

import os
import json
import glob

# Directories
SPRITE_DIR = '../assets/sprites'
ANIMATION_DIR = '../assets/animations'
ACTION_DIRS = ['idle', 'walk', 'attack', 'hurt', 'special']

def generate_animation_config(action_dir):
    """Generate animation configuration for a specific action directory."""
    action_name = os.path.basename(action_dir)
    sprites = []
    
    # Get all sprite files and sort them
    files = glob.glob(os.path.join(action_dir, '*.png'))
    files.sort()
    
    if not files:
        print(f"No sprite files found in {action_dir}")
        return None
    
    # Create frame configuration
    for i, file_path in enumerate(files):
        frame = {
            "index": i,
            "filename": os.path.basename(file_path),
            "path": os.path.relpath(file_path, os.path.dirname(ANIMATION_DIR))
        }
        sprites.append(frame)
    
    animation_config = {
        "name": action_name,
        "frames": sprites,
        "loop": action_name in ['idle', 'walk'],  # Idle and walk animations typically loop
        "frameDuration": 0.1  # Default frame duration in seconds
    }
    
    return animation_config

def main():
    # Ensure animation directory exists
    os.makedirs(ANIMATION_DIR, exist_ok=True)
    
    # Create animation configs
    all_animations = []
    for action in ACTION_DIRS:
        action_dir = os.path.join(SPRITE_DIR, action)
        
        if not os.path.isdir(action_dir):
            print(f"Directory not found: {action_dir}")
            continue
        
        animation_config = generate_animation_config(action_dir)
        if animation_config:
            # Write individual animation file
            output_file = os.path.join(ANIMATION_DIR, f"{action}.json")
            with open(output_file, 'w') as f:
                json.dump(animation_config, f, indent=2)
            print(f"Generated {output_file}")
            
            all_animations.append(animation_config)
    
    # Write combined animations file
    all_animations_file = os.path.join(ANIMATION_DIR, "all_animations.json")
    with open(all_animations_file, 'w') as f:
        json.dump(all_animations, f, indent=2)
    print(f"Generated {all_animations_file}")

if __name__ == "__main__":
    main()
