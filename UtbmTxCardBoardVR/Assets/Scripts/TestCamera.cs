using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof (MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class TestCamera : MonoBehaviour {

    
    private WebCamTexture cameraTexture = null;
    public RenderTexture renderTexture;
    private MeshRenderer meshRenderer;
    private MeshFilter meshFilter;

    // Use this for initialization
    void Start () {
            

        #region Camera Texture binding.
        cameraTexture = new WebCamTexture();
        
        this.GetComponent<MeshRenderer>().material.mainTexture = cameraTexture;
        
        cameraTexture.Play();
        #endregion

        StartCoroutine(FirstFrameExecutor());
    }

    IEnumerator FirstFrameExecutor()
    {
        yield return new WaitForEndOfFrame();

        #region Background Mesh Creation.
        Camera cam = ApplicationManager.Instance.mainCameraReference.GetComponent<Camera>();
        meshRenderer = GetComponent<MeshRenderer>();
        meshFilter = GetComponent<MeshFilter>();


        List<Vector3> vertices = new List<Vector3>();
        List<Vector2> uvs = new List<Vector2>();
        List<int> triangles = new List<int>();


        vertices.Add(cam.ViewportToWorldPoint(new Vector3(0, 0, cam.farClipPlane - 10.0f)));
        vertices.Add(cam.ViewportToWorldPoint(new Vector3(1, 0, cam.farClipPlane - 10.0f)));
        vertices.Add(cam.ViewportToWorldPoint(new Vector3(1, 1, cam.farClipPlane - 10.0f)));
        vertices.Add(cam.ViewportToWorldPoint(new Vector3(0, 1, cam.farClipPlane - 10.0f)));

        uvs.Add(new Vector2(0, 0));
        uvs.Add(new Vector2(1, 0));
        uvs.Add(new Vector2(1, 1));
        uvs.Add(new Vector2(0, 1));

        triangles.Add(1);
        triangles.Add(0);
        triangles.Add(3);
        triangles.Add(1);
        triangles.Add(3);
        triangles.Add(2);

        meshFilter.mesh.vertices = vertices.ToArray();
        meshFilter.mesh.uv = uvs.ToArray();
        meshFilter.mesh.triangles = triangles.ToArray();

        #endregion

        /*#region Camera Texture binding.
        cameraTexture = new WebCamTexture();
        

        
        cameraTexture.Play();
        #endregion*/
    }

    /*void OnDrawGizmosSelected()
    {
        Camera camera = GetComponent<Camera>();
        Vector3 p = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.farClipPlane - 10.0f));
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(p, 100);
        
        p = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.farClipPlane - 10.0f));
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(p, 100);
        
        p = camera.ViewportToWorldPoint(new Vector3(1, 0, camera.farClipPlane - 10.0f));
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(p, 100);
        
        p = camera.ViewportToWorldPoint(new Vector3(0, 1, camera.farClipPlane - 10.0f));
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(p, 100);
    }*/

    // Update is called once per frame
    void Update () {
	}
}
