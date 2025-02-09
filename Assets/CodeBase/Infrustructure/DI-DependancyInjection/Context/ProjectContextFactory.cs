using UnityEngine;

namespace Assets.CodeBase.Infrustructure.DependencyInjection
{
    public class ProjectContextFactory : MonoBehaviour
    {
        private static readonly string ProjectContextResourcePath = "ProjectContext";

        public static void TryCreate()
        {
            if (ProjectContext.Initialized) return;

            ProjectContext projectContextPrefab = TryGetPrefab();

            if (projectContextPrefab != null)
            {
                GameObject.Instantiate(projectContextPrefab);
            }
        }

        private static ProjectContext TryGetPrefab()
        {
            var prefabs = Resources.LoadAll<ProjectContext>(ProjectContextResourcePath);

            if (prefabs.Length > 0)
            {
                return prefabs[0];
            }

            return null;
        }
    }
}