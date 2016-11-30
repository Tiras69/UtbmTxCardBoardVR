using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestGPS : MonoBehaviour {

    private InitializeGPS location;
    public Text latitude;
    public Text longitude;


	// Use this for initialization
	void Start ()
    {
        location = GetComponentInChildren<InitializeGPS>();
        location.Initialize();
	}
	
	// Update is called once per frame
	void Update ()
    {
        LocationInfo tmp = location.GetCurrentDatas();
        latitude.text = tmp.latitude.ToString();
        longitude.text = tmp.longitude.ToString();
	}
}
