using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
//Class GameController, that controls all game behaviours.
public class GameController : MonoBehaviour
{
    //Singleton.
    public static GameController instance;

    //Variables.
    private int fishes = 0;
    public TextMeshProUGUI fishCounterText;

   
    //public ParticleSystem ps;

    private float timeCounter;

    public bool gameOver = true;
    public GameObject ingameUI;
    public GameObject endGame;
    public TextMeshProUGUI[] finalTexts = new TextMeshProUGUI[4];

    
    //public GameObject boat;
    //public GameObject net;
    private float waitingTime = 2f;
    private bool[] conditions = new bool[4];
    //public GameObject generator;


    void Start()
    {
        endGame.SetActive(false);
        instance = this;
        Time.timeScale = 1;
        timeCounter = Time.time;
    }

    //Function TakeFish, to update the score.
    public void TakeFish()
    {
        fishes++;
        fishCounterText.text = "" + fishes;
        AudioManager.instance.ManageAudio("takeFish", "sound", "play");
    }

    public void TakeFish2()
    {
        fishes = fishes + 5;
        fishCounterText.text = "" + fishes;
        AudioManager.instance.ManageAudio("takeFish", "sound", "play");
    }

    //Function FinishGame, called when game ends.
    public void FinishGame(string crash)
    {
        //Stop the game.
        Time.timeScale = 0;
        gameOver = true;
        if(crash == "boat")
        AudioManager.instance.ManageAudio("boatCrack", "sound", "play");
        else if(crash == "ocean")
        AudioManager.instance.ManageAudio("splash", "sound", "play");

        //Save the time the player has been playing a match.
        timeCounter = Time.time - timeCounter;
        int seconds = (int)(timeCounter % 60);
        int minutes = (int)((timeCounter / 60) % 60);

        string timerString = string.Format("{0:0}:{1:00}", minutes, seconds);

        //Update the best score.
        if (fishes > GlobalVars.instance.bestScore)
            GlobalVars.instance.bestScore = fishes;

        //Update the texts in final screen.
        finalTexts[0].text = "END OF GAME";
        finalTexts[1].text = "SCORE: " + fishes + " (BEST: " + GlobalVars.instance.bestScore + ")";
        finalTexts[2].text = "TIME: " + timerString + ".";

        //Activate the endGame UI and deactivate in-game UI.
        ingameUI.SetActive(false);
        endGame.SetActive(true);
    }
}
