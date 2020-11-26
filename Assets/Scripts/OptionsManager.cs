using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Class OptionsManager, to control the options on each scene.
public class OptionsManager : MonoBehaviour
{
    //Singleton.
    public static OptionsManager instance;

    //Variables.
    public Slider musicSlider;
    public Slider fxSlider;

    public float musicVolume;
    public float fxVolume;

    //On Start, get the options from GlobalVars.
    void Start()
    {
        instance = this;

        musicVolume = GlobalVars.instance.musicVolume;
        fxVolume = GlobalVars.instance.fxVolume;

        //if (SceneManager.GetActiveScene().name.Equals("Menu"))
        //{
        //    musicSlider.value = musicVolume;
        //    fxSlider.value = fxVolume;
        //}
    }

    //Set the music volume.
    public void SetMusicVolume(float volume)
    {
        musicVolume = volume;
        GlobalVars.instance.musicVolume = musicVolume;
        foreach (Audio s in AudioManager.instance.music)
        {
            s.source.volume = musicVolume;
        }
    }

    //Set the FX volume.
    public void SetFXVolume(float volume)
    {
        fxVolume = volume;
        GlobalVars.instance.fxVolume = fxVolume;
        foreach (Audio s in AudioManager.instance.sounds)
        {
            s.source.volume = fxVolume;
        }
    }

    //Change the scene.
    public void GoToScene(string scene)
    {
            SceneManager.LoadScene(scene);
    }

    //Play the button sound.
    public void PressButton()
    {
        AudioManager.instance.ManageAudio("button", "sound", "play");
    }
}
