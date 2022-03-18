using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DevTools : EditorWindow
{
    [MenuItem("Window/Dev Tools")]
    public static void Init() {
        GetWindow<DevTools>("Dev Tools");
    }

    void OnGUI() {
        if (!EditorApplication.isPlaying) {
            GUILayout.Label("Editor Mode");
            EditorSceneLoading();
        } else {
            GUILayout.Label("Runtime Mode");
            RuntimeSceneLoading();
        }
    }

    #region Fucking Mess
    #region Editor
    void EditorSceneLoading() {

    }
    #endregion
    #region Runtime
    void RuntimeSceneLoading() {

    }
    #endregion
    #endregion
}
