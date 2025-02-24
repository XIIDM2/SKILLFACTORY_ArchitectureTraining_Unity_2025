using Assets.CodeBase.Configs.Scene;
using CodeBase.Configs;
using CodeBase.GamePlay.Enemies;
using CodeBase.UI.Elements;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ConfigProvider : IConfigProvider
{
    private const string EnemyConfigPath = "Configs/Enemies";
    private const string WindowConfigPath = "Configs/Windows";
    private const string SceneConfigPath = "Configs/Scenes";

    private Dictionary<EnemyID, EnemyConfig> enemies;
    private Dictionary<WindowID, WindowConfig> windows;
    private Dictionary<string, SceneConfig> scenes;

    private SceneConfig[] sceneList;

    public int ScenesAmount => sceneList.Length;

    public void Load()
    {
        enemies = Resources.LoadAll<EnemyConfig>(EnemyConfigPath).ToDictionary(x => x.enemyID, x => x);
        windows = Resources.LoadAll<WindowConfig>(WindowConfigPath).ToDictionary(x => x.windowID, x => x);

        sceneList = Resources.LoadAll<SceneConfig>(SceneConfigPath);
        scenes = sceneList.ToDictionary(x => x.SceneName, x => x);

    }

    public EnemyConfig GetEnemyConfig(EnemyID enemyID)
    {
        return enemies[enemyID];
    }

    public WindowConfig GetWindowConfig(WindowID windowID)
    {
        return windows[windowID];
    }

    public SceneConfig GetSceneConfig(int index)
    {
        return sceneList[index];
    }

    public SceneConfig GetSceneConfig(string sceneName)
    {
        return scenes[sceneName];
    }
}
