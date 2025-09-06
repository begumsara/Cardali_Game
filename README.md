# 🎮 Unity FPS Game Project

This project is a **First Person Shooter (FPS)** prototype developed using the Unity game engine.  
The player fights against enemies, manages ammo, monitors health, and can win or lose the game.  

---

## 🚀 Features
- 🕹️ **Player Control**: Walking, running, strafing, crouching.  
- 🎯 **Shooting System**: Automatic weapon, ammo management, reload system.  
- 🤖 **Enemy AI**:  
  - Patrol system  
  - Suspicion & detection  
  - Shooting at the player  
  - Health & death animation  
- 📜 **Game Management**:  
  - Main menu (play, exit)  
  - Win/Lose screens  
  - Restart and return to main menu  
- 🎨 **Animation System**: Smooth character and weapon animations.  
- 🔊 **Audio & Effects**: Gun sounds, bullet impacts, blood effects.  

---

## 📂 Project Structure

```bash
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
