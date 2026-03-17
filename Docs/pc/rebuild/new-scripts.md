# New Scripts

| Script | Purpose | Complexity | Estimate | Status |
|--------|---------|------------|----------|--------|
| `Assets/Scripts/Player/PCInputHandler.cs` | Centralize WASD + mouse input mapping for top-down controls | Medium | 3h | Not Started |
| `Assets/Scripts/Player/TopDownPlayerController.cs` | Move/rotate player using PC input and aim direction | High | 6h | Not Started |
| `Assets/Scripts/Player/TargetingSystem.cs` | Resolve mouse/world aim target for attacks | Medium | 4h | Not Started |
| `Assets/Scripts/Data/Arena/RoomData.cs` | Hand-authored room SO (prefab, waves, doors, boss flag) | Low | 2h | Not Started |
| `Assets/Scripts/Systems/Arena/RoomManager.cs` | Ordered room progression and room activation per floor | High | 6h | Not Started |
| `Assets/Scripts/Systems/Arena/RoomDoorController.cs` | Door trigger + lock/unlock integration with gameplay events | Medium | 4h | Not Started |
| `Assets/Scripts/Systems/Arena/RoomClearController.cs` | Detect active room clear and raise unlock/progression events | Medium | 3h | Not Started |
| `Assets/Scripts/Characters/Enemies/SteeringBehaviours.cs` | Shared seek/separation/avoidance steering math helpers | High | 6h | Not Started |
| `Assets/Scripts/UI/Views/ShopPanelView.cs` | Between-floor 3-choice upgrade UI view | Medium | 3h | Not Started |
| `Assets/Scripts/UI/Hosts/ShopPanelHost.cs` | Shop panel lifecycle/binding host | Medium | 3h | Not Started |
| `Assets/Scripts/UI/Controllers/ShopController.cs` | Offer upgrades, apply selection, continue flow | Medium | 4h | Not Started |
| `Assets/Scripts/Systems/Arena/FloorTransitionController.cs` | Portal → loading → next floor transition pipeline | Medium | 4h | Not Started |
| `Assets/Scripts/Systems/Arena/BossRoomController.cs` | Boss room state triggers + telegraph timing hooks | Medium | 4h | Not Started |
| `Assets/Scripts/UI/Views/RunResultPanelView.cs` | Victory/defeat + score view | Medium | 3h | Not Started |
| `Assets/Scripts/UI/Hosts/RunResultPanelHost.cs` | Result panel lifecycle host | Medium | 3h | Not Started |
| `Assets/Scripts/UI/Controllers/RunResultController.cs` | Populate result UI and restart/exit actions | Medium | 3h | Not Started |
| `Assets/Scripts/Systems/Arena/RunScoreController.cs` | Track and expose score values for end-of-run output/save | Medium | 3h | Not Started |
