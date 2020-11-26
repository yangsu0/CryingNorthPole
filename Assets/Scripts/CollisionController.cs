using UnityEngine;

//Clase CollisionController, to check collisions between boat and obstacles.
public class CollisionController : MonoBehaviour
{
    //On trigger enter, check what collided.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the boat or the net collides with an obstacle, finish the game.
        if ((transform.CompareTag("BoatAndStick") || transform.CompareTag("Net")) || collision.transform.CompareTag("Ocean") && collision.transform.CompareTag("Obstacle"))
        {
            if (transform.CompareTag("BoatAndStick"))
                GameController.instance.FinishGame("boat");
            else if (transform.CompareTag("Net"))
                GameController.instance.FinishGame("net");
            else if (transform.CompareTag("Ocean"))
                GameController.instance.FinishGame("ocean");
        }

        //If the net collides with a fish, call takeFish function from
        //GameController instance and delete the fish.
        if (transform.CompareTag("Net") && collision.transform.CompareTag("Fish"))
        {
            GameController.instance.TakeFish();
            Destroy(collision.gameObject);
        }
    }
}
