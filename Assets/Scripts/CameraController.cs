using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    public Transform target;

    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void Update()
    {

        transform.position = Vector3.Lerp(transform.position, target.position + offset, 0.5f * Time.deltaTime); 

  
    }
}
