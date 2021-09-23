using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuDifficultyText : MonoBehaviour
{
    [SerializeField] TMP_Text difficultyText;
    [SerializeField] [TextArea] string[] textStrings;

    public void SetText(int textIndex)
    {
        difficultyText.text = textStrings[textIndex];
    }
}
