using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;
    public float forwardForce = 2000;
    public float sideForce = 500;

    // Update is called once per frame
    void FixedUpdate () {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow)) rb.AddForce(-sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        if (Input.GetKey(KeyCode.RightArrow)) rb.AddForce(sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }
}
