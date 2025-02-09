using Assets.CodeBase.Infrustructure.AssetsManagement;
using Assets.CodeBase.Infrustructure.DependencyInjection;
using Assets.CodeBase.Infrustructure.DependencyInjection.DIContainer;
using CodeBase.Infrastructure.Services.Factory;
using CodeBase.Infrastructure.StateMachines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Infrastructure.SceneStates
{
    public class BoostrapperSceneState : IEnterableState, IService
    {
        private IGameFactory gameFactory;
        private HeroSpawnPoint heroSpawnPoint;


        public BoostrapperSceneState(IGameFactory gameFactory, HeroSpawnPoint heroSpawnPoint)
        {
            this.gameFactory = gameFactory;
            this.heroSpawnPoint = heroSpawnPoint;
        }

        public void Enter()
        {

            InitializeHero();

            Debug.Log("SCENE : Init");
        }

        private void InitializeHero()
        {

            gameFactory.CreateHero(heroSpawnPoint.transform.position, heroSpawnPoint.transform.rotation);
            gameFactory.CreateVirtualJoyStick();
            gameFactory.CreateFollowCamera().SetTarget(gameFactory.Hero.transform);
        }

    }
    
}