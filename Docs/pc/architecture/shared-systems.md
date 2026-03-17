# Shared Systems

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

## System Notes

- Databases — No changes required for PC.
- Event Channels — No changes required for PC.
- Object Pooling — No changes required for PC.
- Save Managers — No changes required for PC.
- Core Constants — No changes required for PC.
- Attribute ScriptableObjects — No changes required for PC.
- Enemy Controller/Health/Animator/Attack stack — No changes required for PC.
- Wave + Arena state orchestration — No changes required for PC.
- UI Factory/Host/View pattern — No changes required for PC.
- Loading/Fade UI flow — No changes required for PC.
- Audio event routing — No changes required for PC.
- Localization pipeline — No changes required for PC.
- GameUpdateManager priority scheduler — No changes required for PC.
- VFX priority routing — No changes required for PC.
- Stats/save data models — No changes required for PC.
