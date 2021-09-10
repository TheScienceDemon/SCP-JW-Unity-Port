using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadingScreenManager : MonoBehaviour
{
    [SerializeField] GameObject loadingScreen;
    [SerializeField] Slider loadingBar;
    [SerializeField] TMP_Text loadingbarText;

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(loadAsync(sceneIndex));
    }

    IEnumerator loadAsync(int sceneIndex)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);
        while (!asyncOperation.isDone)
        {
            float progress = Mathf.Clamp01(asyncOperation.progress / .9f);
            loadingBar.value = progress;
            loadingbarText.text = (progress * 100).ToString("F0") + "%";

            yield return null;
        }
    }
}
