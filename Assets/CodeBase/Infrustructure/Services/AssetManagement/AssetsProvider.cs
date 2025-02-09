using UnityEngine;

namespace Assets.CodeBase.Infrustructure.AssetsManagement
{
    public class AssetsProvider : IAssetsProvider
    {
        public T GetPrefab<T>(string prefabPath) where T : Object
        {
            return Resources.Load<T>(prefabPath);
        }

        public T InstantiatePrefab<T>(string prefabPath) where T : Object
        {
            T obj = Resources.Load<T>(prefabPath);
            return GameObject.Instantiate(obj);
        }
    }
}