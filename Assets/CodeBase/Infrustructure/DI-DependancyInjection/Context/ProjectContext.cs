using Assets.CodeBase.Infrustructure.DependencyInjection.DIContainer;
using System;
using UnityEngine;

namespace Assets.CodeBase.Infrustructure.DependencyInjection
{
    public class ProjectContext : Context
    {
        private static ProjectContext instance;

        private DependencyInjectionContainer dependencyInjectionContainer;

        public static bool Initialized => instance != null;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;

                CreateDIContainer();

                InjectToInstallers(monoInstallers);

                InstallBindings();

                InjectToGameObject(gameObject);

                OnBindResolved();

                DontDestroyOnLoad(this);

                return;
            }

            Destroy(gameObject);
        }

        private void CreateDIContainer()
        {
            dependencyInjectionContainer = new DependencyInjectionContainer();
            dependencyInjectionContainer.RegisterService(dependencyInjectionContainer);
        }

        public static void InjectToGameObject(GameObject gameObject)
        {
            instance.dependencyInjectionContainer.InjectToGameObject(gameObject);
        }

        public static void InjectToAllMonoBehaviours()
        {
            instance.dependencyInjectionContainer.InjectToAllMonoBehaviours();
        }

        public static void InjectToInstallers(MonoInstaller[] monoInstallers)
        {
            for (int i = 0; i < monoInstallers.Length; i++)
            {
                instance.dependencyInjectionContainer.InjectToMonoBehaviour(monoInstallers[i]);
            }
        }
    }
}