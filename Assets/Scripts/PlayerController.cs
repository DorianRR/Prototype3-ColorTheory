using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour {
    public float speed;
    public Material[] materials;
    public Renderer rend;

    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    void FixedUpdate()
    {
        float moveHoriz = Input.GetAxis("Horizontal");
        float moveVert = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(moveHoriz, 0, moveVert);

        rb.AddForce(movement * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blue Pool"))
        {
            rend.sharedMaterial = materials[1];
        }
        else if (other.gameObject.CompareTag("Red Pool"))
        {
            rend.sharedMaterial = materials[2];
        }
        else if (other.gameObject.CompareTag("White Pool"))
        {
            rend.sharedMaterial = materials[0];
        }
    }

}
