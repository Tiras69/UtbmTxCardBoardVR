using UnityEngine;
using System.Collections;

public sealed class ApplicationManager : Singleton<ApplicationManager> {

    public GameObject mainCameraReference;

	public void getAndroidParameters()
    {
        AndroidWrapper.GetParameters();
    }
}
