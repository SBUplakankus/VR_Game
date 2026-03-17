# Weapons System

## Melee
- Hitbox-based damage windows.
- Animation-driven timing hooks.
- No velocity-based melee multiplier in PC path.

## Ranged
- Start with one ranged weapon path.
- Single projectile type for MVP implementation.

## WeaponData Changes
- Keep shared core fields: identity, base stats, VFX/SFX, modifiers, economy.
- Remove VR runtime usage of: `gripPositionOffset`, `gripRotationOffset`, `hapticStrength`, `hapticDuration`.
- PC weapon controllers consume `WeaponData` through non-XR base classes.
