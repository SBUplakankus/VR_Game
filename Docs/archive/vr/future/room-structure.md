# Room Structure

Hand-authored room flow for the top-down dungeon crawler pivot.

---

## RoomData ScriptableObject

`RoomData` defines per-room content and progression wiring.

| Field | Purpose |
|:------|:--------|
| Room Prefab Ref | Prefab to load/spawn for this room |
| Spawn Wave Config | Enemy wave setup used by room spawner |
| Door Positions | Door transform/anchor references for connection points |
| Is Boss Room (bool) | Marks room as boss room for end-of-floor flow |

---

## Room Connections

- `RoomManager` holds an ordered list of `RoomData` for each floor.
- Active room index drives which room is loaded next.
- Door triggers reference the next room in order (or branch target if configured).
- Room layout remains linear or simple branching only.

---

## Door Lock/Unlock Flow (Event Channels)

1. Room enters active state.
2. Door lock request is raised through existing gameplay event channels.
3. Enemies spawn from room wave config.
4. Room clear condition is met when active enemies reach zero.
5. Door unlock request is raised through existing gameplay event channels.
6. Player transitions through unlocked door to next room.

---

## Integration with Existing Managers

- `GameFlowManager` controls high-level run states (start, floor progress, victory, defeat).
- `ArenaStateManager` controls room combat states (prelude, active, clear, boss).
- `RoomManager` feeds `RoomData` into those state transitions.

---

## Scope Constraints

- No procedural generation.
- No graph traversal system.
- Hand-authored rooms only.
- Linear flow or simple branching only.
