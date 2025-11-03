using UnityEngine;

/*
 *
 * This script takes an array and will randomly play each song after it's done playing.
 *
 * if not using play on awake you can manually start looping music from other scripts using the PlayMusic() function
 *
 */

public class MusicManager : MonoBehaviour
{
    public AudioClip[] music;
    [Space(8)]
    [Tooltip("Immedietely start playing music when this object loads in")]
    public bool playOnAwake = true;

    public float fadeTime;
    public float cooldownBetweenSongs;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayMusic();
    }

    /// <summary>
    /// Force play music
    /// </summary>
    public void PlayMusic()
    {

    }

    /// <summary>
    /// Plays one music clip
    /// </summary>
    public void PlayOneShotMusic()
    {

    }
    /// <summary>
    /// Force stop music
    /// </summary>
    public void StopMusic()
    {

    }
}
