using Assets.CodeBase.Infrustructure.AssetsManagement;
using Assets.CodeBase.Infrustructure.DependencyInjection;
using Assets.CodeBase.Infrustructure.DependencyInjection.DIContainer;
using Assets.CodeBase.SceneStates;
using CodeBase.Configs;
using CodeBase.GamePlay.Spawners;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Factory;
using CodeBase.Infrastructure.Services.ProgressSavers;
using CodeBase.Infrastructure.Services.SceneStates;
using CodeBase.Infrastructure.StateMachines;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

namespace CodeBase.Infrastructure.SceneStates
{
    public class BoostrapperSceneState : IEnterableState, IService
    {
        private readonly IGameFactory gameFactory;
        private readonly ISceneStateSwitcher sceneStateSwitcher;
        private readonly IInputService inputService;
        private readonly IConfigProvider configProvider;
        private readonly IProgressSaver progressSaver;


        private SceneConfig sceneConfig;

        public BoostrapperSceneState(IGameFactory gameFactory, ISceneStateSwitcher sceneStateSwitcher, IInputService inputService, IConfigProvider configProvider, IProgressSaver progressSaver)
        {
            this.gameFactory = gameFactory;
            this.sceneStateSwitcher = sceneStateSwitcher;
            this.inputService = inputService;
            this.configProvider = configProvider;
            this.progressSaver = progressSaver;
        }

        public async void Enter()
        {
            ClearProgressObjectsList();

            IntializeSceneConfig();

            SpawnEnemies();

            await InitializeHeroAsync();

            LoadProgress();

            EnterState();

            Debug.Log("SCENE : Init");
        }

        private void ClearProgressObjectsList()
        {
            progressSaver.RemoveObjects();
        }

        private void LoadProgress()
        {
            progressSaver.LoadProgress();
        }

        private void EnterState()
        {
            sceneStateSwitcher.EnterState<ResearchSceneState>();
        }

        private void IntializeSceneConfig()
        {
            string sceneName = SceneManager.GetActiveScene().name;
            sceneConfig = configProvider.GetSceneConfig(sceneName);
        }

        private void SpawnEnemies()
        {
            EnemySpawner[] enemySpawner = GameObject.FindObjectsOfType<EnemySpawner>();

            for (int i = 0; i < enemySpawner.Length; i++)
            {
                enemySpawner[i].SpawnBoxerEnemy();
            }
        }

        private async Task InitializeHeroAsync()
        {
            inputService.IsEnabled = true;

            await gameFactory.CreateHeroAsync(sceneConfig.HeroSpawnPosition, Quaternion.identity);

            await gameFactory.CreateVirtualJoyStick();

            FollowCamera followCamera = await gameFactory.CreateFollowCamera();
            followCamera.SetTarget(gameFactory.HeroObject.transform);
        }

    }
    
}