# Archuniverse

# Archuniverse RPG Combat Engine

Archuniverse is a modular, object-oriented C# RPG framework featuring a real-time combat system, item management, inventory logic, stat progression, and a customizable skill tree architecture. Designed with extensibility and future Unity integration in mind, it provides a scalable foundation for both single-player and networked RPG gameplay.

---

## ✨ Features

- ⚔️ **Real-Time Combat Engine**
  - Speed-based cooldown system
  - Dynamic attack/defense type switching (melee/magic)
  - Resource-dependent combat (mana/stamina drain)
  - Bleeding damage over time system

- 🧍‍♂️ **Living Entity & Character System**
  - Base `LivingEntity` class with regeneration, leveling, stat tracking
  - `Character` class with inventory, equipment, economy, and trading mechanics

- 🎒 **Inventory & Equipment System**
  - Modular item types: Weapon, Armor, Food, Potion, Ware
  - Equip/unequip logic with owner binding
  - Special effects via the `IEffect` system

- 🧠 **Skill Tree Architecture**
  - Unlockable skills with level requirements and prerequisites
  - Melee/Magic ability progression
  - Passive stat upgrades (health, defense, regen, etc.)

- ⏱️ **Tick-Based Game Loop**
  - Central `GameLoop` managing all active `ITickable` entities
  - Real-time logic execution without relying on Unity or game engines

---

## 🔧 Technologies

- Language: **C#**
- Framework: **.NET 8.0**
- Architecture: OOP / Component-based / Extensible
- Execution: Console Application (Unity-compatible backend)

---

## 📁 Project Structure

Archuniverse/
├── Characters/ # LivingEntity, Character, SkillTree
├── Items/ # Item base + Weapon, Armor, Potion, etc.
├── Combat/ # RealtimeCombat, Damage, CombatManager
├── Core/ # Base classes, GameLoop, Result enums
├── Program.cs # Main driver (demo combat loop)


---

## 🚀 Getting Started

1. Clone this repo  
2. Build & run via .NET CLI or Visual Studio:
   ```bash
   dotnet run
3. Observe real-time combat output between two characters with printed vitals & attack logs.
