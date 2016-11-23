using UnityEngine;
using System.Collections;

public class WanderAction : Action {
    
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        float rotateDirection = Random.Range(-1f, 1f);
        this.direction = Quaternion.Euler(0.0f, Mathf.Sign(rotateDirection) * angleVelocity * Time.deltaTime, 0.0f)*direction;
        direction.Normalize();

        this._object.transform.Rotate(0f, Mathf.Sign(rotateDirection) * angleVelocity * Time.deltaTime, 0f, Space.World);
        this._object.transform.Translate(velocity * direction * Time.deltaTime);
	}
}
