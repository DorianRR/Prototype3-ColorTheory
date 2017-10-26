using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

    private float xRotation = 0.0f;
    private float verticalInput = 0.0f;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //CharacterController controller = GetComponent<CharacterController>();

        transform.Rotate((transform.up * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Mouse X")).normalized * Time.deltaTime);

       

    }
}
