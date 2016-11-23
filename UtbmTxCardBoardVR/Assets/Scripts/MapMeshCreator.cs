using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class MapMeshCreator : MonoBehaviour {

    private Mesh mesh;
    private MeshRenderer renderer;
    private MapData map;

	// Use this for initialization
	void Start () {

        // Get the map
        map = MapSerializer.Deserialize(Application.streamingAssetsPath+"/Maps/Map1.xml");

        renderer = GetComponent<MeshRenderer>();
        mesh = GetComponent<MeshFilter>().mesh;
        // Clear the mesh from previous instances.
        mesh.Clear();

        // #region Debug 
        // mesh.vertices = new Vector3[] { new Vector3(-10.0f, -10.0f, 0.01f), new Vector3(10.0f, -10.0f, 0.01f), new Vector3(10.0f, 10.0f, 0.01f), new Vector3(-10.0f, 10.0f, 0.01f) };
        // mesh.uv = new Vector2[] { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 0) };
        // mesh.triangles = new int[] { 0, 1, 2, 0, 2, 3 };
        // mesh.RecalculateNormals();
        // 
        // #endregion

        generateMesh();

        this.transform.position = Vector3.zero;
	}
	
    private void generateMesh()
    {
        

        // For all Rooms in the deserialized file
        foreach(RoomData room in map.rooms)
        {
            List<Vector3> vertices = new List<Vector3>();
            List<Vector2> uvs = new List<Vector2>();
            List<int> indices = new List<int>();

            // Getting the number of the position on the room map.
            int c = room.coordinates.Count;

            // For each rooms we get all the coordinates of the mesh.

            // Getting the vertices Coordinates.
            foreach (CoordinateData coord in room.coordinates)
            {
                // Swap the X and Z axis.
                vertices.Add(new Vector3(coord.x, 0.0f, coord.y));
            }

            int tmpSize = vertices.Count;
            for(int i = 0; i < tmpSize; i++)
            {
                // Add the same vertices but with an 5 height.
                vertices.Add(new Vector3(vertices[i].x, 5.0f, vertices[i].z));
            }

            /// <summary>
            /// Formulas where obtains on sheets
            /// Basically it's just chain logically all triangles's vertices
            /// regarding the current indices for a procedural amount 
            /// on vertex on the map.
            /// </summary>           
            #region Create Mesh

            // Create Triangles.
            // Upper Triangles.
            for (int i = 0; i<c ; i++)
            {
                indices.Add(i);
                indices.Add((i+1)%c);
                indices.Add(((i+1)%c)+c);
            }
            // Bottom Triangles.
            for(int i = 0; i<c; i++)
            {
                indices.Add(i);
                indices.Add(((i + 1) % c) + c);
                indices.Add(i + c);
            }

            // uv stuff.
            for(int i = 0; i<c*2; i++)
            {
                // uvs are not quite important
                uvs.Add(new Vector2(i % 2, i / c));
            }

            // Unity building Mesh.
            mesh.vertices = vertices.ToArray();
            mesh.uv = uvs.ToArray();
            mesh.triangles = indices.ToArray();
            mesh.RecalculateNormals();

            #endregion

        }
    }


	// Update is called once per frame
	void Update () {
	
	}
}
