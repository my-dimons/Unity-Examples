using UnityEngine;
using System.Collections;

/*
 *
 * This script should be created in the main scene, and it will persist through all scenes
 * 
 * This script is designed to keep a set of predefined music tracks playing randomly in the background. 
 * It does not support dynamic soundtracks, such as changing music based on the player’s location or game events.
 * But this script does have a few functions to stop and start music
 * 
 * Sometimes this script will bug out if you don't have run in background enabled in Unity (https://discussions.unity.com/t/how-do-you-keep-your-game-running-even-when-you-switch-out-of-it/928)
 *
 */

public class BackgroundMusicManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip[] musicTracks;
    [Space(4)]
    public AudioClip currentPlayingTrack;
    [Space(8)]
    [Tooltip("Immedietely start playing music when this object loads in")]
    public bool playOnAwake = true;

    public float fadeTime;
    [Tooltip("If you want a single value cooldown, just set the values to the same value")]
    public Vector2 randomMilisecondCooldownBetweenSongs;

    public static BackgroundMusicManager Instance { get; private set; }

    public Coroutine playingMusicCoroutine;

    void Awake()
    {
        if (Instance == null) Instance = this; else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        if (playOnAwake)
            StartContinuousMusic();
            
    }

    private void Update()
    {
        if (musicSource != null)
            musicSource.volume = AudioManager.CalculateVolumeBasedOnType(1, AudioManager.AudioType.music);
    }

    private IEnumerator PlayMusicContinuously()
    {
        while (true)
        {
            PlaySingleRandomMusicTrack();

            Debug.Log("Clip Started");
            yield return new WaitWhile(() => musicSource.isPlaying);
            Debug.Log("Clip Ended");

            Debug.Log("Finished Music Clip");

            float waitTimeUntillNextSong = Random.Range(randomMilisecondCooldownBetweenSongs.x, randomMilisecondCooldownBetweenSongs.y);
            yield return new WaitForSecondsRealtime(waitTimeUntillNextSong);
        }
    }

    public void StopMusic()
    {
        if (Instance.musicSource.isPlaying)
        {
            Instance.musicSource.Stop();

            if (Instance.playingMusicCoroutine != null)
            {
                Instance.StopCoroutine(Instance.playingMusicCoroutine);
                Instance.playingMusicCoroutine = null;
            }
        }
    }

    public void StartContinuousMusic()
    {
        if (!Instance.musicSource.isPlaying && musicTracks.Length > 0)
            playingMusicCoroutine = StartCoroutine(PlayMusicContinuously());
        else if (musicTracks.Length > 0)
            Debug.LogWarning("No music tracks in MusicManager.cs");
        else if (!Instance.musicSource.isPlaying)
            Debug.LogWarning("Tried starting continuous music but music source is already playing!");
    }

    private void PlayMusicTrack(AudioClip clip)
    {
        musicSource.clip = clip;
        currentPlayingTrack = clip;

        musicSource.Play();

        Debug.Log($"Playing: {clip.name}");
    }

    public void PlaySingleRandomMusicTrack()
    {
        PlayMusicTrack(GetRandomSong());
    }

    public void PlaySpecificMusicTrack(AudioClip clip)
    {
        Instance.PlayMusicTrack(clip);
    }

    private AudioClip GetRandomSong()
    {
        int randomSongTrackIndex = Random.Range(0, musicTracks.Length);
        return musicTracks[randomSongTrackIndex];
    }
}
