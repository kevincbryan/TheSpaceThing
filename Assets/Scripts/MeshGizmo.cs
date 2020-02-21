using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (MeshFilter))]
public class MeshGizmo : MonoBehaviour
{
    public Color color = new Color(1, 0, 0, 0.5f);
    public bool isWireframe = false;
    
    /*
    void OnDrawGizmos() {
        Gizmos.color = color;
        if (isWireframe) {
            Gizmos.DrawWireMesh(
                gameObject.GetComponent<MeshFilter>().sharedMesh,
                0,
                gameObject.transform.position,
                gameObject.transform.rotation,
                gameObject.transform.localScale
            );
        } else {
            Gizmos.DrawMesh(
                gameObject.GetComponent<MeshFilter>().sharedMesh,
                0,
                gameObject.transform.position,
                gameObject.transform.rotation,
                gameObject.transform.localScale
            );
        }
    }*/
}
