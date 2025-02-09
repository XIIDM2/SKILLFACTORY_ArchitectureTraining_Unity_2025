using Assets.CodeBase.Infrustructure.AssetsManagement;
using Assets.CodeBase.Infrustructure.DependencyInjection.DIContainer;
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

        public GameFactory(IAssetsProvider assetsProvider, DependencyInjectionContainer dIcontainer)
        {
            this.assetsProvider = assetsProvider;
            this.dIcontainer = dIcontainer;
        }

        public GameObject Hero {  get; private set; }

        public VirtualJoyStick VirtualJoyStick {  get; private set; }

        public FollowCamera FollowCamera {  get; private set; }

        public GameObject CreateHero(Vector3 position, Quaternion rotation)
        {
            GameObject heroPrefab = assetsProvider.GetPrefab<GameObject>(AssetsPath.HeroPrefabPath);
            Hero = dIcontainer.Instantiate(heroPrefab);

            Hero.transform.SetPositionAndRotation(position, rotation);

            return Hero;
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