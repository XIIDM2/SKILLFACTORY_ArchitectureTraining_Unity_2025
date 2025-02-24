
using CodeBase.Configs;
using CodeBase.GamePlay;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneConfigSynchronizer
{
    [InitializeOnLoadMethod]
    public static void SychronizeSceneConfig()
    {
        EditorSceneManager.sceneSaving += OnSceneSaving;
    }

    private static void OnSceneSaving(Scene scene, string path)
    {

        SceneConfig[] sceneConfigs = Resources.LoadAll<SceneConfig>("Configs/Scenes");

        if (sceneConfigs != null)
        {
            SceneConfig sceneConfig = null;

            foreach (SceneConfig config in sceneConfigs)
            {
                if (config.SceneName == scene.name)
                {
                    sceneConfig = config;
                    break;
                }
            }

            if (sceneConfig != null)
            {

                SerializedObject serializedConfig = new(sceneConfig);
                serializedConfig.FindProperty("HeroSpawnPosition").vector3Value = GameObject.FindObjectOfType<HeroSpawnPoint>().transform.position;
                serializedConfig.FindProperty("FinishPosition").vector3Value = GameObject.FindObjectOfType<FinishPoint>().transform.position;

                serializedConfig.ApplyModifiedProperties();

                Debug.Log($"Конфиг сцены {scene.name} синхронизирован");

            }
        }

    }
}
