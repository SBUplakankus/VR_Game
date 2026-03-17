# Development Roadmap

2–4 week solo sprint plan for a small, shippable top-down dungeon crawler vertical slice.

---

## Week 1: Core Loop

**Goal:** Ship a playable room-to-room dungeon flow with lock/clear progression.

| Task | Priority | Estimate |
|:-----|:---------|:---------|
| Implement top-down player controller (WASD move, mouse aim) | Critical | 1.5d |
| Add top-down Cinemachine camera follow/aim framing | Critical | 0.5d |
| Define room structure data (`RoomData` ScriptableObject + door trigger setup) | Critical | 1d |
| Build one gameplay scene with 2 connected hand-authored rooms | High | 1d |
| Spawn enemies per room and lock doors on room start | Critical | 1d |
| Detect room clear and unlock doors on enemy-clear event | Critical | 0.5d |

---

## Week 2: Combat & Enemies

**Goal:** Finalize core combat feel and reliable enemy pressure for room clears.

| Task | Priority | Estimate |
|:-----|:---------|:---------|
| Implement one melee weapon (hitbox-based) | Critical | 1d |
| Implement one ranged weapon (hitbox-based, no velocity calc) | Critical | 1d |
| Replace NavMesh movement with simple steering (seek + separation + obstacle avoidance) | Critical | 1.5d |
| Add enemy attack behavior (contact damage or short-range strike) | Critical | 1d |
| Add player health + damage flash feedback | High | 0.5d |
| Implement player death and respawn flow | Critical | 1d |

---

## Week 3: Progression & UI

**Goal:** Add floor progression, between-floor decisions, and complete run-end states.

| Task | Priority | Estimate |
|:-----|:---------|:---------|
| Drop gold on enemy death and track run gold total | Critical | 0.5d |
| Build shop screen with 3 upgrade choices between floors | Critical | 1d |
| Implement floor transition (portal → loading → next floor) | Critical | 1d |
| Add one boss room with one boss enemy type | Critical | 1d |
| Add telegraphed boss attack behavior | High | 1d |
| Build victory/defeat screen with score output | Critical | 1d |

---

## Week 4: Polish & Ship

**Goal:** Content-complete the vertical slice and ship tested PC builds.

| Task | Priority | Estimate |
|:-----|:---------|:---------|
| Author 2–3 floors with 3–5 hand-authored rooms each | Critical | 2d |
| Hook up audio using existing `AudioEvents` flow | High | 1d |
| Save score + settings through existing save system | High | 0.5d |
| Build and test on Windows + Linux | Critical | 1d |
| Capture trailer footage and publish itch.io page | High | 0.5d |

---

## Descoped

- Pause system
- Custom time management layer
- Player level progression curves
- Arena HUD expansion
- Arena results star rating
- Wrist/hand VR UI
- Velocity-based melee damage
- Haptic feedback improvements
- Enemy AI state machine expansion
- Leaderboards
- Save slots UI
- Environmental hazards
- Combo system
- Achievement system
- Tutorial arena
- Multiplayer features
