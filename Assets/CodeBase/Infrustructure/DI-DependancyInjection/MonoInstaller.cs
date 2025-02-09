using Assets.CodeBase.Infrustructure.DependencyInjection.DIContainer;
using UnityEngine;

namespace Assets.CodeBase.Infrustructure.DependencyInjection
{
    public abstract class MonoInstaller : MonoBehaviour
    {
        protected DependencyInjectionContainer DependencyInjectioncontainer;

        [Inject]
        public void Construct(DependencyInjectionContainer DIcontainer)
        {
            DependencyInjectioncontainer = DIcontainer;
        }

        public virtual void InstallBinding()
        {
            
        }
    }
}
