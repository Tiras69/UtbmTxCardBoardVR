using UnityEngine;
using UnityEngine.Events;
using System.Collections;



public class SightObjectTrigger : MonoBehaviour
{

    public float timeToTrigger;
    public LayerMask layerToObserve;
    public UnityEvent action;

    private float timerToTrigger;


    // Use this for initialization
    void Start()
    {
        timerToTrigger = 0.0f;

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(this.transform.position, this.transform.forward, out hit, layerToObserve))
        {
            Debug.Log(timerToTrigger);
            timerToTrigger += Time.deltaTime;
            if (timerToTrigger > timeToTrigger)
            {
                timerToTrigger = 0.0f;
                action.Invoke();
                
            }
        }
        else
        {
            timerToTrigger = 0.0f;
        }


        
    }


}
