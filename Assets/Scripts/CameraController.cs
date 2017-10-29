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

    void LateUpdate()
    {

        transform.position = Vector3.Lerp(transform.position, target.position, 5.0f * Time.deltaTime) + offset; 

        /*
        transform.position = player.transform.position + offset; 
	
    
        transform.Rotate((transform.up * Input.GetAxisRaw("Mouse X")).normalized * Time.deltaTime);
        */
    }
}
