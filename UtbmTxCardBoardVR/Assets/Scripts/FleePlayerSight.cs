using UnityEngine;
using System.Collections;

public class FleePlayerSight : MonoBehaviour {

    public float objectSpeed;

    private GameObject playerGO;

	// Use this for initialization
	void Start () {
        playerGO = ApplicationManager.Instance.mainCameraReference;
        Debug.Log(playerGO);
	}
	
	// Update is called once per frame
	void Update () {
        LookAtOposite();
        Flee();
	}

    public void LookAtOposite()
    {
        // We don't care about the Y coordinates.
        Vector2 flatDirVector = new Vector2(playerGO.transform.forward.x, playerGO.transform.forward.z);
        flatDirVector.Normalize();
        float yRot = Mathf.Atan2(flatDirVector.x, flatDirVector.y) * 180.0f / Mathf.PI;
        Debug.Log("Rotation : "+ yRot);

        Vector3 currentRot = this.transform.rotation.eulerAngles;
        currentRot.y = yRot;
        transform.transform.rotation = Quaternion.Euler(currentRot);

    }

    public void Flee()
    {
        Vector3 playerToObjectVect = this.transform.position - playerGO.transform.position;
        playerToObjectVect.y = 0;
        playerToObjectVect.Normalize();

        float dotValue = Vector3.Dot(playerGO.transform.right, playerToObjectVect);

        // if the value is greater than zero that would mean that the object go to the right
        if(dotValue > 0.0f)
        {
            this.transform.Translate(playerGO.transform.right * objectSpeed * Time.deltaTime, Space.World);
        }
        else
        {
            this.transform.Translate(-playerGO.transform.right * objectSpeed * Time.deltaTime, Space.World);
        }


    }
}
