using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(RawImage))]
public class PlaceBackgroungRawImage : MonoBehaviour {

    private RectTransform panel;
    private RawImage rawImage;
    private WebCamTexture cameraTexture;

    // Use this for initialization
    void Start()
    {
        rawImage = GetComponent<RawImage>();
        panel = GetComponent<RectTransform>();

        //StartCoroutine(FirstFrameExecutor());

        /*#region Background Mesh Creation.
        Camera cam = ApplicationManager.Instance.mainCameraReference.GetComponent<Camera>();
        Camera[] cams = cam.GetComponentsInChildren<Camera>();

        // 1 Left 2 Right


        Vector3 worldCam1 = cams[1].ViewportToWorldPoint(new Vector3(0, 0, cam.farClipPlane - 10.0f));
        Vector3 worldCam2 = cams[1].ViewportToWorldPoint(new Vector3(0, 1, cam.farClipPlane - 10.0f));
        Vector3 worldCam3 = cams[2].ViewportToWorldPoint(new Vector3(1, 0, cam.farClipPlane - 10.0f));
        float width = worldCam3.x - worldCam1.x;
        float height = worldCam2.y - worldCam1.y;

        panel.sizeDelta = new Vector2(height, width);
        Vector3 tmpVect = panel.position;
        tmpVect.z = cam.farClipPlane - 10.0f;
        panel.position = tmpVect;


        #endregion*/

        #region Camera Texture binding.
        cameraTexture = new WebCamTexture();
        rawImage.material.mainTexture = cameraTexture;
        cameraTexture.Play();
        #endregion

        StartCoroutine(FirstFrameExecutor());


    }

    IEnumerator FirstFrameExecutor()
    {
        yield return new WaitForEndOfFrame();

        rawImage = GetComponent<RawImage>();
        panel = GetComponent<RectTransform>();

        //StartCoroutine(FirstFrameExecutor());

        #region Background Mesh Creation.
        Camera cam = ApplicationManager.Instance.mainCameraReference.GetComponent<Camera>();
        Camera[] cams = cam.GetComponentsInChildren<Camera>();

        // 1 Left 2 Right But according to Google the Left Eye is right and the Left Eye is right.

        Vector3 worldCam1 = cams[2].ViewportToWorldPoint(new Vector3(0, 0, cam.farClipPlane - 100.0f));
        Vector3 worldCam2 = cams[2].ViewportToWorldPoint(new Vector3(0, 1, cam.farClipPlane - 100.0f));
        Vector3 worldCam3 = cams[1].ViewportToWorldPoint(new Vector3(1, 0, cam.farClipPlane - 100.0f));
        float width = worldCam3.x - worldCam1.x;
        float height = worldCam2.y - worldCam1.y;

        /*Debug.Log("1: " + worldCam1);
        Debug.Log("2: " + worldCam2);
        Debug.Log("3: " + worldCam3);
        Debug.Log("width: " + width);
        Debug.Log("height: " + height);*/

        panel.sizeDelta = new Vector2(width, height);
        Vector3 tmpVect = panel.position;
        tmpVect.z = cam.farClipPlane - 100.0f;
        panel.position = tmpVect;
        this.transform.SetParent(cam.transform);

        #endregion
    }

    // Update is called once per frame
    void Update () {
	
	}
}
