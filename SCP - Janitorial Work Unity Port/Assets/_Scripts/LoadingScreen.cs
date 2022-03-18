using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public static LoadingScreen Singleton { get; private set; }

    [SerializeField] GameObject canvasObj;
    [SerializeField] Slider progressBarSlider;
    [SerializeField] LocalizedString progressBarString;
    [SerializeField] TMP_Text progressBarText;
    [SerializeField] Image hintImage;
    [SerializeField] TMP_Text hintText;

    [SerializeField] LoadingScreenHint[] loadingScreenHints;

    public float loadingProgress { get; private set; } = 0f;

    void Awake() {
        if (Singleton == null) {
            Singleton = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void LoadScene(int index) =>
        StartCoroutine(LoadSceneEnumerator(index));

    IEnumerator LoadSceneEnumerator(int sceneIndex) {
        progressBarSlider.value = 0f;
        hintText.text = string.Empty;
        loadingProgress = 0f;

        int hintIndex = Random.Range(0, loadingScreenHints.Length);
        var asyncScene = SceneManager.LoadSceneAsync(sceneIndex);

        canvasObj.SetActive(true);

        LoadingScreenHint hint = loadingScreenHints[hintIndex];
        hintImage.sprite = hint.hintImage;
        hintImage.SetNativeSize();
        hintText.text = hint.hintText.GetLocalizedString();

        do {
            loadingProgress = Mathf.Clamp01(asyncScene.progress / .9f);

            progressBarSlider.value = loadingProgress;
            progressBarText.text = progressBarString.GetLocalizedString();

            yield return null;
        } while (!asyncScene.isDone);

        canvasObj.SetActive(false);
    }

    [System.Serializable]
    struct LoadingScreenHint {
        public string hintLabel;
        public LocalizedString hintText;
        public Sprite hintImage;
    }
}
