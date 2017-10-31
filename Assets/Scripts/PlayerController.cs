using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;



public class PlayerController : MonoBehaviour {
    enum color { white, blue, red, yellow, orange, purple, green, brown};
    public float speed;
    public Material[] materials;
    public Text output;
   
    public GameObject[] ColorPool;
    public GameObject doors;

    private DoorController doorController;
    private Rigidbody rb;
    public Renderer rend;
    private Dictionary<string, int> colorCollected = new Dictionary<string, int>();
    public bool isWhite = true;
    public Transform camTransform;

    void Start()
    {
        output.text = "";
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        colorCollected.Add("blue", 0);
        colorCollected.Add("red", 0);
        colorCollected.Add("yellow", 0);
        doorController = doors.GetComponent<DoorController>();
    }

    void FixedUpdate()
    {

        Vector3 currentPo = GetComponent<Transform>().position;

        float moveHoriz = Input.GetAxis("Horizontal");
        float moveVert = Input.GetAxis("Vertical");
        float moveUp = 0;

        if (Input.GetButton("Jump"))
        {
            moveUp = 30;
        }
        else
        {
            moveUp = 0;
        }

        Vector3 movement = new Vector3(moveHoriz, moveUp, moveVert);
        Quaternion rot = Quaternion.Euler(0, camTransform.rotation.eulerAngles.y, 0);
        movement = rot * movement;
        if (this.transform.position.y < 0.51)
        {
            //rb.transform.position = currentPo + movement*speed;
            rb.AddForce(movement * speed);
        }
        movement = new Vector3(0,0,0);
    }
    private void OnTriggerEnter(Collider other)
    {
        isWhite = false;
        if (other.gameObject.CompareTag("White Pool"))
        {
            rend.sharedMaterial = materials[0];
            for (int i = 0; i < 3; i++ )
            {
                ColorPool[i].SetActive(true);
            }
            colorCollected["blue"] = 0;
            colorCollected["red"] = 0;
            colorCollected["yellow"] = 0;
            isWhite = true;
        }
        else if (other.gameObject.CompareTag("Blue Pool"))
        {
            colorCollected["blue"]++;
            if (colorCollected["blue"] == 1 && colorCollected["red"] == 0 && colorCollected["yellow"] == 0){
                rend.sharedMaterial = materials[(int)color.blue];
            }
            else if (colorCollected["blue"] == 1 && colorCollected["red"] == 1 && colorCollected["yellow"] == 0)
            {
                rend.sharedMaterial = materials[(int)color.purple];
            }
            else if (colorCollected["blue"] == 1 && colorCollected["red"] == 0 && colorCollected["yellow"] == 1)
            {
                rend.sharedMaterial = materials[(int)color.green];
            }
            else if (colorCollected["blue"] == 0 && colorCollected["red"] == 1 && colorCollected["yellow"] == 1)
            {
                rend.sharedMaterial = materials[(int)color.orange];
            }
            else if (colorCollected["blue"] == 1 && colorCollected["red"] == 1 && colorCollected["yellow"] == 1)
            {
                rend.sharedMaterial = materials[(int)color.brown];
            }

            other.gameObject.SetActive(false);
           
        }
        else if (other.gameObject.CompareTag("Red Pool"))
        {
            colorCollected["red"]++;
            if (colorCollected["blue"] == 0 && colorCollected["red"] == 1 && colorCollected["yellow"] == 0)
            {
                rend.sharedMaterial = materials[(int)color.red];
            }
            else if (colorCollected["blue"] == 1 && colorCollected["red"] == 1 && colorCollected["yellow"] == 0)
            {
                rend.sharedMaterial = materials[(int)color.purple];
            }
            else if (colorCollected["blue"] == 1 && colorCollected["red"] == 0 && colorCollected["yellow"] == 1)
            {
                rend.sharedMaterial = materials[(int)color.green];
            }
            else if (colorCollected["blue"] == 0 && colorCollected["red"] == 1 && colorCollected["yellow"] == 1)
            {
                rend.sharedMaterial = materials[(int)color.orange];
            }
            else if (colorCollected["blue"] == 1 && colorCollected["red"] == 1 && colorCollected["yellow"] == 1)
            {
                rend.sharedMaterial = materials[(int)color.brown];
            }
            other.gameObject.SetActive(false);
            
        }
        else if (other.gameObject.CompareTag("Yellow Pool"))
        {
            colorCollected["yellow"]++;
            if (colorCollected["blue"] == 0 && colorCollected["red"] == 0 && colorCollected["yellow"] == 1)
            {
                rend.sharedMaterial = materials[(int)color.yellow];
            }
            else if (colorCollected["blue"] == 1 && colorCollected["red"] == 1 && colorCollected["yellow"] == 0)
            {
                rend.sharedMaterial = materials[(int)color.purple];
            }
            else if (colorCollected["blue"] == 1 && colorCollected["red"] == 0 && colorCollected["yellow"] == 1)
            {
                rend.sharedMaterial = materials[(int)color.green];
            }
            else if (colorCollected["blue"] == 0 && colorCollected["red"] == 1 && colorCollected["yellow"] == 1)
            {
                rend.sharedMaterial = materials[(int)color.orange];
            }
            else if (colorCollected["blue"] == 1 && colorCollected["red"] == 1 && colorCollected["yellow"] == 1)
            {
                rend.sharedMaterial = materials[(int)color.brown];
            }
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Gate Trigger"))
        {
            if (colorCollected["blue"] == 1 && colorCollected["red"] == 0 && colorCollected["yellow"] == 1)
            {
                //rend.sharedMaterial = materials[(int)color.green];
                doorController.doorOpening = true;
                output.text = "Win";
            }
            else
            {
                output.text = "lose";
            }
        }
    }

}
