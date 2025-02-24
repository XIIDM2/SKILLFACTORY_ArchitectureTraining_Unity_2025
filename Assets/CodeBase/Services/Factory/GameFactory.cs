using Assets.CodeBase.Infrustructure.AssetsManagement;
using Assets.CodeBase.Infrustructure.DependencyInjection.DIContainer;
using CodeBase.Configs;
using CodeBase.GamePlay.Enemies;
using CodeBase.GamePlay.Hero;
using CodeBase.Infrastructure.Services.ProgressSavers;
using CodeBase.UI.Elements;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

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

        public async Task<GameObject> CreateHeroAsync(Vector3 position, Quaternion rotation)
        {

            HeroObject = await InstantiateAndInject(AssetsAdress.HeroPrefabAdress);

            HeroObject.transform.SetPositionAndRotation(position, rotation);

            HeroHealth = HeroObject.GetComponent<HeroHealth>();

            HeroGold = HeroObject.GetComponent<HeroGold>();

            progressSaver.AddObjects(HeroObject);

            return HeroObject;
        }

        public async Task<GameObject> CreateEnemy(EnemyID enemyID, Vector3 position)
        {
            EnemyConfig enemyConfig = configProvider.GetEnemyConfig(enemyID);
            AsyncOperationHandle<GameObject> handle = Addressables.LoadAssetAsync<GameObject>(enemyConfig.EnemyPrefabReference);
            GameObject enemyPrefab = await handle.Task;

            GameObject enemy = dIcontainer.Instantiate(enemyPrefab);

            Addressables.Release(handle);

            enemy.transform.position = position;

            IEnemyConfigInstaller[] enemyConfigInstallers = enemy.GetComponentsInChildren<IEnemyConfigInstaller>();

            for (int i = 0; i < enemyConfigInstallers.Length; i++)
            {
                enemyConfigInstallers[i].InstallConfig(enemyConfig);
            }

            return enemy;   

        }

        public async Task<VirtualJoyStick> CreateVirtualJoyStick()
        {
            GameObject virtualJoyStickPrefab = await InstantiateAndInject(AssetsAdress.VirtualJoyStickPrefabAdress);
            VirtualJoyStick = virtualJoyStickPrefab.GetComponent<VirtualJoyStick>();

            return VirtualJoyStick;
        }

        public async Task<FollowCamera> CreateFollowCamera()
        {
            GameObject followCameraPrefab = await InstantiateAndInject(AssetsAdress.FollowCameraPrefabAdress);
            FollowCamera = followCameraPrefab.GetComponent<FollowCamera>();

            //FollowCamera.SetTarget(Hero.transform);

            return FollowCamera;
        }

        private async Task<GameObject> InstantiateAndInject(string adress)
        {
            AsyncOperationHandle<GameObject> handle = Addressables.LoadAssetAsync<GameObject>(adress);

            GameObject prefab = await handle.Task;

            GameObject gameObjectToInstantiate = dIcontainer.Instantiate(prefab);

            Addressables.Release(handle);

            return gameObjectToInstantiate;
        }
    }
}