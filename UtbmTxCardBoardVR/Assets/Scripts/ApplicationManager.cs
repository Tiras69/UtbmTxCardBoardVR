using UnityEngine;
using System.Collections;

public sealed class ApplicationManager : Singleton<ApplicationManager> {

    public GameObject mainCameraReference;

	public void getAndroidParameters()
    {
#if UNITY_ANDROID
        AndroidWrapper.GetParameters();
#endif
    }
}
