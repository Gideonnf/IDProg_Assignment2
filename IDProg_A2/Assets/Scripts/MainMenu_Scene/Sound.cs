using UnityEngine;

[System.Serializable]
public class Sound {

    public enum AUDIO_TYPE
    {
        AT_SOUND,
        AT_MUSIC
    }

    public string nameOfSound;
    [Range(0.0f, 1.0f)]
    public float volume;
    public bool loop;
    public AUDIO_TYPE audioType;

    [HideInInspector]
    public AudioSource source;
    public AudioClip clip;

}
