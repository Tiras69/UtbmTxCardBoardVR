using UnityEngine;
using System.Collections;

public class InitializeGPS : MonoBehaviour {

    private LocationService location;
    private LocationInfo oldDatas;

	// Use this for initialization
	IEnumerator Start () {

        this.location = Input.location;

        //Check if location is enabled
	    if (!location.isEnabledByUser)
        {
            Debug.LogError("Location not initialize !");
            yield break;
        }

        //Initialize LocationService
        location.Start(0.1f, 0.5f);

        //Wait until LocationService respond.
        int maxWait = 20;
        if (location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        //Timeout
        if (maxWait < 1)
        {
            Debug.LogError("LocationService : Timeout !");
            yield break;
        }            

        //Connection Fail
        if (location.status == LocationServiceStatus.Failed)
        {
            Debug.LogError("LocationService : Unable to connect");
            yield break;
        }
        else
        {
            Debug.Log("Location: " + location.lastData.latitude + " " + location.lastData.longitude + " " + location.lastData.altitude + " " + location.lastData.horizontalAccuracy + " " + location.lastData.timestamp);
        }

    }

    //Initialize the datas of the Location
    public void Initialize()
    {
        oldDatas = location.lastData;
    }

    float getSquaredDistanceVariation()
    {
        LocationInfo tempDatas = location.lastData;

        float deltaLatitude = tempDatas.latitude - oldDatas.latitude;
        float deltaLongitude = tempDatas.longitude - oldDatas.longitude;

        return Mathf.Pow(deltaLatitude, 2) + Mathf.Pow(deltaLongitude, 2);
    }

    public LocationInfo GetCurrentDatas()
    {
        oldDatas = location.lastData;
        return oldDatas;
    }

    //Stop the location service.
    public void Stop()
    {
        location.Stop();
    }
}
