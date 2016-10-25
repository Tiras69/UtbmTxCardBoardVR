using UnityEngine;
using System.Collections;

public class CircleBehaviour : MonoBehaviour {

    public float torqueSpeed;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.RotateAround(ApplicationManager.Instance.mainCameraReference.transform.position, Vector3.up, torqueSpeed * Time.deltaTime);
	}
}
