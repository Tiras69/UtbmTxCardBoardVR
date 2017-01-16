using UnityEngine;
using System.Collections;

public class MoveGyroscope : GhostAction
{
    private Gyroscope gyroscope;
    private Rigidbody rb;

    // Use this for initialization
    new void Start()
    {
        Input.gyro.enabled = true;  
        this.gyroscope = Input.gyro;
        this.rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = gyroscope.userAcceleration;
        direction.y = 0.0f;
        
        Debug.DrawLine(_object.transform.position, _object.transform.position + direction, Color.green);
        if (direction.magnitude > 0.5)
            rb.AddForce(direction, ForceMode.Acceleration);
        else
            rb.ResetInertiaTensor();
    }
}
