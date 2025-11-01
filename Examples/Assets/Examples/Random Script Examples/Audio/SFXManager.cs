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
       
    }
}
