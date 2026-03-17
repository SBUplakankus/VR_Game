# Player System

## Controller Spec
- Top-down locomotion: WASD movement on world XZ plane.
- Mouse-driven facing: player rotates to aim point each frame.
- Fixed gameplay camera assumptions: no head/wrist tracking.
- Combat trigger routing: primary attack, secondary attack, interact, pause.

## Input Bindings
| Action | Binding |
|--------|---------|
| Move | WASD / Left Stick |
| Aim | Mouse position / Right Stick |
| Primary Attack | Left Mouse |
| Secondary Attack | Right Mouse |
| Interact | E |
| Pause | Esc |

## Rebuild References
- [VR to PC Map](../rebuild/vr-to-pc-map.md)
- `Assets/Scripts/Player/PCInputHandler.cs`
- `Assets/Scripts/Player/TopDownPlayerController.cs`
