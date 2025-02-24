using Assets.CodeBase.Infrustructure.AssetsManagement;
using Assets.CodeBase.Infrustructure.DependencyInjection.DIContainer;
using CodeBase.Configs;
using CodeBase.GamePlay.Enemies;
using CodeBase.GamePlay.Hero;
using CodeBase.Infrastructure.Services.ProgressSavers;
using CodeBase.UI.Elements;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Factory
{
    public class GameFactory : IGameFactory
    {
        private IAssetsProvider assetsProvider;
        private DependencyInjectionContainer dIcontainer;
        private IConfigProvider configProvider;
        private IProgressSaver progressSaver;

        public GameFactory(IAssetsProvider assetsProvider, DependencyInjectionContainer dIcontainer, IConfigProvider configProvider, IProgressSaver progressSaver)
        {
            this.assetsProvider = assetsProvider;
            this.dIcontainer = dIcontainer;
            this.configProvider = configProvider;
            this.progressSaver = progressSaver;
        }

        public GameObject HeroObject {  get; private set; }

        public HeroHealth HeroHealth { get; private set; }
        public HeroGold HeroGold { get; private set; }

        public VirtualJoyStick VirtualJoyStick {  get; private set; }

        public FollowCamera FollowCamera {  get; private set; }

        public GameObject CreateHero(Vector3 position, Quaternion rotation)
        {
            GameObject heroPrefab = assetsProvider.GetPrefab<GameObject>(AssetsPath.HeroPrefabPath);
            HeroObject = dIcontainer.Instantiate(heroPrefab);

            HeroObject.transform.SetPositionAndRotation(position, rotation);

            HeroHealth = HeroObject.GetComponent<HeroHealth>();

            HeroGold = HeroObject.GetComponent<HeroGold>();

            progressSaver.AddObjects(HeroObject);

            return HeroObject;
        }

        public GameObject CreateEnemy(EnemyID enemyID, Vector3 position)
        {
            EnemyConfig enemyConfig = configProvider.GetEnemyConfig(enemyID);
            GameObject enemyPrefab = enemyConfig.EnemyPrefab;
            GameObject enemy = dIcontainer.Instantiate(enemyPrefab);

            enemy.transform.position = position;

            IEnemyConfigInstaller[] enemyConfigInstallers = enemy.GetComponentsInChildren<IEnemyConfigInstaller>();

            for (int i = 0; i < enemyConfigInstallers.Length; i++)
            {
                enemyConfigInstallers[i].InstallConfig(enemyConfig);
            }

            return enemy;   

        }

        public VirtualJoyStick CreateVirtualJoyStick()
        {
            GameObject virtualJoyStickPrefab = assetsProvider.GetPrefab<GameObject>(AssetsPath.VirtualJoyStickPrefabPath);
            VirtualJoyStick = dIcontainer.Instantiate(virtualJoyStickPrefab).GetComponent<VirtualJoyStick>();

            return VirtualJoyStick;
        }

        public FollowCamera CreateFollowCamera()
        {
            GameObject followCameraPrefab = assetsProvider.GetPrefab<GameObject>(AssetsPath.FollowCameraPrefabPath);
            FollowCamera = dIcontainer.Instantiate(followCameraPrefab).GetComponent<FollowCamera>();

            //FollowCamera.SetTarget(Hero.transform);

            return FollowCamera;
        }


    }
}