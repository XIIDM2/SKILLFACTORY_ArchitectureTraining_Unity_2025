using Assets.CodeBase.Infrustructure.DependencyInjection;
using Assets.CodeBase.Infrustructure.DependencyInjection.DIContainer;
using CodeBase.Infrastructure.Services.ProgressSavers;
using CodeBase.Infrastructure.StateMachines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure.Services.GameStates
{
    public class GameBoostTrapperState : IEnterableState, IService
    { 
        private IGameStateSwitcher gameStateSwitcher;
        private IConfigProvider configProvider;
        private IProgressSaver progressSaver;

        public GameBoostTrapperState(IGameStateSwitcher gameStateSwitcher, IConfigProvider configProvider, IProgressSaver progressSaver)
        {
            this.gameStateSwitcher = gameStateSwitcher;
            this.configProvider = configProvider;
            this.progressSaver = progressSaver;
        }

        public void Enter()
        {
            Application.targetFrameRate = (int)Screen.currentResolution.refreshRateRatio.value;

            configProvider.Load();

            progressSaver.LoadProgress();

            if (SceneManager.GetActiveScene().name == Constants.BoostreapperSceneName || SceneManager.GetActiveScene().name == Constants.MainMenuSceneName)
            {
                gameStateSwitcher.EnterState<LoadMainMenuState>();
            }
            Debug.Log("GAME : Init");
        }


    }

    
}