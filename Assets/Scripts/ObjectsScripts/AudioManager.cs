using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public AudioPlayer audioPlayer;

    // Start is called before the first frame update
    void Start()
    {
        audioPlayer.Instatiate();
    }
    /// <summary>
    /// Play the first sound for array (use when using only one sound)
    /// </summary>
    public void PlaySound()
    {
        audioPlayer.PlaySound();
    }
    /// <summary>
    /// Play sound with specified name
    /// </summary>
    /// <param name="soundName">Name you assigned to sound in the inspector</param>
    public void PlaySound(string soundName)
    {
        audioPlayer.PlaySound(soundName);
    }
    /// <summary>
    /// Use it if you have multiple sounds on object and you want to play random one
    /// </summary>
    public void PlayRandom()
    {
        audioPlayer.PlayRandom();
    }
}

[Serializable]
public class AudioPlayer
{
    [Tooltip("Put blanck AudioSource here")] public AudioSource audioSource;
    [Tooltip("This represents list of audio clips and the name you give them," +
        "if you plan to use just one sound - name doesn`t matter")]
    public List<Sound> sounds;

    Dictionary<string, AudioClip> sortedSounds;

    public void Instatiate()
    {
        sortedSounds = new Dictionary<string, AudioClip>();
        foreach (Sound sound in sounds)
        {
            sortedSounds.Add(sound.name, sound.clip);
        }
    }
    public void PlaySound()
    {
        if (audioSource.isPlaying) return;

        ValidateCurrentClip(sounds[0].clip);
        audioSource.Play();
    }
    public void PlaySound(string soundName)
    {
        if (audioSource.isPlaying) return;

        if (sortedSounds.TryGetValue(soundName, out AudioClip clip))
        {
            ValidateCurrentClip(clip);
            audioSource.Play();
        }
    }
    public void PlayRandom()
    {
        if (audioSource.isPlaying) return;

        int randomIndex = UnityEngine.Random.Range(0, sounds.Count);

        ValidateCurrentClip(sounds[randomIndex].clip);
        audioSource.Play();
    }
    /// <summary>
    /// Check if clip you want to play is already assigned to audioPlayer
    /// </summary>
    /// <param name="clip"></param>
    void ValidateCurrentClip(AudioClip clip)
    {
        if (audioSource.clip != clip)
        {
            audioSource.clip = clip;
        }
    }
}
[Serializable]
public class Sound
{
    public string name;
    [Tooltip("Sound you want to be played")] public AudioClip clip;
}
