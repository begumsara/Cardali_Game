🎮 Unity FPS Game Project

This project is a First Person Shooter (FPS) prototype developed using the Unity game engine.
The player fights against enemies, manages ammo, monitors health, and can win or lose the game.

🚀 Features

🕹️ Player Control: Walking, running, strafing, crouching.

🎯 Shooting System: Automatic weapon, ammo management, reload system.

🤖 Enemy AI:

Patrol system

Suspicion & detection

Shooting at the player

Health & death animation

📜 Game Management:

Main menu (play, exit)

Win/Lose screens

Restart and return to main menu

🎨 Animation System: Smooth character and weapon animations.

🔊 Audio & Effects: Gun sounds, bullet impacts, blood effects.

📂 Project Structure
Assets/
├── Scripts/
│   ├── AnaMenuKontrol.cs      # Main menu control
│   ├── Dusman.cs              # Enemy AI
│   ├── GameManager.cs         # Game manager
│   ├── KarakterKontrol.cs     # Player controller
│   ├── Reloadislem.cs         # Reload animation logic
│   ├── Taramali1.cs           # Weapon system
│   └── BenimKutuphanem/
│       └── Animasyon.cs       # Custom animation library

⚙️ Installation

Clone or download this repository:

git clone https://github.com/username/unity-fps-game.git


Open the project using Unity Hub.

Recommended Unity version: 2021.3 LTS or newer.

Open the AnaMenu scene from the Scenes folder and press play to run the game.

🕹️ Gameplay

WASD → Move

Shift → Run

Ctrl → Crouch

Mouse0 (Left Click) → Shoot

R → Reload

Reach "OyunSonu" trigger → Win the game

🎥 Gameplay Video

👉 You can watch the gameplay demonstration here:


(Replace VIDEO_ID with your YouTube video ID)

🧪 Testing

Open the AnaMenu scene and click the "Play" button in-game.

If the player's health reaches zero → Game Over Screen will show.

If the player reaches the end trigger → Win Screen will appear.

🤝 Contributing

Fork this repository 🍴

Create a new branch:

git checkout -b feature/new-feature


Commit your changes:

git commit -m "Added new feature"


Push to the branch:

git push origin feature/new-feature


Open a Pull Request ✔️
