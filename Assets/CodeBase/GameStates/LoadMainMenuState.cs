using Assets.CodeBase.Infrustructure.DependencyInjection.DIContainer;
using CodeBase.GamePlay.UI.Services;
using CodeBase.Infrastructure.Services.SceneLoader;
using CodeBase.Infrastructure.StateMachines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.GameStates
{
    public class LoadMainMenuState : IEnterableState, IService
    {
        private ISceneLoader sceneLoader;
        private IWindowProvider windowProvider;

        public LoadMainMenuState(ISceneLoader sceneLoader, IWindowProvider windowProvider)
        {
            this.sceneLoader = sceneLoader;
            this.windowProvider = windowProvider;
        }

        public void Enter()
        {
            sceneLoader.Load(Constants.MainMenuSceneName, onloaded: () => windowProvider.Open(UI.Elements.WindowID.MainMenuWindow));
        }
    }
}

