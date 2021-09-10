using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscordManager : MonoBehaviour
{
    public static DiscordManager Singleton { get; private set; }
    public Discord.Discord discord;

    /*
    void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    */

    // Start is called before the first frame update
    void Start()
    {
        discord = new Discord.Discord(884884423043067984, (System.UInt64)Discord.CreateFlags.Default);
        var activityManager = discord.GetActivityManager();
        Debug.Log(activityManager);
        var activity = new Discord.Activity
        {
            Details = "pog battling",
            State = "Test",
            Assets =
            {
                LargeImage = "logo",
                LargeText = "",
                SmallImage = "",
                SmallText = "",
            },
        };
        activityManager.UpdateActivity(activity, (res) =>
        {
            if (res == Discord.Result.Ok)
            {
                Debug.Log("Discord launched successfully");
            }
            else
            {
                Debug.LogError("Discord errored launching! : " + res);
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        discord.RunCallbacks();
    }
}
