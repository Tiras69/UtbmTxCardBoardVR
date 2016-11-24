using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AccelerationX : MonoBehaviour {

    public Text XAcceleration;
    public Text YAcceleration;
    public Text ZAcceleration;

    private Gyroscope gyroscope;

	// Use this for initialization
	void Start () {

        this.gyroscope = Input.gyro;
	}
	
	// Update is called once per frame
	void Update () {
        XAcceleration.text = gyroscope.userAcceleration.x.ToString();
        YAcceleration.text = gyroscope.userAcceleration.y.ToString();
        ZAcceleration.text = gyroscope.userAcceleration.z.ToString();

        Debug.DrawLine(Vector3.zero, gyroscope.userAcceleration);

    }
}
