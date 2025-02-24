using Assets.CodeBase.Infrustructure.DependencyInjection.DIContainer;
using Assets.CodeBase.Services.ProgressSaver;
using CodeBase.GamePlay.UI.Services;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Factory;
using CodeBase.Infrastructure.Services.GameStates;
using CodeBase.Infrastructure.Services.ProgressProviders;
using CodeBase.Infrastructure.Services.ProgressSavers;
using CodeBase.Infrastructure.Services.SceneStates;
using CodeBase.Infrastructure.StateMachines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Infrastructure.SceneStates
{
    public class VictorySceneState : IEnterableState, IService
    {
        private IInputService inputService;
        private IGameFactory gameFactory;
        private IProgressProvider progressProvider;
        private IProgressSaver progressSaver;
        private IWindowProvider windowProvider;

        public VictorySceneState(IInputService inputService, IGameFactory gameFactory, IGameStateSwitcher gameStateSwitcher, IProgressProvider progressProvider, IProgressSaver progressSaver, IWindowProvider windowProvider)
        {
            this.inputService = inputService;
            this.gameFactory = gameFactory;
            this.progressProvider = progressProvider;
            this.progressSaver = progressSaver;
            this.windowProvider = windowProvider;
        }

        public void Enter()
        {
            progressProvider.PlayerProgress.LevelIndex++;
            progressProvider.PlayerProgress.HeroStats.HeroMaxHealth += 50;
            progressProvider.PlayerProgress.HeroStats.HeroDamage += 10;
            progressProvider.PlayerProgress.HeroStats.HeroMovementSpeed += 1;
            progressProvider.PlayerProgress.HeroStats.SaveHeroGold(gameFactory.HeroGold.GetGoldAmount());

            progressSaver.SaveProgress();

            inputService.IsEnabled = false;
            gameFactory.VirtualJoyStick.gameObject.SetActive(false);

            windowProvider.Open(UI.Elements.WindowID.VictoryWindow);

        }
    }
}