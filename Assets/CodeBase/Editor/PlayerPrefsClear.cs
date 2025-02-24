using UnityEditor;
using UnityEngine;


public class PlayerPrefsClear
{
    [MenuItem("Tools/PlayerPrefs/ClearPlayerPrefs")]
    private static void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }
}
