﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController3 : MonoBehaviour
{
    public bool doorOpening;
    public GameObject leftDoor;
    public GameObject rightDoor;

    private float speed;
    void Start()
    {
        doorOpening = false;
        speed = 0.8f;

    }

    // Update is called once per frame
    void Update()
    {


        if (doorOpening == true)
        {
            Vector3 offset = new Vector3(0, 0, speed * Time.deltaTime);

            if (leftDoor.transform.position.x <= -2.4 && false)
            {
                doorOpening = false;
            }
            else
            {
                leftDoor.transform.position = leftDoor.transform.position - offset;
                rightDoor.transform.position = rightDoor.transform.position + offset;
            }
            //westDoor.transform.position = new Vector3(-2.3f, 0.67f, 9.8f);

            //eastDoor.transform.position += offset;

        }

    }


}
