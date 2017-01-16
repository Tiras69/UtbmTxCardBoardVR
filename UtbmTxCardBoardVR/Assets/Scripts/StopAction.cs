using UnityEngine;
using System.Collections;

public class StopAction : Action {

    public float inertie;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	    if (velocity > 0.0f)
        {
            velocity *= inertie;
            Vector3 translate = direction * velocity * Time.deltaTime;
            _object.transform.Translate(translate);
        }
        else
        {
            velocity = 0.0f;
        }
	}

    
}
