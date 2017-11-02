﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    //public GameObject player;
    public Transform lookAt;
    public Transform camTransform;

    private Camera cam;

    public float distance = 5.0f;
    public float currentX = 0.0f;
    public float currentY = 0.0f;
    public float sensivityX = 4.0f;
    public float sensivityY = 4.0f;
    public const float MIN_Y = 15;
    public const float MAX_Y = 50;


    // Use this for initialization
    void Start()
    {
        //offset = transform.position - player.transform.position;
        camTransform = GetComponent<Transform>();
        cam = Camera.main;

    }

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X") * sensivityX;
        currentY += Input.GetAxis("Mouse Y") * sensivityY;
        currentY = Mathf.Clamp(currentY, MIN_Y, MAX_Y);
    }

    private void LateUpdate()
    {
        //transform.position = player.transform.position + offset; 
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }
}
