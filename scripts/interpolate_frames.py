#!/usr/bin/env python3

"""
Generate intermediate animation frames between keyframes to create smoother animations.
"""

import os
import sys
from PIL import Image
import numpy as np

def create_intermediate_frame(img1, img2, factor):
    """Create an intermediate frame between two images."""
    if img1.size != img2.size:
        img2 = img2.resize(img1.size)
        
    img1_array = np.array(img1).astype(float)
    img2_array = np.array(img2).astype(float)
    
    blend_array = img1_array + factor * (img2_array - img1_array)
    blend_array = np.clip(blend_array, 0, 255).astype(np.uint8)
    
    return Image.fromarray(blend_array)

def interpolate_frames(directory, num_intermediate=1):
    """Create intermediate frames between consecutive images in a directory."""
    # Get all image files
    files = [f for f in os.listdir(directory) if f.endswith(('.png', '.jpg', '.jpeg'))]
    files.sort()
    
    if len(files) < 2:
        print(f"Need at least 2 images in {directory} to interpolate")
        return
    
    # For each consecutive pair of images
    new_files = []
    for i in range(len(files) - 1):
        img1_path = os.path.join(directory, files[i])
        img2_path = os.path.join(directory, files[i + 1])
        
        img1 = Image.open(img1_path)
        img2 = Image.open(img2_path)
        
        # Add first image
        new_files.append(files[i])
        
        # Create intermediate frames
        for j in range(1, num_intermediate + 1):
            factor = j / (num_intermediate + 1)
            new_img = create_intermediate_frame(img1, img2, factor)
            
            # Create new filename
            name_parts = os.path.splitext(files[i])
            new_name = f"{name_parts[0]}_inter{j}{name_parts[1]}"
            new_path = os.path.join(directory, new_name)
            
            new_img.save(new_path)
            new_files.append(new_name)
            print(f"Created {new_name}")
    
    # Add last image
    new_files.append(files[-1])
    
    return new_files

def main():
    if len(sys.argv) < 2:
        print("Usage: interpolate_frames.py <directory> [num_intermediate_frames]")
        return
    
    directory = sys.argv[1]
    num_frames = int(sys.argv[2]) if len(sys.argv) > 2 else 1
    
    interpolate_frames(directory, num_frames)

if __name__ == "__main__":
    main()
