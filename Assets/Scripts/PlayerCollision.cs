using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour {

    public PlayerMovement movement;

    private void OnCollisionEnter(Collision collision) {

        //If the boat collides with an obstacle, finish the game.
        if (transform.CompareTag("BoatAndStick") && collision.transform.CompareTag("Obstacle"))
            GameController.instance.FinishGame("boat");
        else if (transform.CompareTag("BoatAndStick") && collision.transform.CompareTag("Ocean"))
            GameController.instance.FinishGame("ocean");
        else if (collision.transform.CompareTag("Final"))
        {
            GameController.instance.FinishGame("Finish");
        }
        //If the net collides with a fish, call takeFish function from
        //GameController instance and delete the fish.
        if (collision.transform.CompareTag("Fish"))
        {
            GameController.instance.TakeFish();
            Destroy(collision.gameObject);
        }
    }

   private void OnTriggerEnter(Collider collision) {
        //Get point according to the trash's color.
        if (collision.gameObject.CompareTag("Fish")) {
            collision.gameObject.SetActive(false);
            GameController.instance.TakeFish();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Fish2")) {
            collision.gameObject.SetActive(false);
            GameController.instance.TakeFish2();
            Destroy(collision.gameObject);
        }
    }
}
