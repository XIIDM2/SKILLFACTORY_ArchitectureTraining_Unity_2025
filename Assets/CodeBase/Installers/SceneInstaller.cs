using Assets.CodeBase.Infrustructure.DependencyInjection;
using Assets.CodeBase.Infrustructure.DependencyInjection.DIContainer;
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
        [SerializeField] private HeroSpawnPoint spawnPoint;
        public override void InstallBinding()
        {
            RegisterSceneServices();

            RegisterSceneStateMachine();

            Debug.Log("SCENE : Register Services");
        }

        private void RegisterSceneServices()
        {
            DependencyInjectioncontainer.RegisterService(spawnPoint);

        }

        private void RegisterSceneStateMachine()
        {
            DependencyInjectioncontainer.RegisterService<ISceneStateSwitcher, SceneStateMachine>();
            DependencyInjectioncontainer.RegisterService<BoostrapperSceneState>();
        }

        private void OnDestroy()
        {
            DependencyInjectioncontainer.UnregisterService<HeroSpawnPoint>();

            DependencyInjectioncontainer.UnregisterService<ISceneStateSwitcher>();
            DependencyInjectioncontainer.UnregisterService<BoostrapperSceneState>();
        }
    }


}
