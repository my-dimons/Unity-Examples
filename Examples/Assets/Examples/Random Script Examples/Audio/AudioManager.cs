using NUnit.Framework.Constraints;
using System;
using UnityEngine;



/// <summary>
/// Holds variables/functions for other audio scripts (Such as global volume)
/// </summary>
public static class AudioManager
{
    public class AudioVolumeType
    {
        public string audioName;

        [Range(0f, 1f)]
        public float volume;

        public AudioVolumeType(string name, float vol)
        {
            audioName = name;
            volume = vol;
        }
    }

    // To add more volume types, add more properties to this array and then update
    public enum AudioType
    {
        sfx,
        music,
        global
    }

    // test
    public AudioVolumeType[] volumes = new AudioVolumeType[] { AudioVolumeType("sfx", 1), AudioVolumeType("music", 1), AudioVolumeType("global", 1);

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
