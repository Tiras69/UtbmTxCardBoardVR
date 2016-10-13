using UnityEngine;
using UnityEngine.UI;
using System.Collections;

#if UNITY_ANDROID
/// <summary>
/// This class must be unique (maybe the use of a singleton can be wise)
/// since this class is not a singleton it have to be attached to a one GameObject
/// in every scene were you want to access specifics parameters of an Android API.
/// </summary>
public sealed class AndroidWrapper : MonoBehaviour {

    #region public fields
    public static Vector2   cameraResolution        { get; private set; }   // gives the resolution of the front back camera.
    public static float     cameraFocalLength       { get; private set; }   // gives the focal length of the front back camera.
    public static float     cameraHorizontalFOV     { get; private set; }   // gives the Horizontal field of view of the back facing camera.
    public static float     cameraVerticalFOV       { get; private set; }   // gives the Vertical field of view of the back facing camera.
    #endregion

    /// <summary>
    /// Static methods thats search in the native Android APIs some parameters
    /// that can be useful in the application.
    /// </summary>
    private static void GetParameters()
    {
        try {
            AndroidJavaClass cameraClass = new AndroidJavaClass("android.hardware.Camera");

            int numCameras = cameraClass.CallStatic<int>("getNumberOfCameras");

            // This is an ugly hack to make Unity
            // generate Camera permisions.
            WebCamDevice[] devices = WebCamTexture.devices;

            // Camera.open gets back-facing camera by default.
            int camID = 0;
            AndroidJavaObject camera = cameraClass.CallStatic<AndroidJavaObject>("open", camID);

            // We check if there a back facing camera.
            if (camera != null)
            {
                // We get the parameter object.
                AndroidJavaObject cameraParameters = camera.Call<AndroidJavaObject>("getParameters");
                //We get the size in the parameters
                AndroidJavaObject cameraSize = cameraParameters.Call<AndroidJavaObject>("getPictureSize");

                // Add it to the "convenient" variables
                Vector2 tmpVect = Vector2.zero;
                tmpVect.x = (float) cameraSize.Get<int>("width");
                tmpVect.y = (float) cameraSize.Get<int>("height");
                cameraResolution = tmpVect;
                
                cameraHorizontalFOV = cameraParameters.Call<float>("getHorizontalViewAngle");
                cameraVerticalFOV = cameraParameters.Call<float>("getVerticalViewAngle");
                cameraFocalLength = cameraParameters.Call<float>("getFocalLength");

            }
        }
        catch (AndroidJavaException e)
        {

        }
    }

    #region Unity stuff related
    // Use this for initialization
    void Start () {
        AndroidWrapper.GetParameters();
	}
    #endregion
}
#endif
