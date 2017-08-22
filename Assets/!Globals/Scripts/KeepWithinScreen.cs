using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class KeepWithinScreen : MonoBehaviour
{
    private Renderer rend;
    private Camera cam;
    private Bounds camBounds;
    private float camWidth, camHeight;

    // Use this for initialization
    void Start()
    {
        // Set cam to main camera
        cam = Camera.main;
        // Get renderer component
        rend = GetComponent<Renderer>();
    }

    void UpdateCamBounds()
    {
        camHeight = 2f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;
        camBounds = new Bounds(cam.transform.position, new Vector3(camWidth, camHeight));
    }

    Vector3 CheckBounds()
    {
        Vector3 pos = transform.position;
        Vector3 size = rend.bounds.size;
        float halfWidth = size.x * 0.5f;
        float halfHeight = size.y * 0.5f;
        // Check left
        if(pos.x - halfWidth < camBounds.min.x)
        {
            pos.x = camBounds.min.x + halfWidth;
        }
        // Check right
        if (pos.x + halfWidth > camBounds.max.x)
        {
            pos.x = camBounds.max.x - halfWidth;
        }
        // Check down
        if (pos.y - halfHeight < camBounds.min.y)
        {
            pos.y = camBounds.min.y + halfHeight;
        }
        // Check up
        if (pos.y + halfHeight > camBounds.max.y)
        {
            pos.y = camBounds.max.y - halfHeight;
        }
        return pos;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCamBounds();
        transform.position = CheckBounds();
    }
}
