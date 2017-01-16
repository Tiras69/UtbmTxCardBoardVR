using UnityEngine;
using System.Collections;

public class ThroughCameraAction : GhostAction {

    private GameObject mainCamera;
    private Quaternion targetQuaternion;
    private Quaternion initQuaternion;

    private float currentSlerpTime = 0.0f;

    public float slerpDeltaTime;

	// Use this for initialization
	void Start () {
        mainCamera = ApplicationManager.Instance.mainCameraReference;
        
        //We get the init quaternion;
        Transform t = this.transform;
        this.initQuaternion = t.rotation;

        //We get the targeted quaternion
        t.LookAt(mainCamera.transform, this.transform.up);
        this.targetQuaternion = t.rotation;

        /*
        Vector3 lookAtPosLocalised = transform.InverseTransformPoint(mainCamera.transform.position);
        lookAtPosLocalised.y = 0f;
        Vector3 lookAt = transform.TransformPoint(lookAtPosLocalised);*/
        
    }
	
	// Update is called once per frame
	void Update () {
        //We calculate the destination of the object.
        Vector3 cameraPosition = mainCamera.gameObject.transform.position;
        Vector3 objectPosition = _object.transform.position;

        direction = cameraPosition - objectPosition;
        direction.y = 0f;
        direction.Normalize();

        //We rotate the objet smoothly
        Quaternion currentionQuaternion = Quaternion.Slerp(initQuaternion, targetQuaternion, currentSlerpTime);
        currentSlerpTime += slerpDeltaTime;

        /*
        Quaternion currentRotation = Quaternion.LookRotation(direction);
        transform.localRotation = Quaternion.Slerp(transform.rotation, currentRotation, angleVelocity * Time.deltaTime);

        _object.transform.rotation = currentRotation;*/


        this.transform.Translate(direction * velocity * Time.deltaTime, Space.World);
        this.transform.rotation = currentionQuaternion;

    }
}
