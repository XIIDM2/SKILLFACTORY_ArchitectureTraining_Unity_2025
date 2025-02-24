using Assets.CodeBase.Infrustructure.DependencyInjection.DIContainer;
using CodeBase.Infrastructure.Services.Factory;
using CodeBase.Infrastructure.StateMachines;
using UnityEngine;
using CodeBase.Infrastructure.Services.SceneStates;
using CodeBase.GamePlay;
using CodeBase.Infrastructure.SceneStates;
using CodeBase.Configs;
using UnityEngine.SceneManagement;

namespace Assets.CodeBase.SceneStates
{
    public class ResearchSceneState : IEnterableState, IExitableState, ITickableState, IService
    {
        private readonly ISceneStateSwitcher sceneStateSwitcher;
        private readonly IGameFactory gameFactory;
        private readonly IConfigProvider configProvider;
        private readonly EnemiesInBattleRange enemiesInBattleRange;

        private SceneConfig sceneConfig;

        public ResearchSceneState(ISceneStateSwitcher sceneStateSwitcher, IGameFactory gameFactory, IConfigProvider configProvider, EnemiesInBattleRange enemiesInBattleRange)
        {
            this.sceneStateSwitcher = sceneStateSwitcher;
            this.gameFactory = gameFactory;
            this.configProvider = configProvider;
            this.enemiesInBattleRange = enemiesInBattleRange;
        }

        public void Enter()
        {
            gameFactory.HeroHealth.Death += OnHeroDeath;

            string sceneName = SceneManager.GetActiveScene().name;
            sceneConfig = configProvider.GetSceneConfig(sceneName);
        }

        public void Exit()
        {
            gameFactory.HeroHealth.Death -= OnHeroDeath;
        }

        public void Tick() 
        {
            if (enemiesInBattleRange.HeroInBattle)
            {
                sceneStateSwitcher.EnterState<BattleSceneState>();
            }
            else
            {
                if (Vector3.Distance(gameFactory.HeroObject.transform.position, sceneConfig.FinishPosition) < FinishPoint.Radius)
                {

                    sceneStateSwitcher.EnterState<VictorySceneState>();
                }
            }
        }

        private void OnHeroDeath()
        {
            sceneStateSwitcher.EnterState<DefeatSceneState>();
        }
    }
}