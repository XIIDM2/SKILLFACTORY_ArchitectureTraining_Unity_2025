using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Configs
{
    [CreateAssetMenu(fileName = "Scene_", menuName = "Configs/Scene")]
    public class SceneConfig : ScriptableObject
    {
        public string SceneName;
        public Vector3 HeroSpawnPosition;
        public Vector3 FinishPosition;
    }
}