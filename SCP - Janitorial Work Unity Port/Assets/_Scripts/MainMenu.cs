using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] TMP_Text bottomLeftText;

    // Start is called before the first frame update
    void Start()
    {
        bottomLeftText.text = "v" + Application.version + "\n" + "Running on Unity " + Application.unityVersion;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
