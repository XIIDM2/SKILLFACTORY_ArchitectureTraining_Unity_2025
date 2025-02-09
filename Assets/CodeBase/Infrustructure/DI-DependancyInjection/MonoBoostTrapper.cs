using UnityEngine;

namespace Assets.CodeBase.Infrustructure.DependencyInjection
{
    public abstract class MonoBoostTrapper : MonoBehaviour
    {
        public abstract void OnBindResolved();       
    }
}
