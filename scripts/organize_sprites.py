#!/usr/bin/env python3

"""
Organize sprite files into appropriate directories based on naming conventions.
"""

import os
import shutil
import re

# Directories
SPRITE_DIR = '../assets/sprites'
ACTION_DIRS = ['idle', 'walk', 'attack', 'hurt', 'special']

def main():
    # Ensure all required directories exist
    for action in ACTION_DIRS:
        os.makedirs(os.path.join(SPRITE_DIR, action), exist_ok=True)
    
    # Find all sprite files in current directory
    sprite_files = [f for f in os.listdir('.') if os.path.isfile(f) and f.endswith(('.png', '.jpg', '.jpeg'))]
    
    # Move files to appropriate directories
    for file in sprite_files:
        moved = False
        for action in ACTION_DIRS:
            if action in file.lower():
                shutil.move(file, os.path.join(SPRITE_DIR, action, file))
                print(f"Moved {file} to {action} directory")
                moved = True
                break
        
        if not moved:
            print(f"Didn't move {file} - no matching category found")

if __name__ == "__main__":
    main()
