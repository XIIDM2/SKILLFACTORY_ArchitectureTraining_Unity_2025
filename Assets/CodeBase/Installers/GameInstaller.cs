using Assets.CodeBase.Infrustructure.AssetsManagement;
using Assets.CodeBase.Infrustructure.DependencyInjection;
using Assets.CodeBase.Infrustructure.DependencyInjection.DIContainer;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.CoroutineRunner;
using CodeBase.Infrastructure.Services.Factory;
using CodeBase.Infrastructure.Services.GameStates;
using CodeBase.Infrastructure.Services.SceneLoader;
using System;
using UnityEngine;

namespace Assets.CodeBase.Infrustructure
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBinding()
        {
            RegisterGlobalServices();

            RegisterGameStateMachine();
        }

        private void RegisterGlobalServices()
        {
            DependencyInjectioncontainer.RegisterService<ICoroutineRunner, CoroutineRunner>();
            DependencyInjectioncontainer.RegisterService<ISceneLoader, SceneLoader>();
            DependencyInjectioncontainer.RegisterService<IAssetsProvider, AssetsProvider>();
            DependencyInjectioncontainer.RegisterService<IInputService, InputService>();
            DependencyInjectioncontainer.RegisterService<IGameFactory, GameFactory>();
            Debug.Log("GAME : Register Services");
        }

        private void RegisterGameStateMachine()
        {
            DependencyInjectioncontainer.RegisterService<IGameStateSwitcher, GameStateMachine>();
            DependencyInjectioncontainer.RegisterService<GameBoostTrapperState>();
            DependencyInjectioncontainer.RegisterService<LoadNextSceneState>();
        }
    }
}
