using Assets.CodeBase.Infrustructure.AssetsManagement;
using Assets.CodeBase.Infrustructure.DependencyInjection;
using CodeBase.Infrastructure.SceneStates;
using CodeBase.Infrastructure.Services.GameStates;
using CodeBase.Infrastructure.Services.SceneStates;
using System.Collections;
using UnityEngine;

namespace Assets.CodeBase.Infrustructure
{
    public class SceneBoostTrapper : MonoBoostTrapper
    {
        private ISceneStateSwitcher sceneStateSwitcher;
        private BoostrapperSceneState boostrapperSceneState;

        [Inject]
        public void Construct(ISceneStateSwitcher sceneStateSwitcher, BoostrapperSceneState boostrapperSceneState)
        {
            this.sceneStateSwitcher = sceneStateSwitcher;
            this.boostrapperSceneState = boostrapperSceneState;
        }

        public override void OnBindResolved()
        {
            InitSceneStateMachine();
        }

        private void InitSceneStateMachine()
        {
            sceneStateSwitcher.AddState(boostrapperSceneState);

            sceneStateSwitcher.EnterState<BoostrapperSceneState>();
        }
    }
}
