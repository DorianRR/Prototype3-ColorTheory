using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Trails;

public class MoveTrailAnchor : MonoBehaviour
{

    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public float rotateSpeed = 3.0F;
    private Vector3 moveDirection = Vector3.zero;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        CharacterController controller = GetComponent<CharacterController>();
        
        //Roate Player via keyboard
        //transform.Rotate(0, Input.GetAxis("Horizontal"), 0);

        //Roate Player via mouse
        transform.Rotate(0, Input.GetAxis("Mouse X"), 0);

        if (controller.isGrounded)
        {
            //print("I am grounded sir");
            //GameObject.Find("TrailAnchor").GetComponent<TrailEmitter>().NewTrail();
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
            {
                //GameObject.Find("TrailAnchor").GetComponent<TrailEmitter>().EndTrail();
                moveDirection.y = jumpSpeed;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

    }
}
