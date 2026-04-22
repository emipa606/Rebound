# GitHub Copilot Instructions for Rebound (Continued) Mod

## Mod Overview and Purpose
The **Rebound (Continued)** mod revamps and enhances the original mod by AKreedz, introducing new dynamics and improvements in melee combat for RimWorld. The core feature of this mod is enabling pawns to rebound hostile projectiles using melee weapons, providing a tactical advantage in combat.

## Key Features and Systems
- **Sword Master Trait**: 
  - A new trait automatically gained when a pawn reaches a melee skill of 20, although this auto-assignment can be disabled in settings. The trait can also have a random low chance of appearing naturally.
  - Any trait can become a rebound-focused trait through mod extensions.

- **Projectile Rebounding**:
  - Bullets can be rebounded if the pawn is drafted and holding a melee weapon.
  - Rebound chance formula: `0.5 * (Melee-skill / 10)`.
  - Configurable speed limit for projectiles to be eligible for rebounding.
  - A new setting allows projectiles to be blocked instead of rebounded.
  - A new setting can disable rebound while the pawn is actively engaged in melee combat.

- **Weapon Durability System**:
  - When rebounding, melee weapons incur durability damage calculated as: `0.4 / (Melee-skill / 5)`.
  - Weapons drop when durability reaches 1 to prevent destruction.
  - Adjustable settings for weapon damage and base rebound chance.

- **Settings and Mod Compatibility**:
  - Supports Combat Extended (CE) mod.
  - Integration features include support for custom trait extensions and adaptable skill level conditions.
  - Allows for localization with Traditional Chinese translation.

## Coding Patterns and Conventions
- **Class Organization**: Files like `API.cs` and `Settings.cs` are used for configuration and API interactions, promoting modularity.
- **Static Classes**: Utilized for functionality that doesn't need instance states, e.g., `CERebound` and `Projectile_ImpactSomething`.
- **Mod Extensions**: The use of `DefModExtension` in `ProjectileInversion_ModExtension.cs` expands def capabilities, which eases integration with XML-based mod settings.

## XML Integration
- **DefModExtension**: Extend trait properties via XML to allow more dynamic and modular gameplay trait specifications, enabling custom rebound traits.
- **Settings Management**: XML files are utilized to configure default behaviors and option toggles, making it user-friendly to adjust mechanics from the settings menu.

## Harmony Patching
- **Harmony Library**: Used for method patching to safely alter game behavior without directly modifying original game code.
- **Consistent Patches**: Organized in related class files ensuring separation of concern, e.g., `SkillRecord_Learn` and `Projectile_ImpactSomething`.

## Suggestions for Copilot
1. **Code Completion and Helper Functions**: Utilize Copilot to suggest boilerplate code or helper functions, such as for calculating projectile speeds or handling weapon durability.
2. **Error Checking and Validation**: Automatically generate validation checks for settings, ensuring user-induced errors are minimized.
3. **Refactoring Guidance**: Leverage Copilot to identify redundant or inefficient code segments, suggesting more optimal coding patterns.
4. **XML Templates**: Suggest XML templates for setting up new mod extensions and trait definitions.
5. **Harmony Patch Suggestions**: Recommend potential methods that may require patching and propose starting templates for Harmony patches.

By adhering to these structured guidelines and using the power of Copilot, development and maintenance of the **Rebound (Continued)** mod can be efficiently managed, ensuring a consistent and feature-rich user experience.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.

