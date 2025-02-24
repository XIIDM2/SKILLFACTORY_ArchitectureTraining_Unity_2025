using CodeBase.Infrastructure.Services.Factory;
using Assets.CodeBase.Infrustructure.DependencyInjection.DIContainer;
using CodeBase.Infrastructure.StateMachines;
using CodeBase.Infrastructure.Services.SceneStates;
using Assets.CodeBase.SceneStates;

namespace CodeBase.Infrastructure.SceneStates
{
    public class BattleSceneState : IEnterableState, ITickableState, IService
    {
        private IGameFactory gameFactory;
        private ISceneStateSwitcher sceneStateSwitcher;
        private EnemiesInBattleRange enemiesInBattleRange;

        public BattleSceneState(IGameFactory gameFactory, ISceneStateSwitcher sceneStateSwitcher, EnemiesInBattleRange enemiesInBattleRange)
        {
            this.gameFactory = gameFactory;
            this.sceneStateSwitcher = sceneStateSwitcher;
            this.enemiesInBattleRange = enemiesInBattleRange;
        }

        public void Enter()
        {
            gameFactory.HeroHealth.Death += OnHeroDeath;
        }

        public void Exit()
        {
            gameFactory.HeroHealth.Death -= OnHeroDeath;
        }

        public void Tick()
        {
            if (!enemiesInBattleRange.HeroInBattle)
            {
                sceneStateSwitcher.EnterState<ResearchSceneState>();
            }
        }

        private void OnHeroDeath()
        {
            sceneStateSwitcher.EnterState<DefeatSceneState>();
        }
    }
}