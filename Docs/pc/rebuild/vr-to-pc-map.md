# VR to PC Map

## Section 2 — Systems to Rebuild (VR → PC Equivalent)

**`Assets/Scripts/Player/CombatFeedbackController.cs` → `Assets/Scripts/Player/PCDamageFeedbackController.cs`**
- VR version does: holds hit-audio/haptics feedback references for combat feedback.
- PC version needs: drive damage flash + screen/UI feedback and optional hit audio only.
- Complexity: Low
- Estimated time: 2h
- Notes: remove haptic dependency; wire into `GameplayEvents.PlayerDamaged`.

**`Assets/Scripts/Player/PlayerHitAudio.cs` → `Assets/Scripts/Player/PlayerHitAudio.cs` (PC implementation)**
- VR version does: currently empty placeholder component.
- PC version needs: play local damage SFX on player hit/death.
- Complexity: Low
- Estimated time: 1h
- Notes: keep class name if possible to reduce prefab churn.

**`Assets/Scripts/Player/PlayerWeaponHolster.cs` → `Assets/Scripts/Player/PCWeaponLoadoutController.cs`**
- VR version does: XR socket holster management with `XRSocketInteractor` events.
- PC version needs: slot/swap between equipped melee/ranged weapons from keyboard/mouse.
- Complexity: Medium
- Estimated time: 3h
- Notes: no physics holster; keep simple active-slot switching.

**`Assets/Scripts/Systems/Capture Mode/SmoothFollowCamera.cs` → `Assets/Scripts/Player/TopDownCameraController.cs`**
- VR version does: generic transform follow with optional smoothing and offsets.
- PC version needs: fixed top-down follow/aim framing (Cinemachine-compatible).
- Complexity: Medium
- Estimated time: 3h
- Notes: use this script as reference only; maintain deterministic framing for room combat.

**`Assets/Scripts/Characters/Enemies/EnemyMovement.cs` → `Assets/Scripts/Characters/Enemies/EnemySteeringMovement.cs`**
- VR version does: NavMesh chase/attack state handling with target tracking.
- PC version needs: seek + separation + obstacle avoidance steering (no NavMesh).
- Complexity: High
- Estimated time: 8h
- Notes: keep `EnemyController` contract (`OnSpawn/OnDespawn/UpdateAI/IsInAttackRange`) stable.

**`Assets/Scripts/UI/Controllers/PlayerWristAttributesController.cs` → `Assets/Scripts/UI/Controllers/PlayerHUDController.cs`**
- VR version does: shows/hides wrist attribute hosts via wrist-head proximity.
- PC version needs: persistent screen-space player health/shield display.
- Complexity: Medium
- Estimated time: 3h
- Notes: reuse existing `PlayerArenaAttributeHost/View` if layout is adequate.

**`Assets/Scripts/Weapons/XRWeaponBase.cs` → `Assets/Scripts/Weapons/PCWeaponBase.cs`**
- VR version does: XR grab lifecycle, cooldown, hit processing, haptic dispatch.
- PC version needs: input-driven equip/attack lifecycle with same damage/VFX/audio pipeline.
- Complexity: Medium
- Estimated time: 4h
- Notes: preserve `WeaponData` consumption and `GamePoolManager` effect spawning.

**`Assets/Scripts/Weapons/MeleeXRWeapon.cs` → `Assets/Scripts/Weapons/PCMeleeWeapon.cs`**
- VR version does: physics swing velocity drives melee damage multiplier.
- PC version needs: deterministic melee attacks using hitbox windows (no velocity scaling).
- Complexity: Medium
- Estimated time: 4h
- Notes: align with roadmap (hitbox-based, simple timing).

**`Assets/Scripts/Weapons/BowXRWeapon.cs` → `Assets/Scripts/Weapons/PCRangedWeapon.cs`**
- VR version does: hand-draw bow charging and projectile release.
- PC version needs: direct ranged attack trigger using hitbox-based method for MVP.
- Complexity: Medium
- Estimated time: 4h
- Notes: keep one ranged weapon only; avoid draw/charge complexity.

**`Assets/Scripts/Weapons/WeaponHitbox.cs` → `Assets/Scripts/Weapons/PCWeaponHitbox.cs`**
- VR version does: trigger-hit processing against `XRWeaponBase` and velocity multipliers.
- PC version needs: hitbox collision processing for PC weapon base without XR assumptions.
- Complexity: Medium
- Estimated time: 3h
- Notes: reuse directional hit reaction path into `EnemyAnimator`.

---
