using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class VisualizeBounds : MonoBehaviour
{
    private Renderer rend;

    void OnDrawGizmos()
    {
        rend = GetComponent<Renderer>();
        Gizmos.DrawWireCube(transform.position, rend.bounds.size);
    }
}
