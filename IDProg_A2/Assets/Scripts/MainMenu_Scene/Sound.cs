using UnityEngine;

[System.Serializable]
public class Sound {

    public string nameOfSound;
    [Range(0.0f, 1.0f)]
    public float volume;
    public bool loop;

    [HideInInspector]
    public AudioSource source;
    public AudioClip clip;

}
