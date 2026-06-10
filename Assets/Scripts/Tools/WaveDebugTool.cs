using Systems;
using Systems.Arena;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Tools
{
    public class WaveDebugTool : MonoBehaviour
    {
        [Header("Debug References")]
        [SerializeField] private EnemyManager enemyManager;

        private void KillAllEnemies()
        {
            if (!enemyManager)
            {
                Debug.LogError("DebugWaveTool: WaveSpawner not assigned.");
                return;
            }

            Debug.Log("DebugWaveTool: KillAllEnemies");
            enemyManager.CleanupEnemies();
        }

        private void Update()
        {
            if (Keyboard.current.kKey.wasPressedThisFrame)
                KillAllEnemies();
        }
    }
}
