using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGizmo : MonoBehaviour
{
    public Color color = new Color(1, 0, 0, 0.5f);

    private Mesh mesh;

    // Start is called before the first frame update
    void Start()
    {
        mesh = gameObject.GetComponent<MeshFilter>().sharedMesh;
        
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        mesh.RecalculateTangents();
    }
    
    void OnDrawGizmos() {
        Gizmos.color = color;
        Gizmos.DrawMesh(
            gameObject.GetComponent<MeshFilter>().mesh,
            0,
            gameObject.transform.position,
            gameObject.transform.rotation,
            gameObject.transform.localScale
        );
    }
}
