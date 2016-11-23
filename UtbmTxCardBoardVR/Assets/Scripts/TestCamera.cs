using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestCamera : MonoBehaviour {

    
    private WebCamTexture cameraTexture = null;

    // Use this for initialization
    void Start () {

        cameraTexture = new WebCamTexture();

        this.GetComponent<RawImage>().material.mainTexture = cameraTexture;

        cameraTexture.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
