using UnityEngine;
using CodeBase.Infrastructure.Services;
using System;
using UnityEngine.SceneManagement;
using CodeBase.Infrastructure.Services.SceneLoader;
using CodeBase.Infrastructure.Services.GameStates;
using Assets.CodeBase.Infrustructure.DependencyInjection;

namespace Assets.CodeBase.Infrustructure
{
    public class GameBoostTrapper : MonoBoostTrapper
    {
        private IGameStateSwitcher gameStateSwitcher;
        private GameBoostTrapperState gameBoostTrapperState;
        private LoadNextSceneState loadNextSceneState;

        [Inject]
        public void Construct(IGameStateSwitcher gameStateSwitcher, GameBoostTrapperState gameBoostTrapperState, LoadNextSceneState loadNextSceneState)
        {
            this.gameStateSwitcher = gameStateSwitcher;
            this.gameBoostTrapperState = gameBoostTrapperState;
            this.loadNextSceneState = loadNextSceneState;
        }

        public override void OnBindResolved()
        {
            DontDestroyOnLoad(this);

            InitGameStateMachine();

            RunGameStateMachine();
        }

        private void InitGameStateMachine()
        {
            gameStateSwitcher.AddState(gameBoostTrapperState);
            gameStateSwitcher.AddState(loadNextSceneState);
        }
        private void RunGameStateMachine()
        {
            gameStateSwitcher.EnterState<GameBoostTrapperState>();
        }


    }
}