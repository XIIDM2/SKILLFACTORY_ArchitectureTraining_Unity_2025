using Assets.CodeBase.Infrustructure.DependencyInjection;
using Assets.CodeBase.Infrustructure.DependencyInjection.DIContainer;
using CodeBase.Infrastructure.Services.ProgressProviders;
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
        private IProgressProvider progressProvider;
        private IConfigProvider configProvider;

        public LoadNextSceneState(ISceneLoader sceneLoader, IProgressProvider progressProvider, IConfigProvider configProvider)
        {
            this.sceneLoader = sceneLoader;
            this.progressProvider = progressProvider;
            this.configProvider = configProvider;
        }

        public void Enter()
        {
            int levelIndex = progressProvider.PlayerProgress.LevelIndex;
            levelIndex = Mathf.Clamp(levelIndex, 0, configProvider.ScenesAmount - 1);

            string sceneName = configProvider.GetSceneConfig(levelIndex).SceneName;

            sceneLoader.Load(sceneName);
        }
    }
} 