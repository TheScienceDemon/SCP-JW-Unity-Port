using TMPro;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] TMP_Text infoText;

    void Start() {
        infoText.text = $"v{Application.version}\nRunning on Unity {Application.unityVersion}";
    }

    #region New Save Settings
    public void SetSaveName(string newName) =>
        GameManager.Singleton.SetSaveName(newName);

    public void SetGameSeed(string newSeed) =>
        GameManager.Singleton.SetGameSeed(newSeed);

    public void SetGameDifficulty(int newDifficultyIndex) =>
        GameManager.Singleton.SetGameDifficulty(newDifficultyIndex);
    #endregion

    public void QuitApp() {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
