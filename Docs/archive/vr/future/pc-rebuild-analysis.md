# PC Rebuild Analysis

Scope: current `Assets/Scripts/` audit for a separate top-down PC rebuild while keeping VR code intact.

---

## Section 1 — Shared Systems (No Changes Needed)

| Script | Why it carries over unchanged |
|--------|-------------------------------|
| `Assets/Scripts/Attributes/FloatAttribute.cs` | Generic reactive value containers used by shared data/settings. |
| `Assets/Scripts/Attributes/IntAttribute.cs` | Generic reactive value containers used by shared data/settings. |
| `Assets/Scripts/Audio/ArenaAudioManager.cs` | Audio routing/event integration is platform-agnostic. |
| `Assets/Scripts/Audio/AudioPriorityRouter.cs` | Audio routing/event integration is platform-agnostic. |
| `Assets/Scripts/Audio/DefaultSceneAudio.cs` | Audio routing/event integration is platform-agnostic. |
| `Assets/Scripts/Audio/WorldAudioController.cs` | Audio routing/event integration is platform-agnostic. |
| `Assets/Scripts/Characters/Base/AnimatorComponent.cs` | Base health/animator components are not VR-bound. |
| `Assets/Scripts/Characters/Base/HealthComponent.cs` | Base health/animator components are not VR-bound. |
| `Assets/Scripts/Characters/Enemies/EnemyAnimator.cs` | Enemy animation state driver is reusable with steering movement. |
| `Assets/Scripts/Characters/Enemies/EnemyAttack.cs` | Attack timing/hit logic is reusable after movement replacement. |
| `Assets/Scripts/Characters/Enemies/EnemyController.cs` | Component orchestration and spawn/despawn flow stay valid. |
| `Assets/Scripts/Characters/Enemies/EnemyHealth.cs` | Damage/death/VFX flow is platform-agnostic. |
| `Assets/Scripts/Characters/Enemies/EnemyId.cs` | Identifier component is platform-agnostic. |
| `Assets/Scripts/Constants/AudioKeys.cs` | Shared keys/constants used by all versions. |
| `Assets/Scripts/Constants/GameConstants.cs` | Shared keys/constants used by all versions. |
| `Assets/Scripts/Constants/LocalizationKeys.cs` | Shared keys/constants used by all versions. |
| `Assets/Scripts/Constants/UIToolkitStyles.cs` | Shared keys/constants used by all versions. |
| `Assets/Scripts/Data/Arena/ArenaData.cs` | ScriptableObject data model remains core architecture. |
| `Assets/Scripts/Data/Arena/ArenaWavesData.cs` | ScriptableObject data model remains core architecture. |
| `Assets/Scripts/Data/Arena/WaveData.cs` | ScriptableObject data model remains core architecture. |
| `Assets/Scripts/Data/Core/AudioClipData.cs` | ScriptableObject data model remains core architecture. |
| `Assets/Scripts/Data/Core/EnemyData.cs` | ScriptableObject data model remains core architecture. |
| `Assets/Scripts/Data/Core/ParticleData.cs` | ScriptableObject data model remains core architecture. |
| `Assets/Scripts/Data/Core/WorldAudioData.cs` | ScriptableObject data model remains core architecture. |
| `Assets/Scripts/Data/Progression/MetaProgressionData.cs` | ScriptableObject data model remains core architecture. |
| `Assets/Scripts/Data/Progression/UpgradeData.cs` | ScriptableObject data model remains core architecture. |
| `Assets/Scripts/Data/Registries/GameDatabaseRegistry.cs` | ScriptableObject data model remains core architecture. |
| `Assets/Scripts/Data/Settings/AudioSettingsConfig.cs` | ScriptableObject data model remains core architecture. |
| `Assets/Scripts/Data/Settings/LanguageSettingsConfig.cs` | ScriptableObject data model remains core architecture. |
| `Assets/Scripts/Data/Settings/ObjectPoolConfig.cs` | ScriptableObject data model remains core architecture. |
| `Assets/Scripts/Data/Settings/VideoSettingsConfig.cs` | ScriptableObject data model remains core architecture. |
| `Assets/Scripts/Data/Weapons/ProjectileData.cs` | ScriptableObject data model remains core architecture. |
| `Assets/Scripts/Data/Weapons/WeaponData.cs` | ScriptableObject data model remains core architecture. |
| `Assets/Scripts/Data/Weapons/WeaponModifierData.cs` | ScriptableObject data model remains core architecture. |
| `Assets/Scripts/Data/Weapons/WeaponType.cs` | ScriptableObject data model remains core architecture. |
| `Assets/Scripts/Databases/ArenaDatabase.cs` | Database pattern is shared unchanged. |
| `Assets/Scripts/Databases/AudioClipDatabase.cs` | Database pattern is shared unchanged. |
| `Assets/Scripts/Databases/DatabaseBase.cs` | Database pattern is shared unchanged. |
| `Assets/Scripts/Databases/EnemyDatabase.cs` | Database pattern is shared unchanged. |
| `Assets/Scripts/Databases/GameDatabases.cs` | Database pattern is shared unchanged. |
| `Assets/Scripts/Databases/ParticleDatabase.cs` | Database pattern is shared unchanged. |
| `Assets/Scripts/Databases/UpgradeDatabase.cs` | Database pattern is shared unchanged. |
| `Assets/Scripts/Databases/WeaponDatabase.cs` | Database pattern is shared unchanged. |
| `Assets/Scripts/Databases/WorldAudioDatabase.cs` | Database pattern is shared unchanged. |
| `Assets/Scripts/Events/Channels/EventChannel.cs` | Event channel infrastructure is shared unchanged. |
| `Assets/Scripts/Events/Registries/AudioEvents.cs` | Event channel infrastructure is shared unchanged. |
| `Assets/Scripts/Events/Registries/GameplayEvents.cs` | Event channel infrastructure is shared unchanged. |
| `Assets/Scripts/Events/Registries/SystemEvents.cs` | Event channel infrastructure is shared unchanged. |
| `Assets/Scripts/Events/Registries/UIEvents.cs` | Event channel infrastructure is shared unchanged. |
| `Assets/Scripts/Factories/LocalisationFactory.cs` | UI/localization factory layer remains reusable. |
| `Assets/Scripts/Factories/UIToolkitFactory.cs` | UI/localization factory layer remains reusable. |
| `Assets/Scripts/Interfaces/IDamageable.cs` | Contracts are platform-agnostic. |
| `Assets/Scripts/Interfaces/IHealable.cs` | Contracts are platform-agnostic. |
| `Assets/Scripts/Interfaces/IUpdateable.cs` | Contracts are platform-agnostic. |
| `Assets/Scripts/Player/PlayerArenaController.cs` | Player health/shield damage sink can be reused for top-down combat. |
| `Assets/Scripts/Player/PlayerAttributes.cs` | Gold/XP/level attributes and event hooks carry over. |
| `Assets/Scripts/Pooling/GamePoolManager.cs` | Pooling is shared and required for performance. |
| `Assets/Scripts/Saves/PlayerSaveFileManager.cs` | Save managers are reusable for PC progression/settings. |
| `Assets/Scripts/Saves/SaveFileManagerBase.cs` | Save managers are reusable for PC progression/settings. |
| `Assets/Scripts/Saves/SettingsSaveFileManager.cs` | Save managers are reusable for PC progression/settings. |
| `Assets/Scripts/Systems/Arena/ArenaInterfaceManager.cs` | Arena intro/boss intro/fade event wiring is reusable. |
| `Assets/Scripts/Systems/Arena/ArenaPauseController.cs` | Input-action pause gate remains valid for PC controls. |
| `Assets/Scripts/Systems/Arena/ArenaStateManager.cs` | Arena state machine structure maps to room/floor flow. |
| `Assets/Scripts/Systems/Arena/EnemyManager.cs` | Active enemy tracking/cleanup logic remains valid. |
| `Assets/Scripts/Systems/Arena/WaveManager.cs` | Wave/boss sequencing logic is reusable with room data inputs. |
| `Assets/Scripts/Systems/Arena/WaveSpawner.cs` | Reusable core script with no XR/NavMesh dependency. |
| `Assets/Scripts/Systems/Capture Mode/CaptureModeController.cs` | Optional capture utility; independent from gameplay architecture. |
| `Assets/Scripts/Systems/Core/BoostrapManager.cs` | Bootstrap, registry install, and loading orchestration are reusable. |
| `Assets/Scripts/Systems/Core/GameFlowManager.cs` | Top-level game state machine is reusable with new transitions. |
| `Assets/Scripts/Systems/Core/GameStateMessenger.cs` | State request helper remains valid. |
| `Assets/Scripts/Systems/Core/GameUpdateManager.cs` | Priority update scheduler is shared infrastructure. |
| `Assets/Scripts/Systems/Core/InstantBootstrapManager.cs` | Editor bootstrap helper remains useful for PC iteration. |
| `Assets/Scripts/Systems/Core/VFXPriorityRouter.cs` | VFX routing is platform-agnostic. |
| `Assets/Scripts/Systems/Hub/ArenaPortalController.cs` | Portal entry point exists and can be repurposed for floor transitions. |
| `Assets/Scripts/Systems/Hub/AutoSaveController.cs` | Autosave trigger flow remains valid. |
| `Assets/Scripts/Systems/Settings/AudioController.cs` | Settings controllers/config wiring are reusable for PC. |
| `Assets/Scripts/Systems/Settings/GraphicsController.cs` | Settings controllers/config wiring are reusable for PC. |
| `Assets/Scripts/Systems/Settings/LanguageController.cs` | Settings controllers/config wiring are reusable for PC. |
| `Assets/Scripts/Systems/Stats/ArenaRecord.cs` | Run/stat data classes are reusable for score output. |
| `Assets/Scripts/Systems/Stats/LeaderboardEntry.cs` | Run/stat data classes are reusable for score output. |
| `Assets/Scripts/Tools/StateMachineDebugTool.cs` | Editor/debug helpers remain useful during rebuild. |
| `Assets/Scripts/Tools/WaveDebugTool.cs` | Editor/debug helpers remain useful during rebuild. |
| `Assets/Scripts/UI/Controllers/FadeController.cs` | Generic fade orchestration remains reusable. |
| `Assets/Scripts/UI/Controllers/LoadingScreenController.cs` | Loading screen progression mapping remains reusable. |
| `Assets/Scripts/UI/Controllers/PauseMenuController.cs` | Pause menu controller shell is reusable. |
| `Assets/Scripts/UI/Controllers/StartMenuController.cs` | Start menu flow remains core loop entry point. |
| `Assets/Scripts/UI/Extensions/AudioExtensions.cs` | UI tween helpers are reusable. |
| `Assets/Scripts/UI/Extensions/TweenAlpha.cs` | UI tween helpers are reusable. |
| `Assets/Scripts/UI/Extensions/TweenExtensions.cs` | UI tween helpers are reusable. |
| `Assets/Scripts/UI/Extensions/TweenPosition.cs` | UI tween helpers are reusable. |
| `Assets/Scripts/UI/Extensions/TweenTransform.cs` | UI tween helpers are reusable. |
| `Assets/Scripts/UI/Game/EnemyHealthBar.cs` | Enemy world-health UI remains useful in top-down view. |
| `Assets/Scripts/UI/Hosts/ArenaIntroHost.cs` | UI host pattern is shared architecture (except VignetteHost). |
| `Assets/Scripts/UI/Hosts/AudioSettingsPanelHost.cs` | UI host pattern is shared architecture (except VignetteHost). |
| `Assets/Scripts/UI/Hosts/BasePanelHost.cs` | UI host pattern is shared architecture (except VignetteHost). |
| `Assets/Scripts/UI/Hosts/BossIntroHost.cs` | UI host pattern is shared architecture (except VignetteHost). |
| `Assets/Scripts/UI/Hosts/BoundAttributePanelHost.cs` | UI host pattern is shared architecture (except VignetteHost). |
| `Assets/Scripts/UI/Hosts/LabelHost.cs` | UI host pattern is shared architecture (except VignetteHost). |
| `Assets/Scripts/UI/Hosts/LoadingScreenHost.cs` | UI host pattern is shared architecture (except VignetteHost). |
| `Assets/Scripts/UI/Hosts/LocalizationPanelHost.cs` | UI host pattern is shared architecture (except VignetteHost). |
| `Assets/Scripts/UI/Hosts/PauseMenuHost.cs` | UI host pattern is shared architecture (except VignetteHost). |
| `Assets/Scripts/UI/Hosts/PlayerArenaAttributeHost.cs` | UI host pattern is shared architecture (except VignetteHost). |
| `Assets/Scripts/UI/Hosts/SettingsPanelHost.cs` | UI host pattern is shared architecture (except VignetteHost). |
| `Assets/Scripts/UI/Hosts/StartMenuPanelHost.cs` | UI host pattern is shared architecture (except VignetteHost). |
| `Assets/Scripts/UI/Hosts/VideoSettingsPanelHost.cs` | UI host pattern is shared architecture (except VignetteHost). |
| `Assets/Scripts/UI/Views/ArenaIntroView.cs` | UI view pattern is shared architecture (except VignetteView). |
| `Assets/Scripts/UI/Views/AudioSettingsPanelView.cs` | UI view pattern is shared architecture (except VignetteView). |
| `Assets/Scripts/UI/Views/BasePanelView.cs` | UI view pattern is shared architecture (except VignetteView). |
| `Assets/Scripts/UI/Views/BossIntroView.cs` | UI view pattern is shared architecture (except VignetteView). |
| `Assets/Scripts/UI/Views/BoundAttributePanelView.cs` | UI view pattern is shared architecture (except VignetteView). |
| `Assets/Scripts/UI/Views/LabelView.cs` | UI view pattern is shared architecture (except VignetteView). |
| `Assets/Scripts/UI/Views/LoadingScreenView.cs` | UI view pattern is shared architecture (except VignetteView). |
| `Assets/Scripts/UI/Views/LocalizationPanelView.cs` | UI view pattern is shared architecture (except VignetteView). |
| `Assets/Scripts/UI/Views/PauseMenuView.cs` | UI view pattern is shared architecture (except VignetteView). |
| `Assets/Scripts/UI/Views/PlayerArenaAttributeView.cs` | UI view pattern is shared architecture (except VignetteView). |
| `Assets/Scripts/UI/Views/SettingsPanelView.cs` | UI view pattern is shared architecture (except VignetteView). |
| `Assets/Scripts/UI/Views/StartMenuPanelView.cs` | UI view pattern is shared architecture (except VignetteView). |
| `Assets/Scripts/UI/Views/VideoSettingsPanelView.cs` | UI view pattern is shared architecture (except VignetteView). |
| `Assets/Scripts/Utilities/CountdownTimer.cs` | Generic utility class is reusable. |
| `Assets/Scripts/Visual Effects/ParticleController.cs` | Particle lifecycle controller is platform-agnostic. |

---

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

## Section 3 — Scripts to Delete (VR-Only, No PC Equivalent)

| Script | Reason for deletion |
|--------|---------------------|
| `Assets/Scripts/Player/PlayerHapticFeedback.cs` | Direct XR haptics (`UnityEngine.XR.XRNode`) with no PC top-down use. |
| `Assets/Scripts/Player/WristProximityDetector.cs` | Wrist-to-head proximity mechanic is VR-only UI behavior. |
| `Assets/Scripts/Player/XRComponentController.cs` | Toggles XR rig components; no equivalent in non-VR runtime. |
| `Assets/Scripts/Systems/Core/RefreshRateController.cs` | Requests XR display refresh rates; not used on desktop camera loop. |
| `Assets/Scripts/Systems/Core/SpaceWarpCameraExtension.cs` | Meta SpaceWarp OpenXR integration is VR-only. |
| `Assets/Scripts/UI/Controllers/CombatVignetteController.cs` | VR comfort vignette controller is unnecessary for top-down PC. |
| `Assets/Scripts/UI/Hosts/VignetteHost.cs` | Host for VR vignette UI only. |
| `Assets/Scripts/UI/Views/VignetteView.cs` | View for VR vignette UI only. |
| `Assets/Scripts/Weapons/Projectile.cs` | Current roadmap ranged attack is hitbox-based, so projectile flight script is not required for MVP. |
| `Assets/Scripts/Weapons/ShieldXRWeapon.cs` | Shield block/bash is outside reduced roadmap weapon scope. |
| `Assets/Scripts/Weapons/StaffXRWeapon.cs` | Staff charge-cast path is outside reduced roadmap weapon scope. |
| `Assets/Scripts/Weapons/ThrowableXRWeapon.cs` | Throwable recall weapon is outside reduced roadmap weapon scope. |
| `Assets/Scripts/Weapons/WeaponHolsterController.cs` | XR grab/socket holster behavior is VR-specific. |

---

## Section 4 — New Scripts Required (No VR Equivalent)

| Script | Purpose | Complexity | Estimate |
|--------|---------|------------|----------|
| `Assets/Scripts/Player/PCInputHandler.cs` | Centralize WASD + mouse input mapping for top-down controls | Medium | 3h |
| `Assets/Scripts/Player/TopDownPlayerController.cs` | Move/rotate player using PC input and aim direction | High | 6h |
| `Assets/Scripts/Player/TargetingSystem.cs` | Resolve mouse/world aim target for attacks | Medium | 4h |
| `Assets/Scripts/Data/Arena/RoomData.cs` | Hand-authored room SO (prefab, waves, doors, boss flag) | Low | 2h |
| `Assets/Scripts/Systems/Arena/RoomManager.cs` | Ordered room progression and room activation per floor | High | 6h |
| `Assets/Scripts/Systems/Arena/RoomDoorController.cs` | Door trigger + lock/unlock integration with gameplay events | Medium | 4h |
| `Assets/Scripts/Systems/Arena/RoomClearController.cs` | Detect active room clear and raise unlock/progression events | Medium | 3h |
| `Assets/Scripts/Characters/Enemies/SteeringBehaviours.cs` | Shared seek/separation/avoidance steering math helpers | High | 6h |
| `Assets/Scripts/UI/Views/ShopPanelView.cs` | Between-floor 3-choice upgrade UI view | Medium | 3h |
| `Assets/Scripts/UI/Hosts/ShopPanelHost.cs` | Shop panel lifecycle/binding host | Medium | 3h |
| `Assets/Scripts/UI/Controllers/ShopController.cs` | Offer upgrades, apply selection, continue flow | Medium | 4h |
| `Assets/Scripts/Systems/Arena/FloorTransitionController.cs` | Portal → loading → next floor transition pipeline | Medium | 4h |
| `Assets/Scripts/Systems/Arena/BossRoomController.cs` | Boss room state triggers + telegraph timing hooks | Medium | 4h |
| `Assets/Scripts/UI/Views/RunResultPanelView.cs` | Victory/defeat + score view | Medium | 3h |
| `Assets/Scripts/UI/Hosts/RunResultPanelHost.cs` | Result panel lifecycle host | Medium | 3h |
| `Assets/Scripts/UI/Controllers/RunResultController.cs` | Populate result UI and restart/exit actions | Medium | 3h |
| `Assets/Scripts/Systems/Arena/RunScoreController.cs` | Track and expose score values for end-of-run output/save | Medium | 3h |

---

## Section 5 — Data / ScriptableObject Changes

| ScriptableObject Class | PC plan |
|------------------------|---------|
| `Assets/Scripts/Attributes/FloatAttribute.cs` | Carry over as-is. |
| `Assets/Scripts/Attributes/IntAttribute.cs` | Carry over as-is. |
| `Assets/Scripts/Data/Core/AudioClipData.cs` | Carry over as-is. |
| `Assets/Scripts/Data/Core/ParticleData.cs` | Carry over as-is. |
| `Assets/Scripts/Data/Core/WorldAudioData.cs` | Carry over as-is. |
| `Assets/Scripts/Data/Core/EnemyData.cs` | Carry over base fields; add steering tuning fields (`separationWeight`, `avoidanceRadius`) if per-enemy tuning is needed. |
| `Assets/Scripts/Data/Weapons/WeaponModifierData.cs` | Carry over as-is. |
| `Assets/Scripts/Data/Weapons/ProjectileData.cs` | Keep class for future compatibility; not required for MVP hitbox-based ranged weapon. |
| `Assets/Scripts/Data/Weapons/WeaponData.cs` | Keep core/economy/combat fields; remove usage of VR-only fields (`gripPositionOffset`, `gripRotationOffset`, `hapticStrength`, `hapticDuration`) in PC runtime. |
| `Assets/Scripts/Data/Arena/WaveData.cs` | Carry over as-is. |
| `Assets/Scripts/Data/Arena/ArenaWavesData.cs` | Carry over as-is. |
| `Assets/Scripts/Data/Arena/ArenaData.cs` | Keep temporarily; create PC sibling `RoomData` for hand-authored room flow. |
| `Assets/Scripts/Data/Progression/MetaProgressionData.cs` | Carry over as-is. |
| `Assets/Scripts/Data/Progression/UpgradeData.cs` | Carry over as-is; reused by 3-choice shop. |
| `Assets/Scripts/Data/Settings/AudioSettingsConfig.cs` | Carry over as-is. |
| `Assets/Scripts/Data/Settings/VideoSettingsConfig.cs` | Carry over as-is (desktop quality/AA still relevant). |
| `Assets/Scripts/Data/Settings/LanguageSettingsConfig.cs` | Carry over as-is. |
| `Assets/Scripts/Data/Settings/ObjectPoolConfig.cs` | Carry over as-is (currently minimal). |
| `Assets/Scripts/Data/Registries/GameDatabaseRegistry.cs` | Carry over as-is; add `RoomDatabase` reference only if room data is databased. |

---

## Section 6 — Scene Structure

### Existing scenes now
- `Assets/Scenes/Game/Bootstrap.unity`
- `Assets/Scenes/Game/StartMenu.unity`
- `Assets/Scenes/Game/Hub.unity`
- `Assets/Scenes/Game/GoblinCampDay.unity`
- `Assets/Scenes/Game/MainTest.unity` (disabled in build settings)
- `Assets/Scenes/Demo/BasicScene.unity`
- `Assets/Scenes/Demo/SampleScene.unity`

### PC version keep
- `Bootstrap.unity` (bootstrap entry still useful)
- `StartMenu.unity` (core loop start)
- `MainTest.unity` (dev/test sandbox)

### PC version create
- `Assets/Scenes/PC/PCDungeonFloor01.unity`
- `Assets/Scenes/PC/PCDungeonFloor02.unity`
- `Assets/Scenes/PC/PCDungeonFloor03.unity` (optional third floor)
- `Assets/Scenes/PC/PCRunResult.unity` (or equivalent result UI scene if not overlay-based)

### PC version delete/archive (from PC branch only)
- `Assets/Scenes/Game/Hub.unity` (not in target loop)
- `Assets/Scenes/Game/GoblinCampDay.unity` (VR arena content)
- `Assets/Scenes/Demo/BasicScene.unity`
- `Assets/Scenes/Demo/SampleScene.unity`

### Bootstrap / loading changes required
- `BootstrapManager` can remain, but scene targets in menu/game flow must switch from `Hub/GoblinCampDay` to PC dungeon floor scenes.
- Build settings currently include XR configuration; PC branch should keep scene list focused on bootstrap/start menu/PC floors.

---

## Section 7 — Total Effort Estimate

### Totals
- Section 2 subtotal: **35h**
- Section 4 subtotal: **64h**
- **Total estimated rebuild effort: 99h**

### Week mapping (roadmap-aligned)
- **Week 1 (Core Loop): 31h**
  - `PCInputHandler`, `TopDownPlayerController`, `TopDownCameraController` replacement, `TargetingSystem`, `RoomData`, `RoomManager`, `RoomDoorController`, `RoomClearController`
- **Week 2 (Combat & Enemies): 32h**
  - `PCWeaponBase`, `PCMeleeWeapon`, `PCRangedWeapon`, `PCWeaponHitbox`, `EnemySteeringMovement`, `SteeringBehaviours`, feedback/audio replacements
- **Week 3 (Progression & UI): 27h**
  - `ShopPanel*`, `ShopController`, `FloorTransitionController`, `BossRoomController`, `RunResultPanel*`, `RunResultController`, `RunScoreController`
- **Week 4 (Polish & Ship): 9h**
  - integration hardening, scene wiring, regression passes for migrated systems

### Risk items (>4h)
- `EnemyMovement` → `EnemySteeringMovement`: **8h** (behavior tuning + obstacle edge cases)
- `TopDownPlayerController`: **6h** (input/aim/collision feel tuning)
- `RoomManager`: **6h** (room progression/state coupling)
- `SteeringBehaviours`: **6h** (separation/avoidance stability)

If runtime scene/prefab dependencies differ from code assumptions, add 6–10h contingency.
