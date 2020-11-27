using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;
    public float forwardForce = 1000;
    public float sideForce = 100;
    public float processing_time = 0;
    // Update is called once per frame
    void FixedUpdate () {
        Debug.Log(processing_time);
        if (processing_time < 240)
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
            if (Input.GetKey(KeyCode.LeftArrow)) rb.AddForce(-sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            if (Input.GetKey(KeyCode.RightArrow)) rb.AddForce(sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            processing_time += 1;
        }
        else if(processing_time >= 240)
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime * 2);
            if (Input.GetKey(KeyCode.LeftArrow)) rb.AddForce(-sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            if (Input.GetKey(KeyCode.RightArrow)) rb.AddForce(sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            processing_time += 1;
        }
    }
}
