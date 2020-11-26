using UnityEngine;

//Class Audio, which contains all necesary info of a song or sound.
[System.Serializable]
public class Audio
{
    //Variables.
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume = 1;
    [Range(.1f, 3f)]
    public float pitch = 1;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
