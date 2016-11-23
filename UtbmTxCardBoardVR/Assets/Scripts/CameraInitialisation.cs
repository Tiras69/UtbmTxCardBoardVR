using UnityEngine;
using System.Collections;

public class CameraInitialisation : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        ApplicationManager.Instance.mainCameraReference = this.gameObject;
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
