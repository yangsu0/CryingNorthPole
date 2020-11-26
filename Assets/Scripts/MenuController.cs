using UnityEngine;
using UnityEngine.SceneManagement;
//Class MenuController, to control the Menu behaviour.
public class MenuController : MonoBehaviour
{
    //Variables
    //public GameObject background;
    private float mousePosX, mousePosY;
    public float moveFactor;

    //On Start, set the timeScale to 1.
    //We do this because is set to 0 on GameController.FinishGame()
    //and we need to be 1 for Invoke function on Generation class.
    void Start()
    {
        Time.timeScale = 1;
    }

    //On Update, move the background depending on the mouse position and the move factor.
    //void Update()
    //{
    //    //Move the background.
    //    mousePosX = Input.mousePosition.x;
    //    mousePosY = Input.mousePosition.y;
    //    background.GetComponent<RectTransform>().position = new Vector2((mousePosX / Screen.width) * moveFactor - moveFactor, (mousePosY / Screen.height) * moveFactor - moveFactor);
    //}
}
