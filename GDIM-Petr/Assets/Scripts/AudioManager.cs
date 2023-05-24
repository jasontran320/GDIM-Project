using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    //This is to make sure we only have one instance of the audio manager between scenes
    public static AudioManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        //If audio manager does not exist in scene then create instance else Destroy/remove object
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }

        // Allow for audio manager to persit between scenes
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        
    }

    private void Start() 
    {
        AudioManager.instance.Play("BG Music");
    }

    public void Play (string name)
    {
        Sound s = System.Array.Find(sounds, Sound => Sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
            

        s.source.Play();
    }

    public void Volume(string name, float newVolume)
    {
        Sound s = System.Array.Find(sounds, Sound => Sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.volume = newVolume;
        s.source.volume = s.volume;
    }

    public void Pause(string name, bool pause)
    {
        Sound s = System.Array.Find(sounds, Sound => Sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        if (pause)
            s.source.Pause();
        else
            s.source.UnPause();
    }
    
}
