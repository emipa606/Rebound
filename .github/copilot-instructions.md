# GitHub Copilot Instructions for Rebound (Continued) Mod

## Mod Overview and Purpose

**Rebound (Continued)** is an update to the original mod by AKreedz, introducing enhanced combat mechanics in RimWorld. Its primary aim is to add a dynamic melee-oriented trait enabling bullet rebound mechanics to spice up combat engagements. This mod is designed for players who want to enhance the tactical aspect of battles by incorporating unique skills and mechanics related to melee proficiency.

## Key Features and Systems

- **New Trait: Sword Master**: This rare trait is automatically granted to pawns with a melee skill level of 20 unless disabled via settings. It can also be learned at lower levels if the settings are adjusted.
- **Bullet Rebound Mechanic**: Grants drafted player pawns with melee weapons the chance to rebound projectiles based on their melee skill and manipulation ability. This chance is calculated as `0.5 * (Melee-skill / 10)`.
- **Weapon Durability Mechanic**: Weapons utilized for rebounding tend to wear out. The durability damage probability is calculated as `0.4 / (Melee-skill/5)`. Weapons will be dropped if their durability reaches critical levels (1 durability point) to prevent destruction.
- **Projectile Speed Limit**: Fast-moving projectiles cannot be rebounded. This threshold can be customized via mod settings.
- **Enhanced Customization**: 
  - Settings to enable simple projectile blocking.
  - Options to alter weapon damage probability, base rebound chance, and the level at which the trait is acquired.
  - Compatibility with mods that increase melee skill level caps.
- **Broader Trait Integration**: Any trait can serve as a rebound trait with the addition of a mod extension.
- **Combat Extended Support**: Integrates seamlessly with Combat Extended (CE).
- **Localization**: Includes Traditional Chinese translation.

## Coding Patterns and Conventions

- **Naming Conventions**: Classes and methods utilize PascalCase, presented alongside well-defined, descriptive names.
- **Static Classes**: Frequently used for utility or helper functions, as seen in `BulletCE_Impact`, `CERebound`, and `Projectile_ImpactSomething`.
- **Modular Design**: Code is structured into specific classes dedicated to distinct functionalities, such as `Settings`, `PIMod`, and `StartUp`.

## XML Integration

- **DefModExtension**: Uses `ProjectileInversion_ModExtension` to augment existing definitions (Defs) with additional functionalities specific to projectile inversion mechanics.
- **XML Data**: Supports dynamic integration with XML, allowing traits and skills to be tailored or supplemented via XML configurations.

## Harmony Patching

Harmony is employed to patch original RimWorld methods to either enhance or replace default behaviors, such as in altering the projectile combat mechanics or integrating new skill levels for traits.

## Suggestions for Copilot

- **Optimize Algorithm Calculations**: Ensure calculations, especially for rebound chance and weapon durability, are not overly complex or redundant.
- **Code Refactoring**: Encourage creating methods for repeated logic in order to keep codebase DRY.
- **Error Handling**: Implement comprehensive exception handling, especially for settings adjustments and Harmony patches, to prevent game-breaking bugs.
- **Ensure Compatibility**: Provide suggestions on how to check compatibility with other popular mods and potential clashing gameplay mechanics.
- **Customization Options**: Generate configurable settings allowing users to modify the mod behavior according to their gameplay preferences.

This set of guidelines should help optimize Copilot-assisted code suggestions for the ongoing development and maintenance of the Rebound (Continued) mod.
