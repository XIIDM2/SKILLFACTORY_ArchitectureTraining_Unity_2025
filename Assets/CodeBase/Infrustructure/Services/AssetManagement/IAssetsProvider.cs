using Assets.CodeBase.Infrustructure.DependencyInjection;
using Assets.CodeBase.Infrustructure.DependencyInjection.DIContainer;
using UnityEngine;

namespace Assets.CodeBase.Infrustructure.AssetsManagement
{
    public interface IAssetsProvider : IService
    {
        T GetPrefab<T>(string prefabPath) where T : Object;
        T InstantiatePrefab<T>(string prefabPath) where T : Object;
    }
}