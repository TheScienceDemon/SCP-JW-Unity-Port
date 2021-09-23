using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameValues : MonoBehaviour
{
    public static GameValues Singleton { get; private set; }

    private void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public string gameName;
    public int gameSeed;
    public bool useIntro;
    public int gameDifficulty;

    public void SetName(string inputString)
    {
        gameName = inputString;
    }

    public void SetSeed(string inputString)
    {
        gameSeed = int.Parse(inputString);
    }

    public void SetIntro(bool inputBool)
    {
        useIntro = inputBool;
    }

    public void SetDifficulty(int inputInt)
    {
        gameDifficulty = inputInt;
    }
}
