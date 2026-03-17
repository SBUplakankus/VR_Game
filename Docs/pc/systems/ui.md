# UI System

## Required PC Panels
| Panel | Status |
|-------|--------|
| StartMenu | Carry over (resized/layout update only) |
| HUD | Rebuild (replaces wrist/proximity presentation) |
| Shop | Rebuild |
| Results (Victory/Defeat + Score) | Rebuild |
| Pause | Carry over (resized/layout update only) |
| Loading Screen | Carry over (text/layout update only) |
| Settings | Carry over (resized/layout update only) |

## Carry Over vs Rebuild
- Carry over architecture: UI Toolkit Factory + Host + View + Controller pattern.
- Carry over panels: StartMenu, Pause, Loading, Settings (desktop layout pass only).
- Rebuild panels: persistent HUD, between-floor Shop, run Results.
