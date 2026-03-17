# Enemy System

## Steering Behaviour Spec
- Seek: move toward current player position.
- Separation: repel from nearby enemies to reduce clumping.
- Obstacle Avoidance: steer away from immediate blockers without NavMesh.
- Attack gate remains distance/timer based from existing enemy attack flow.

## Attack Patterns
- Contact damage for basic pressure enemies.
- Short-range strike using existing `EnemyAttack` timing and hit radius.

## Carries Over Unchanged
- `EnemyController`
- `EnemyHealth`
- `EnemyAnimator`
- `EnemyAttack`
- Enemy spawn/despawn event flow via `GameplayEvents` and `EnemyManager`
