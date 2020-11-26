using System;
using UnityEngine;

//Class AudioManager, that controls all audio in the game.
public class AudioManager : MonoBehaviour
{
    //Singleton.
    public static AudioManager instance;

    //Variables.
    public Audio[] music;
    public Audio[] sounds;

    //On Awake, instance itselft and if there is another, destroy it.
    //Then, set to don't destroy on load.
    //Also get all the data from the sounds.
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach (Audio s in music)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        foreach (Audio s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    //On start, play the main theme.
    void Start()
    {
        ManageAudio("menu", "music", "play");
    }

    //Function ManageAudio, to play, stop, pause or unpause any audio.
    public void ManageAudio(string name, string type, string action)
    {
        //Depending if type is music or sound, it will search the audio on one array or the other.
        if (type == "music")
        {
            Audio s = Array.Find(music, sound => sound.name == name);
            if (s == null)
            {
                Debug.LogWarning("Sound: " + name + " not found!");
                return;
            }
            if (action == "play")
                s.source.Play();
            else if (action == "stop")
                s.source.Stop();
            else if (action == "pause")
                s.source.Pause();
            else if (action == "unpause")
                s.source.UnPause();
        }
        else if (type == "sound")
        {
            Audio s = Array.Find(sounds, sound => sound.name == name);
            if (s == null)
            {
                Debug.LogWarning("Sound: " + name + " not found!");
                return;
            }
            if (action == "play")
                s.source.Play();
            else if (action == "stop")
                s.source.Stop();
            else if (action == "pause")
                s.source.Pause();
            else if (action == "unpause")
                s.source.UnPause();
        }
    }
}
