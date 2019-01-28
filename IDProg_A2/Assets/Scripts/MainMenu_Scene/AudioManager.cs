using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    // Static Instance
    private static AudioManager m_Instance;
    public static AudioManager GetInstance()
    {
        return m_Instance;
    }

    // Array to Store all the Sounds Clips
    [SerializeField]
    private Sound[] sounds;


    private void Awake()
    {
        // Attach Instance
        if(m_Instance == null)
          m_Instance = this;
        else
        {
            // If already have one AudioManager
            // Destroy this new gameObject
            Destroy(gameObject);
            return;
        }

        // Create a Sound Source for each sound clip
        // Attached..
        for(int index = 0; index < sounds.Length; ++index)
        {
            sounds[index].source = gameObject.AddComponent<AudioSource>();
            sounds[index].source.clip = sounds[index].clip;

            sounds[index].source.volume = sounds[index].volume;
            sounds[index].source.loop = sounds[index].loop;
        }

        // Don't Destroy on loading Next Scene
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
        PlaySound("BGMusic");
    }
	
	
    // Play Sounds
    public void PlaySound(string selectedSound)
    {
        Sound s = Array.Find(sounds, sound => sound.nameOfSound == selectedSound);

        // if cannot find
        if (s == null)
            return;
        // if already playing
        if (s.source.isPlaying)
            return;

        // Play the Sound
        s.source.Play();
    }
    // Stop Sound
    public void StopSound(string selectedSound)
    {
        Sound s = Array.Find(sounds, sound => sound.nameOfSound == selectedSound);

        // if cannot find
        if (s == null)
            return;
        // if not playing
        if (!s.source.isPlaying)
            return;

        // Stop the Sound
        s.source.Stop();
    }
}
