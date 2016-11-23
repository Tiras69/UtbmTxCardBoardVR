using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshRenderer))]
public class TransmitPosToShader : MonoBehaviour {

    public GameObject obj;

    private MeshRenderer renderer;

	// Use this for initialization
	void Start () {
        renderer = this.GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        renderer.material.SetVector("_GhostPosition", new Vector4(obj.transform.position.x,
                                                        obj.transform.position.y,
                                                        obj.transform.position.z,
                                                        1.0f));

    }
}
