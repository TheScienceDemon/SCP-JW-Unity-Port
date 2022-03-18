using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(VideoPlayer))]
public class Loader : MonoBehaviour
{
    [SerializeField] Startup[] startups;

    int startupIndex = 0;
    bool isSkipping = false;

    AudioSource source;
    VideoPlayer player;

    void Start() {
        source = GetComponent<AudioSource>();
        player = GetComponent<VideoPlayer>();

        Startup firstStartup = startups[startupIndex];
        source.clip = firstStartup.sound;
        player.clip = firstStartup.video;

        source.Play();
        player.Play();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) || !player.isPlaying) {
            SkipToNext();
        }
    }

    void SkipToNext() {
        if (isSkipping) { return; }

        isSkipping = true;

        source.Stop();
        player.Stop();

        startupIndex++;

        if (startupIndex >= startups.Length) {
            LoadingScreen.Singleton.LoadScene((int)SceneIndexes.MainMenu);
            return;
        }

        Startup newStartup = startups[startupIndex];
        source.clip = newStartup.sound;
        player.clip = newStartup.video;

        source.Play();
        player.Play();

        isSkipping = false;
    }

    [System.Serializable]
    struct Startup {
        public string label;
        public VideoClip video;
        public AudioClip sound;
    }
}
