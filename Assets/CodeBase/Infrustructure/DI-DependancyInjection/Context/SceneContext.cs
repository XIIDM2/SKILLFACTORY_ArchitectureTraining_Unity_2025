using UnityEngine;

namespace Assets.CodeBase.Infrustructure.DependencyInjection
{
    [DefaultExecutionOrder(-10000)]
    public class SceneContext : Context
    {
        private void Awake()
        {
            ProjectContextFactory.TryCreate();

            ProjectContext.InjectToInstallers(monoInstallers);

            InstallBindings();

            ProjectContext.InjectToAllMonoBehaviours();

            OnBindResolved();

        }
    }
}
