using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Trails;

public class TrailFX : MonoBehaviour {

    public CharacterController controller;

    private bool prevGrounded = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        //CharacterController controller = GetComponent<CharacterController>();

        //print(controller.transform.position.y < 3);

        if (controller.isGrounded && controller.velocity != Vector3.zero)
        {
            prevGrounded = true;
            print("GROUNDED!!");
            GameObject.Find("TrailAnchor/TrailFX").GetComponent<TrailEmitter>().NewTrail();
        }
        else if(prevGrounded){
            GameObject.Find("TrailAnchor/TrailFX").GetComponent<TrailEmitter>().EndTrail();
            prevGrounded = false;
        }
        

    }
}
