using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScaler : MonoBehaviour
{
    public float sceneWidth = 10;

    Camera _camera;
    void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        if (Screen.width < Screen.height)
        {
            float unitsPerPixel = sceneWidth / Screen.width;

            float desiredHalfHeight = 0.5f * unitsPerPixel * Screen.height;

            _camera.orthographicSize = desiredHalfHeight;
        }
    }

}
