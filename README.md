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

## Asset Management

### Scripts

- **organize_sprites.py**: Organizes sprite files into appropriate directories based on naming conventions
- **interpolate_frames.py**: Generates intermediate animation frames to create smoother animations
- **generate_animation_json.py**: Creates JSON configuration files for animations

## Development

### Prerequisites

- Python 3.7+ with Pillow library for image processing scripts
- Xcode for iOS development

### Version Control

This project uses Git for version control. The repository includes backups and context backups to ensure we don't break the game during development.

## License

This project is licensed under the MIT License - see the LICENSE file for details.
