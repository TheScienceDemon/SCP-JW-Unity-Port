using UnityEngine;

public class DiscordManager : MonoBehaviour
{
    public static DiscordManager Singleton { get; private set; }

    Discord.Discord discord;

    void Awake() {
        if (Singleton == null) {
            Singleton = this;
            DontDestroyOnLoad(gameObject);
        } else
            Destroy(gameObject);
    }

    void Start() {
#if !UNITY_EDITOR
        discord = new Discord.Discord(884884423043067984, (ulong) Discord.CreateFlags.Default);

        var activityManager = discord.GetActivityManager();

        var activity = new Discord.Activity {
            Details = "Amog Us",
            State = "Finally testing again",
            Assets =
            {
                LargeImage = "logo",
                LargeText = "",
                SmallImage = "",
                SmallText = "",
            },
        };
        activityManager.UpdateActivity(activity, (res) => {
            if (res == Discord.Result.Ok)
            {
                Debug.Log("Discord launched successfully");
            }
            else
            {
                Debug.LogError("Discord errored launching! : " + res);
            }
        });
#endif
    }

#if !UNITY_EDITOR
    void Update() => discord.RunCallbacks();
#endif
}
