using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour {

    public PlayerMovement movement;

    private void OnCollisionEnter(Collision collision) {
        // if (collisionInfo.collider.tag == "Obstacle") {
        //     Debug.Log("We hit an obstacle");
        //     movement.enabled = false;
        // }
        //If the boat or the net collides with an obstacle, finish the game.

        if (transform.CompareTag("BoatAndStick") && collision.transform.CompareTag("Obstacle"))
            GameController.instance.FinishGame("boat");
        else if (transform.CompareTag("BoatAndStick") && collision.transform.CompareTag("Ocean"))
            GameController.instance.FinishGame("ocean");

        //If the net collides with a fish, call takeFish function from
        //GameController instance and delete the fish.
        if (collision.transform.CompareTag("Fish"))
        {
            GameController.instance.TakeFish();
            Destroy(collision.gameObject);
        }
    }
}
