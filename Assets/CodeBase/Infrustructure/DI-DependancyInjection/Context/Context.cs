using UnityEngine;

namespace Assets.CodeBase.Infrustructure.DependencyInjection
{
    public abstract class Context : MonoBehaviour
    {
        [SerializeField] protected MonoInstaller[] monoInstallers;
        [SerializeField] protected MonoBoostTrapper contextMonoBoostTrapper;

        protected void InstallBindings()
        {
            if (monoInstallers == null) return;

            for (int i = 0; i < monoInstallers.Length; i++)
            {
                monoInstallers[i]?.InstallBinding();
            }
        }

        protected void OnBindResolved()
        {
            contextMonoBoostTrapper?.OnBindResolved();
        }
    }
}