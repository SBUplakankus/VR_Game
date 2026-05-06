# Monsta Choppa VR

A VR roguelike arena combat game built with Unity's XR Interaction Toolkit. Fight waves of enemies in arenas, earn gold and experience, upgrade equipment, and progress through increasingly difficult challenges.

## YouTube Playlist

The development of this game was documented on YouTube through a [mini-series](https://www.youtube.com/watch?v=kB48cedTjUw&list=PLAcWixmo_apu7DfyybS1LCxLorlU4yAi2&pp=sAgC) 
that I uploaded a video for once a wekk until I shelved the project you can watch.

## Project Status

I started this project to prepare for my Internship as an Immersive Developer and had hopes to publish a finished release,
but it was shelved in January 2026 due to just not having the time or energy. See the [full documentation](https://sbuplakankus.github.io/monsta-choppa-vr/) for details. 

## Documentation

The current docs were generated using Opus 4.5 based on the code I wrote myself and my existing documentation.

| Section | Description |
|:--------|:------------|
| [Architecture](Docs/architecture/overview.md) | System design, event channels, database patterns |
| [Game Systems](Docs/systems/weapons.md) | Weapons, enemies, UI, save data |
| [VR Development](Docs/vr/performance.md) | Performance optimization, comfort, SpaceWarp |
| [Future Plans](Docs/future/roadmap.md) | Roadmap and project status |

## Technical Highlights

- **ScriptableObject-driven architecture** with generic database patterns
- **Event channel system** for decoupled communication
- **Object pooling** with priority routing for VR performance
- **UI Toolkit** with Factory-View-Host pattern
- **XR Interaction Toolkit** integration for VR input

## Dependencies

| Asset | Purpose |
|:------|:--------|
| PrimeTween | Allocation-free animation |
| ESave | Save file serialization |
| XR Interaction Toolkit | VR input and interaction |
| Synty Dungeon Realms | Environment art |
