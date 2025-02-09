using Assets.CodeBase.Infrustructure.DependencyInjection;
using Assets.CodeBase.Infrustructure.DependencyInjection.DIContainer;
using CodeBase.Infrastructure.StateMachines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.GameStates
{
    public class GameBoostTrapperState : IEnterableState, IService
    { 
        private IGameStateSwitcher gameStateSwitcher;

        public GameBoostTrapperState(IGameStateSwitcher gameStateSwitcher)
        {
            this.gameStateSwitcher = gameStateSwitcher;
        }

        public void Enter()
        {
            Application.targetFrameRate = (int)Screen.currentResolution.refreshRateRatio.value;

            gameStateSwitcher.EnterState<LoadNextSceneState>();

            Debug.Log("GAME : Init");
        }


    }

    
}