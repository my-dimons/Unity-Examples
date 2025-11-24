using System;
using UnityEngine;


/*
 * This is a static class, do not add it to any objects 
 *
 * TO CREATE MORE AUDIO TYPES
 * ---
 * 1. Add a new properaty to the 'AudioType' enum below
 * 2. Add a new custom volume variable like the ones below
 * 3. Add another condition to the 'CalculateVolumeBasedOnType(float volume, AudioType audioType)' switch function
 * 
 * Requires the BackgroundMusicManager.cs and SfxManager.cs scripts to work properly
 */

/// <summary>
/// Holds variables/functions for other audio scripts (Such as global volume)
/// </summary>
public static class AudioManager
{
    // To add more volume types, add more properties to this array and then update
    public enum AudioType
    {
        sfx,
        music,
        global
    }

    [Header("Audio Volumes")]

    [Range(0f, 1f)]
    [Tooltip("All volume is multiplied by this value")]
    public static float globalVolume = 1;

    [Space(8)]

    [Range(0f, 1f)]
    [Tooltip("Music volume is multiplied by this value")]
    public static float musicVolume = 1;

    [Range(0f, 1f)]
    [Tooltip("SFX volume is multiplied by this value")]
    public static float sfxVolume = 1;

    //[Space(8)]

    /*
     * Custom volumes here!
     */
     
    /// <summary>
    /// Does multiplication to volume types to the get right audio levels
    /// </summary>
    public static float CalculateVolumeBasedOnType(float volume, AudioType audioType) => audioType switch
    {
        AudioType.sfx => MultiplyByGlobalVolume(volume) * sfxVolume,
        AudioType.music => MultiplyByGlobalVolume(volume) * musicVolume,
        AudioType.global => MultiplyByGlobalVolume(volume),
        _ => MultiplyByGlobalVolume(volume),
    };

    private static float MultiplyByGlobalVolume(float volume) => volume * globalVolume;

    /// <summary>
    /// Calculates the effective playback duration of an audio clip after adjusting for pitch
    /// </summary>
    public static float CalculateClipLength(float clipLength, float pitch) => clipLength / Math.Abs(pitch);

    /// <summary>
    /// Calculates the pitch adjustment factor needed to play an audio clip at a specified duration
    /// </summary>
    public static float CalculateClipPitchWithLength(float clipLength, float time) => clipLength * time;
}
