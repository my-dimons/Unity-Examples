using NUnit.Framework.Constraints;
using System;
using UnityEngine;

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
    [Range(0f, 1f)]
    [Tooltip("All volume is multiplied by this value")]
    public static float globalVolume;

    [Space(8)]

    [Range(0f, 1f)]
    [Tooltip("Music volume is multiplied by this value")]
    public static float musicVolume;

    [Range(0f, 1f)]
    [Tooltip("SFX volume is multiplied by this value")]
    public static float sfxVolume;

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
}
