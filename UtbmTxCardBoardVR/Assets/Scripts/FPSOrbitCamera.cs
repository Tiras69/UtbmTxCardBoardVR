using UnityEngine;
using System.Collections;

public class FPSOrbitCamera : MonoBehaviour {

    public float mouseSensibility;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        this.transform.Rotate(new Vector3(mouseY, 0.0f, 0.0f));
        this.transform.Rotate(new Vector3(0.0f, mouseX, 0.0f), Space.World);
	}
}
