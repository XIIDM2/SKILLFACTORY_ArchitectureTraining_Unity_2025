using CodeBase.GamePlay.UI.Services;
using CodeBase.UI.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.CodeBase.Configs.Scene
{
    [CreateAssetMenu(fileName = "WindowConfig", menuName = "Configs/Window")]
    public class WindowConfig : ScriptableObject
    {
        public WindowID windowID;
        public string windowTitle;
        public GameObject windowPrefab;
    }
}
