using System;
using Constants;
using Data.Arena;
using Data.Waves;
using Events;
using Events.Registries;
using Systems.Core;
using UnityEngine;
using Utilities;

namespace Systems.Arena
{
    [RequireComponent(typeof(WaveSpawner))]
    public class WaveManager : MonoBehaviour, IUpdateable
    {
        [Header("Arena Data")]
        [SerializeField] private ArenaWavesData arenaWavesData;

        private CountdownTimer _countdownTimer;
        private WaveSpawner _waveSpawner;
        private int _currentWaveIndex;

        private void HandleWavePrelude() => StartCountdown(GameConstants.PreludeDuration, ArenaState.WaveIntermission);

        private void HandleWaveStart()
        {
            var waveData = arenaWavesData.Waves[_currentWaveIndex];
            _waveSpawner.SpawnWave(waveData);
        }

        private void HandleWaveCompletion()
        {
            _currentWaveIndex++;
            var allWavesCompleted = _currentWaveIndex >= arenaWavesData.Waves.Count;

            GameplayEvents.ArenaStateChangeRequested.Raise(allWavesCompleted
                ? ArenaState.BossIntermission
                : ArenaState.WaveIntermission);
        }

        private void HandleAllWaveEnemiesDefeated() => GameplayEvents.ArenaStateChangeRequested.Raise(ArenaState.WaveComplete);

        private void HandleBossSpawn()
        {
            var bossWave = arenaWavesData.Boss;
            _waveSpawner.SpawnBoss(bossWave);
        }

        private void HandleBossDefeated() => GameplayEvents.ArenaStateChangeRequested.Raise(ArenaState.BossComplete);
        private void HandleBossCompletion() => GameplayEvents.ArenaStateChangeRequested.Raise(ArenaState.ArenaVictory);
        private void HandleIntermission(float duration, ArenaState nextState) => StartCountdown(duration, nextState);
        private void StopTimer() => _countdownTimer.Stop();

        private void HandleGameStateChange(ArenaState arenaState)
        {
            Debug.Log($"WaveManager: State changed to {arenaState}.");
            switch (arenaState)
            {
                case ArenaState.ArenaPrelude:
                    HandleWavePrelude();
                    break;
                case ArenaState.WaveIntermission:
                    HandleIntermission(GameConstants.WaveIntermissionDuration, ArenaState.WaveActive);
                    break;
                case ArenaState.WaveActive:
                    HandleWaveStart();
                    break;
                case ArenaState.WaveComplete:
                    HandleWaveCompletion();
                    break;
                case ArenaState.BossIntermission:
                    HandleIntermission(GameConstants.BossIntermissionDuration, ArenaState.BossActive);
                    break;
                case ArenaState.BossActive:
                    HandleBossSpawn();
                    break;
                case ArenaState.BossComplete:
                    HandleBossCompletion();
                    break;
                case ArenaState.ArenaDefeat:
                case ArenaState.ArenaVictory:
                case ArenaState.ArenaPaused:
                    StopTimer();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(arenaState), arenaState, null);
            }
        }

        private void StartCountdown(float duration, ArenaState nextState)
        {
            _countdownTimer.Start(duration, () => GameplayEvents.ArenaStateChangeRequested.Raise(nextState));
        }

        public void OnUpdate(float deltaTime) => _countdownTimer.Update(deltaTime);

        private void Awake()
        {
            _countdownTimer = new CountdownTimer();
            _waveSpawner = GetComponent<WaveSpawner>();
        }

        private void OnEnable()
        {
            GameplayEvents.ArenaStateChanged.Subscribe(HandleGameStateChange);
            _waveSpawner.OnWaveEnemiesDefeated += HandleAllWaveEnemiesDefeated;
            _waveSpawner.OnBossDefeated += HandleBossDefeated;
            GameUpdateManager.Instance.Register(this, UpdatePriority.High);
        }

        private void OnDisable()
        {
            GameplayEvents.ArenaStateChanged.Unsubscribe(HandleGameStateChange);
            _waveSpawner.OnWaveEnemiesDefeated -= HandleAllWaveEnemiesDefeated;
            _waveSpawner.OnBossDefeated -= HandleBossDefeated;
            GameUpdateManager.Instance.Unregister(this);
        }
    }
}
