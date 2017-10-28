using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailEmitter : MonoBehaviour {
    private Vector3 currentPo;
    private Vector3 prePo;
    private PlayerController playerController;
    private bool lineOn = true;
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

        if (currentPo.y <= 0.5 && prePo.y <= 0.5 && !playerController.isWhite && lineOn)
        {
            GameObject LineHolder = new GameObject("LineHolder");
            LineHolder.transform.position = new Vector3(0, 0, 0);
            //Vector3 ro = GetComponent<Transform>().rotation.eulerAngles;
            LineHolder.transform.rotation = Quaternion.Euler(90, 0, 0);

            LineRenderer lr = LineHolder.AddComponent<LineRenderer>();
            lr.useWorldSpace = true;
            lr.alignment = LineAlignment.Local;
            lr.positionCount = 2;
            //terial = GetComponent<Material>().color;
            lr.sharedMaterial = playerController.rend.sharedMaterial;
       
            lr.startWidth = 0.2f;
            lr.endWidth = 0.2f;
            lr.SetPosition(0, new Vector3(prePo.x, 0.01f, prePo.z));
            lr.SetPosition(1, new Vector3(currentPo.x, 0.01f, currentPo.z));
            GameObject.Destroy(LineHolder, 40f);
        }
        
        prePo = currentPo;
    }
}
