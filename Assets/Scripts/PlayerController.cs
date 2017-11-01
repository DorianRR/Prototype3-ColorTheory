using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;



public class PlayerController : MonoBehaviour {
    enum color { white, blue, red, yellow, orange, purple, green, brown};
    public Transform camTransform;
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
        float moveHoriz = Input.GetAxis("Horizontal");
        float moveVert = Input.GetAxis("Vertical");
        float moveUp = 0;
        Vector3 movement = new Vector3(moveHoriz, 0, moveVert);
        Quaternion rot = Quaternion.Euler(0, camTransform.rotation.eulerAngles.y, 0);
        transform.rotation = rot;
        movement = rot * movement;
        transform.position += movement * speed * Time.deltaTime;
        if (this.transform.position.y < 0.51)
        {

            if (Input.GetButton("Jump"))
            {
                moveUp =10;
            }
            else
            {
                moveUp = 0;
            }
            Vector3 jmpForece = new Vector3(0, moveUp, 0);
            rb.AddForce(jmpForece * 40);
        }
        
        /*
        trueRight = rot * Vector3.right;
        trueDown = rot * Vector3.back;
        rb.AddTorque(trueRight*moveVert*speed, ForceMode.Acceleration);
        rb.AddTorque(trueDown * moveHoriz * speed, ForceMode.Acceleration);
        */


        /*
        if (Input.GetButton("Jump"))
        {
            moveUp = 5;
        }
        else
        {
            moveUp = 0;
        }
        movement.y = moveUp;
       
        if (this.transform.position.y < 0.51)
        {
            rb.drag = 10;
            rb.AddForce(movement * speed);
        }
        else
        {
            rb.drag = 0;
        }
        */
    }
    private void OnTriggerEnter(Collider other)
    {
        
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
            isWhite = false;
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
            isWhite = false;
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
            isWhite = false;
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
