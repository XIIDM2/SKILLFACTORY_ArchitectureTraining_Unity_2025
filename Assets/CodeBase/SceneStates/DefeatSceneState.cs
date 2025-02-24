using Assets.CodeBase.Infrustructure.DependencyInjection.DIContainer;
using CodeBase.Infrastructure.Services.Factory;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.StateMachines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeBase.GamePlay.UI.Services;

namespace CodeBase.Infrastructure.SceneStates
{
    public class DefeatSceneState : IEnterableState, IService
    {
        private IInputService inputService;
        private IGameFactory gameFactory;
        private IWindowProvider windowProvider;

        public DefeatSceneState(IInputService inputService, IGameFactory gameFactory, IWindowProvider windowProvider)
        {
            this.inputService = inputService;
            this.gameFactory = gameFactory;
            this.windowProvider = windowProvider;
        }

        public void Enter()
        {
            inputService.IsEnabled = false;
            gameFactory.VirtualJoyStick.gameObject.SetActive(false);
            windowProvider.Open(UI.Elements.WindowID.DefeatWindow);
        }
    }
}