using Assets.CodeBase.Infrustructure.DependencyInjection;
using Assets.CodeBase.Infrustructure.DependencyInjection.DIContainer;
using Assets.CodeBase.SceneStates;
using CodeBase.GamePlay;
using CodeBase.Infrastructure.SceneStates;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Factory;
using CodeBase.Infrastructure.Services.SceneStates;
using System.Collections;
using UnityEngine;

namespace Assets.CodeBase.Infrustructure
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private FinishPoint finishPoint;
        [SerializeField] private EnemiesInBattleRange enemiesInBattleRange;
        [SerializeField] private SceneStateMachineTicker sceneStateMachineTicker;
        public override void InstallBinding()
        {
            RegisterSceneServices();

            RegisterSceneStateMachine();

            Debug.Log("SCENE : Register Services");
        }

        private void RegisterSceneServices()
        {
            DependencyInjectioncontainer.RegisterService(enemiesInBattleRange);
            DependencyInjectioncontainer.RegisterService(sceneStateMachineTicker);

        }

        private void RegisterSceneStateMachine()
        {
            DependencyInjectioncontainer.RegisterService<ISceneStateSwitcher, SceneStateMachine>();
            DependencyInjectioncontainer.RegisterService<BoostrapperSceneState>();
            DependencyInjectioncontainer.RegisterService<ResearchSceneState>();
            DependencyInjectioncontainer.RegisterService<BattleSceneState>();
            DependencyInjectioncontainer.RegisterService<VictorySceneState>();
            DependencyInjectioncontainer.RegisterService<DefeatSceneState>();
        }

        private void OnDestroy()
        {
            DependencyInjectioncontainer.UnregisterService<EnemiesInBattleRange>();
            DependencyInjectioncontainer.UnregisterService<SceneStateMachineTicker>();

            DependencyInjectioncontainer.UnregisterService<ISceneStateSwitcher>();
            DependencyInjectioncontainer.UnregisterService<BoostrapperSceneState>();
            DependencyInjectioncontainer.UnregisterService<ResearchSceneState>();
            DependencyInjectioncontainer.UnregisterService<BattleSceneState>();
            DependencyInjectioncontainer.UnregisterService<VictorySceneState>();
            DependencyInjectioncontainer.UnregisterService<DefeatSceneState>();
        }
    }


}
