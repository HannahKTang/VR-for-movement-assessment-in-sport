using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam_controller : MonoBehaviour
{
    public Vector2 turn_cam;
    public float sensitivity_cam = .5f;
    public float bobbing_angle = 2.0f;
    private int idxbob;


    void Start()
    {
       // Cursor.lockState = CursorLockMode.Locked;  // To hide cursor
    }


    void Update()
    {
        turn_cam.x += Input.GetAxis("Mouse Y") * sensitivity_cam;
        transform.localRotation = Quaternion.Euler(-turn_cam.x, 0, 0);        
    }
}
