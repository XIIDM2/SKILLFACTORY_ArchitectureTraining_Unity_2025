using Assets.CodeBase.Infrustructure.AssetsManagement;
using Assets.CodeBase.Infrustructure.DependencyInjection;
using Assets.CodeBase.SceneStates;
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
        private ResearchSceneState researchSceneState;
        private BattleSceneState battleSceneState;
        private VictorySceneState victorySceneState;
        private DefeatSceneState defeatSceneState;

        [Inject]
        public void Construct(ISceneStateSwitcher sceneStateSwitcher, BoostrapperSceneState boostrapperSceneState, ResearchSceneState researchSceneState, BattleSceneState battleSceneState, VictorySceneState victorySceneState, DefeatSceneState defeatSceneState)
        {
            this.sceneStateSwitcher = sceneStateSwitcher;
            this.boostrapperSceneState = boostrapperSceneState;
            this.researchSceneState = researchSceneState;
            this.battleSceneState = battleSceneState;
            this.victorySceneState = victorySceneState;
            this.defeatSceneState = defeatSceneState;
        }

        public override void OnBindResolved()
        {
            InitSceneStateMachine();
        }

        private void InitSceneStateMachine()
        {
            sceneStateSwitcher.AddState(boostrapperSceneState);
            sceneStateSwitcher.AddState(researchSceneState);
            sceneStateSwitcher.AddState(battleSceneState);
            sceneStateSwitcher.AddState(victorySceneState);
            sceneStateSwitcher.AddState(defeatSceneState);

            sceneStateSwitcher.EnterState<BoostrapperSceneState>();
        }
    }
}
