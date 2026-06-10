# Monsta Choppa VR

A VR roguelike arena combat game built with Unity's XR Interaction Toolkit. Fight waves of enemies in arenas, earn gold and experience, upgrade equipment, and progress through increasingly difficult challenges.

## Tech Stack

- **Engine:** Unity 6000.4.8f1 (Unity 6)
- **Render Pipeline:** Universal Render Pipeline (URP) 17.4.0
- **XR:** XR Interaction Toolkit 3.4.1, OpenXR 1.16.1, Oculus 4.5.4, XR Hands 1.7.3
- **Target:** Meta Quest 2/3 (Android ARM64, Vulkan, IL2CPP)
- **Plugins:** PrimeTween, ESave

## Features

- 5 VR weapon types: melee (velocity-based damage), bow, staff, shield (block/bash), throwable
- Object pooling with priority routing for VFX and audio
- Priority-based update system (3-tier throttling)
- ScriptableObject-driven database architecture
- Event channel system for decoupled communication
- UI Toolkit with Factory-View-Host pattern
- Application SpaceWarp for half-rate rendering
- 90 Hz refresh rate support

## Build

Open in Unity 6000.4.8f1, switch platform to Android, and build.

## Development

This project was documented on [YouTube](https://www.youtube.com/watch?v=kB48cedTjUw&list=PLAcWixmo_apu7DfyybS1LCxLorlU4yAi2).
