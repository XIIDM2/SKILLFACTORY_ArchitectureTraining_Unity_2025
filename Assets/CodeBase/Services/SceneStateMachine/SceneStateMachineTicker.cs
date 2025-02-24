using Assets.CodeBase.Infrustructure.DependencyInjection;
using Assets.CodeBase.Infrustructure.DependencyInjection.DIContainer;
using CodeBase.Infrastructure.Services.SceneStates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Infrastructure.SceneStates
{
    public class SceneStateMachineTicker : MonoBehaviour, IService
    {
        private ISceneStateSwitcher sceneStateSwitcher;

        [Inject]
        public void Construct(ISceneStateSwitcher sceneStateSwitcher)
        {
            this.sceneStateSwitcher = sceneStateSwitcher;
        }

        private void Update()
        {
            sceneStateSwitcher.UpdateTick();

            Debug.Log(sceneStateSwitcher.CurrentState.ToString());
        }

    }
}