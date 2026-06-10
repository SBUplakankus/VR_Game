using System;
using System.Collections;
using Events;
using Events.Registries;
using Systems.Core;
using UnityEngine;

namespace Systems.Arena
{
    public enum ArenaState
    {
        ArenaPrelude,
        WaveActive,
        WaveIntermission,
        WaveComplete,
        BossIntermission,
        BossActive,
        BossComplete,
        ArenaVictory,
        ArenaDefeat,
        ArenaPaused
    }

    public class ArenaStateManager : MonoBehaviour
    {
        private ArenaState _currentArenaState;
        private ArenaState _previousState;

        public ArenaState CurrentArenaState => _currentArenaState;
        public ArenaState PreviousArenaState => _previousState;

        private static bool IsValidTransition(ArenaState from, ArenaState to)
        {
            Debug.Log($"GameStateManager: Checking if transition from {from} to {to} is valid.");
            return from switch
            {
                ArenaState.ArenaPrelude => to == ArenaState.WaveIntermission,
                ArenaState.WaveIntermission => to == ArenaState.WaveActive,
                ArenaState.WaveActive => to is ArenaState.WaveComplete or ArenaState.ArenaDefeat,
                ArenaState.WaveComplete => to is ArenaState.WaveIntermission or ArenaState.BossIntermission,
                ArenaState.BossIntermission => to == ArenaState.BossActive,
                ArenaState.BossActive => to is ArenaState.BossComplete or ArenaState.ArenaDefeat,
                ArenaState.BossComplete => to == ArenaState.ArenaVictory,
                ArenaState.ArenaVictory => false,
                ArenaState.ArenaDefeat => false,
                ArenaState.ArenaPaused => true,
                _ => false
            };
        }

        private void HandleArenaStateChangeRequest(ArenaState newArenaState)
        {
            if (_currentArenaState == newArenaState)
            {
                Debug.LogWarning($"GameStateManager: Ignoring redundant state change to {newArenaState}. Already in that state!");
                return;
            }

            if (!IsValidTransition(_currentArenaState, newArenaState))
            {
                Debug.LogWarning($"GameStateManager: Invalid transition from {_currentArenaState} to {newArenaState}.");
                return;
            }

            Debug.Log($"GameStateManager: Handling requested state transition to {newArenaState}.");
            HandleGameStateChanged(newArenaState);
        }

        private void HandleGameStateChanged(ArenaState newArenaState)
        {
            Debug.Log($"GameStateManager: Exiting {_currentArenaState}, transitioning to {newArenaState}.");
            ExitCurrentState();
            _currentArenaState = newArenaState;
            EnterCurrentState();
            Debug.Log($"GameStateManager: Entered new state {newArenaState}.");
            GameplayEvents.ArenaStateChanged.Raise(_currentArenaState);
        }

        private void TogglePause()
        {
            if (_currentArenaState == ArenaState.ArenaPaused)
            {
                Debug.Log("GameStateManager: Resuming from paused state.");
                HandleGameStateChanged(_previousState);
            }
            else
            {
                Debug.Log($"GameStateManager: Pausing game. Previous state: {_currentArenaState}.");
                _previousState = _currentArenaState;
                HandleGameStateChanged(ArenaState.ArenaPaused);
            }
        }

        private void EnterCurrentState()
        {
            switch (_currentArenaState)
            {
                case ArenaState.ArenaPrelude: HandleGamePreludeEnter(); break;
                case ArenaState.WaveIntermission: HandleWaveIntermissionEnter(); break;
                case ArenaState.WaveActive: HandleWaveActiveEnter(); break;
                case ArenaState.WaveComplete: HandleWaveCompleteEnter(); break;
                case ArenaState.BossIntermission: HandleBossIntermissionEnter(); break;
                case ArenaState.BossActive: HandleBossActiveEnter(); break;
                case ArenaState.BossComplete: HandleBossCompleteEnter(); break;
                case ArenaState.ArenaVictory: HandleGameWonEnter(); break;
                case ArenaState.ArenaDefeat: HandleGameOverEnter(); break;
                case ArenaState.ArenaPaused: HandleGamePausedEnter(); break;
                default: throw new ArgumentOutOfRangeException();
            }
        }

        private void ExitCurrentState()
        {
            switch (_currentArenaState)
            {
                case ArenaState.ArenaPrelude: HandleGamePreludeExit(); break;
                case ArenaState.WaveIntermission: HandleWaveIntermissionExit(); break;
                case ArenaState.WaveActive: HandleWaveActiveExit(); break;
                case ArenaState.WaveComplete: HandleWaveCompleteExit(); break;
                case ArenaState.BossIntermission: HandleBossIntermissionExit(); break;
                case ArenaState.BossActive: HandleBossActiveExit(); break;
                case ArenaState.BossComplete: HandleBossCompleteExit(); break;
                case ArenaState.ArenaVictory: HandleGameWonExit(); break;
                case ArenaState.ArenaDefeat: HandleGameOverExit(); break;
                case ArenaState.ArenaPaused: HandleGamePausedExit(); break;
                default: throw new ArgumentOutOfRangeException();
            }
        }

        private void HandleGamePreludeEnter() => GameplayEvents.GameStateChangeRequested.Raise(GameState.Arena);
        private void HandleGamePreludeExit() => Debug.Log("GameStateManager: Exiting GamePrelude State.");
        private void HandleWaveIntermissionEnter() => Debug.Log("GameStateManager: Entering WaveIntermission State.");
        private void HandleWaveIntermissionExit() => Debug.Log("GameStateManager: Exiting WaveIntermission State.");
        private void HandleWaveActiveEnter() => Debug.Log("GameStateManager: Entering WaveActive State.");
        private void HandleWaveActiveExit() => Debug.Log("GameStateManager: Exiting WaveActive State.");
        private void HandleWaveCompleteEnter() => Debug.Log("GameStateManager: Entering WaveComplete State.");
        private void HandleWaveCompleteExit() => Debug.Log("GameStateManager: Exiting WaveComplete State.");
        private void HandleBossIntermissionEnter() => Debug.Log("GameStateManager: Entering BossIntermission State.");
        private void HandleBossIntermissionExit() => Debug.Log("GameStateManager: Exiting BossIntermission State.");
        private void HandleBossActiveEnter() => Debug.Log("GameStateManager: Entering BossActive State.");
        private void HandleBossActiveExit() => Debug.Log("GameStateManager: Exiting BossActive State.");
        private void HandleBossCompleteEnter() => Debug.Log("GameStateManager: Entering BossComplete State.");
        private void HandleBossCompleteExit() => Debug.Log("GameStateManager: Exiting BossComplete State.");
        private void HandleGameWonEnter() => GameplayEvents.GameStateChangeRequested.Raise(GameState.ArenaVictory);
        private void HandleGameWonExit() => Debug.Log("GameStateManager: Exiting GameWon State.");
        private void HandleGameOverEnter() => GameplayEvents.GameStateChangeRequested.Raise(GameState.ArenaDefeat);
        private void HandleGameOverExit() => Debug.Log("GameStateManager: Exiting GameOver State.");
        private void HandleGamePausedEnter() => Debug.Log("GameStateManager: Game Paused. Setting Time.timeScale to 0.");
        private void HandleGamePausedExit() => Debug.Log("GameStateManager: Game Resumed. Restoring Time.timeScale to 1.");

        private void Awake()
        {
            _currentArenaState = ArenaState.ArenaPrelude;
            EnterCurrentState();
        }

        private IEnumerator TestStart()
        {
            yield return new WaitForSeconds(1);
            GameplayEvents.ArenaStateChanged.Raise(_currentArenaState);
        }

        private void OnEnable()
        {
            GameplayEvents.ArenaStateChangeRequested.Subscribe(HandleArenaStateChangeRequest);
            StartCoroutine(TestStart());
        }

        private void OnDisable() => GameplayEvents.ArenaStateChangeRequested.Unsubscribe(HandleArenaStateChangeRequest);
    }
}
