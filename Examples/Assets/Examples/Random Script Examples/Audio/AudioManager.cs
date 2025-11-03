using NUnit.Framework.Constraints;
using System;
using UnityEngine;

/// <summary>
/// Holds variables/functions for other audio scripts (Such as global volume)
/// </summary>
public static class AudioManager
{
    // To add more volume types, add more properties to this array and then update GetVolumeBasedOnType()
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
    public static float GetVolumeBasedOnType(float volume, AudioType audioType) => audioType switch
    {
        AudioType.sfx => MultiplyByGlobalVolume(volume) * sfxVolume,
        AudioType.music => MultiplyByGlobalVolume(volume) * musicVolume,
        AudioType.global => MultiplyByGlobalVolume(volume),
        _ => MultiplyByGlobalVolume(volume),
    };

    private static float MultiplyByGlobalVolume(float volume) => volume * globalVolume;
}

/// <summary>
/// Holds variables/functions for other audio scripts (Such as global volume), but is a singleton so it can be used in the unity editor
/// </summary>
/*public class AudioManagerObject : MonoBehaviour
{
    public class Testing
    {

    }
    public static AudioManagerObject Instance;

    private void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }
}*/
