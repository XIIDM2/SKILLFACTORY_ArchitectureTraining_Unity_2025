using Assets.CodeBase.Infrustructure.DependencyInjection;
using Assets.CodeBase.Infrustructure.DependencyInjection.DIContainer;
using CodeBase.Infrastructure.Services.SceneLoader;
using CodeBase.Infrastructure.StateMachines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.GameStates
{
    public class LoadNextSceneState : IEnterableState, IService
    {
        private ISceneLoader sceneLoader;

        public LoadNextSceneState(ISceneLoader sceneLoader)
        {
            this.sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            sceneLoader.Load("Level_1");
        }
    }
}