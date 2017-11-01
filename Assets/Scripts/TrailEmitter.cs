using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailEmitter : MonoBehaviour {
    private Vector3 currentPo;
    private Vector3 prePo;
    private PlayerController playerController;
    private bool lineOn = true;
    private float currentPos;
    private float previousPos;
    private bool onGround = true;

    // Use this for initialization
    void Start () {
        prePo = GetComponent<Transform>().position;
        playerController = GetComponent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
        currentPo = GetComponent<Transform>().position;

        if (Input.GetKeyDown(KeyCode.Q) && lineOn == true)
        {
            lineOn = false; 
        }

        else if (Input.GetKeyDown(KeyCode.Q) && lineOn == false)
        {
            lineOn = true;
        }
        //
        if (onGround && !playerController.isWhite && lineOn)
        {
            GameObject LineHolder = new GameObject("LineHolder");
            LineHolder.transform.position = new Vector3(0, 0, 0);
            //Vector3 ro = GetComponent<Transform>().rotation.eulerAngles;
            LineHolder.transform.rotation = Quaternion.Euler(90, 0, 0);

            LineRenderer lr = LineHolder.AddComponent<LineRenderer>();
            lr.useWorldSpace = true;
            lr.alignment = LineAlignment.Local;
            lr.positionCount = 2;
            //material = GetComponent<Material>().color;
            lr.sharedMaterial = playerController.rend.sharedMaterial;
       
            lr.startWidth = 0.2f;
            lr.endWidth = 0.2f;
            lr.SetPosition(0, new Vector3(prePo.x, prePo.y - 0.99f, prePo.z));
            lr.SetPosition(1, new Vector3(currentPo.x, currentPo.y - 0.99f, currentPo.z));
            GameObject.Destroy(LineHolder, 40f);
        }
        if (currentPo.y > prePo.y)
        {
            onGround = false;
        }
        prePo = currentPo;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            onGround = true;
        }
    }

}
