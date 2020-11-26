using UnityEngine;

//Class GlobalVars, to control variables between scenes.
public class GlobalVars : MonoBehaviour
{
    //Singleton.
    public static GlobalVars instance;

    //Variables
    public float musicVolume;
    public float fxVolume;

    public int bestScore;

    //On Awake, instance itself and if already exists replace it.
    //Also set variables to default values.
    void Awake()
    {
        if (instance == null)
        {
            musicVolume = 0.5f; //Music volume set to 50%.
            fxVolume = 0.75f; //FX volume set to 75%.
            bestScore = 0; //Best score set to 0.

            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
