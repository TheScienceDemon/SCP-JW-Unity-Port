using UnityEngine;

public class LoadingScreenButton : MonoBehaviour
{
    public void LoadScene(int buildIndex) =>
        LoadingScreen.Singleton.LoadScene(buildIndex);
}
