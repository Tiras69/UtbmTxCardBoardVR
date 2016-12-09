using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class GyroViewer : MonoBehaviour {

    private Rigidbody _rigidboby;
    private float _lastAccValueX;
    private float _lastAccValueY;
    private float _lastAccValueZ;

    // Use this for initialization
    void Start () {
        _rigidboby = GetComponent<Rigidbody>();
        Input.gyro.enabled = true;
        _lastAccValueX = 0;
        _lastAccValueY = 0;
        _lastAccValueZ = 0;
    }

    void Update()
    {
        this.transform.rotation = Input.gyro.attitude;
        this.transform.position = IntegrateAcc( Input.gyro.userAcceleration * 100);
        this.GetComponent<MeshRenderer>().material.color = new Color(transform.position.x, transform.position.y, transform.position.z);
    }
	
    private Vector3 IntegrateAcc(Vector3 acc)
    {
        Vector3 speed = new Vector3();
        speed.x = ((_lastAccValueX + acc.x) / 2.0f) * Time.deltaTime;
        _lastAccValueX = acc.x;

        speed.y = ((_lastAccValueY + acc.y) / 2.0f) * Time.deltaTime;
        _lastAccValueY = acc.y;

        speed.z = ((_lastAccValueZ + acc.z) / 2.0f) * Time.deltaTime;
        _lastAccValueZ = acc.z;

        return speed;
    }

    /*void FixedUpdate()
    {
    }*/
}
