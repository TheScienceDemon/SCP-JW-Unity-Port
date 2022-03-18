using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton { get; private set; }

    public bool IsGameRunning { get; private set; }

    public string SaveName { get; private set; }
    public int GameSeed { get; private set; }
    public Difficultys GameDifficulty { get; private set; }

    void Awake() {
        if (Singleton == null) {
            Singleton = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy() => SceneManager.sceneLoaded -= OnSceneLoaded;

    void OnSceneLoaded(Scene scene, LoadSceneMode loadMode) {
        IsGameRunning = scene.buildIndex == (int)SceneIndexes.Facility;
    }

    public void SetSaveName(string newName) {
        if (IsGameRunning) { return; }

        SaveName = newName;
    }

    public void SetGameSeed(string newSeed) {
        if (IsGameRunning) { return; }

        GameSeed = int.TryParse(newSeed, out int _newSeed)
            ? _newSeed
            : Random.Range(int.MinValue, int.MaxValue);
    }

    public void SetGameDifficulty(int newDifficultyIndex) {
        if (IsGameRunning) { return; }

        GameDifficulty = (Difficultys)newDifficultyIndex;
    }
}
