using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float BoundMargin = 1.0f;
    Camera cam;
    private Renderer rend;
    private float objectHeight;
    private float objectWidth;

    private void Start()
    {
        cam = Camera.main;
        rend = GetComponent<Renderer>();
        objectHeight = rend.bounds.size.y;
        objectWidth = rend.bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        var yMargin = BoundMargin + objectHeight / 2;
        var xMargin = BoundMargin + objectWidth / 2;
        var maxY = cam.ViewportToWorldPoint(new Vector3(0, 1, cam.nearClipPlane)).y + yMargin;
        var minY = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane)).y - yMargin;
        var maxX = cam.ViewportToWorldPoint(new Vector3(1, 0, cam.nearClipPlane)).x + xMargin;
        var minX = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane)).x - xMargin;
        if (transform.position.y > maxY || transform.position.y < minY || transform.position.x > maxX || transform.position.x < minX)
        {
            Destroy(gameObject);
        }
    }
}
