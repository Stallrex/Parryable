﻿using UnityEngine;

[ExecuteInEditMode]
public class Zoom : MonoBehaviour
{
    Camera cameraObject;
    public float defaultFOV = 60;
    public float maxZoomFOV = 15;
    [Range(0, 1)]
    public float currentZoom;
    public float sensitivity = 1;


    void Awake()
    {
        // Get the camera on this gameObject and the defaultZoom.
        cameraObject = GetComponent<Camera>();
        if (cameraObject)
        {
            defaultFOV = cameraObject.fieldOfView;
        }
    }

    void Update()
    {
        // Update the currentZoom and the camera's fieldOfView.
        currentZoom += Input.mouseScrollDelta.y * sensitivity * .05f;
        currentZoom = Mathf.Clamp01(currentZoom);
        //cameraObject.fieldOfView = Mathf.Lerp(defaultFOV, maxZoomFOV, currentZoom);
    }
}
