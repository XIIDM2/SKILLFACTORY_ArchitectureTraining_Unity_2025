using Assets.CodeBase.Configs.Scene;
using Assets.CodeBase.Infrustructure.DependencyInjection.DIContainer;
using CodeBase.Configs;
using CodeBase.GamePlay.Enemies;
using CodeBase.UI.Elements;

public interface IConfigProvider : IService
{
    int ScenesAmount { get; }

    EnemyConfig GetEnemyConfig(EnemyID enemyID);
    WindowConfig GetWindowConfig(WindowID windowID);
    SceneConfig GetSceneConfig(int index);
    SceneConfig GetSceneConfig(string sceneName);
    void Load();
}