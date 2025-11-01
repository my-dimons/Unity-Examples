using UnityEngine;

/*
 *  To play audio globally (same volume no matter what), use "PlayAudioClip()"
 *  To play audio spacialy (change volume and channel depending on location), use "PlaySpacialAudioClip()"
 */

public static class SFXManager
{
    private static readonly float DEFAULT_PITCH_VARIANCE = 0.1f;

    /// <summary>
    /// Plays an audio clip globaly (Not using spacial audio), at a set volume with a pitch variance (to feel less repetative)
    /// </summary>
    /// <param name="clip">Audio clip to play</param>
    /// <param name="volume">Volume to play audio clip at</param>
    /// <param name="pitchVariance">
    /// Random variance to make sound feel less repetative. 
    /// adds/subtracts a random pitch to the set audio clips pitch within the range of -pitchVariance, and pitchVariance 
    /// </param>
    public static void PlayAudioClip(AudioClip clip, float volume = 1, float pitchVariance = default)
    {
        if (pitchVariance == default) pitchVariance = DEFAULT_PITCH_VARIANCE;
    }

    /// <summary>
    /// Plays an audio clip spacialy (Changes volume and L/R volume channel based on location), at a certain volume with a pitch variance (to feel less repetative)
    /// </summary>
    /// <param name="clip">Audio clip to play</param>
    /// <param name="position">Position to play audio clip at</param>
    /// <param name="volume">Volume to play audio clip at</param>
    /// <param name="pitchVariance">
    /// Random variance to make sound feel less repetative. 
    /// adds/subtracts a random pitch to the set audio clips pitch within the range of -pitchVariance, and pitchVariance 
    /// </param>
    public static void PlaySpacialAudioClip(AudioClip clip, Vector3 position, float volume = 1, float pitchVariance = default)
    {
        if (pitchVariance == default) pitchVariance = DEFAULT_PITCH_VARIANCE;
    }

    private static void PlayClip(AudioClip clip, float volume, float pitchVariance, Vector3 position = default)
    {
        GameObjec temporaryGameObject = new("Audio Clip (Temporary)");
        temporaryGameObject.transform.parent = null;

        // set to global or spacial audio
        if (position = default)
        {
            temporaryGameObject.transform.position = Camera.main.transform.position;
            audioSource.spatialBlend = 0f; // 2D sound
        } 
        else
        {
            temporaryGameObject.transform.position = position;
            audioSource.spatialBlend = 1f; // 3D sound
        }

        // Set up AudioSource
        AudioSource audioSource = temporaryGameObject.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.volume = AudioManager.GetVolumeBasedOnType(volume, AudioManager.VolumeTypes.sfx);

        float randomPitch = Random.Range(1 - pitchVariance, 1 + pitchVariance);
        audioSource.pitch = randomPitch;

        audioSource.Play();


        float destroyTime = clip.length / audioSource.pitch;
        Destroy(temporaryGameObject, destroyTime);
    }
}
