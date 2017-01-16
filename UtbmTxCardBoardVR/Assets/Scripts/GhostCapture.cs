using UnityEngine;
using System.Collections;

public class GhostCapture : MonoBehaviour {

    public float timeToTrigger;
    public float timeOfFlash;
    public LayerMask layerToObserve;

    private float timerToTrigger;
    private float timerToFlash;

    private Light lampLight;

	// Use this for initialization
	void Start () {
        this.timerToTrigger = 0.0f;
        this.lampLight = GetComponentInChildren<Light>();
        this.timerToFlash = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {

        Debug.DrawRay(this.transform.position, this.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, float.PositiveInfinity)) {
            Debug.Log("RayCast");

            this.timerToTrigger += Time.deltaTime;
            timerToFlash -= Time.deltaTime;
            if (timerToFlash < 0.0f)
                timerToFlash = 0.0f;

            if (this.timerToTrigger > this.timeToTrigger)
            {
                timerToTrigger = 0.0f;
                if (hit.transform.gameObject.tag == "Ghost")
                {
                    hit.transform.gameObject.SetActive(false);
                }
                StartCoroutine(Flash());
                timerToFlash = 2.0f;
            }
        }
	}

    IEnumerator Flash()
    {
        lampLight.enabled = true;
        yield return new WaitForSeconds(timeOfFlash);
        lampLight.enabled = false;
    }
}
