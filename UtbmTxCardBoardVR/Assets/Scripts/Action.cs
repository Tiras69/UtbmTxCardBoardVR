using UnityEngine;
using System.Collections;

public abstract class Action : MonoBehaviour {

    public float velocity;
    public float angleVelocity;
    public Vector3 direction;

    public GameObject _object;

	// Use this for initialization
	protected virtual void Start () {
        _object = GetComponent<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
