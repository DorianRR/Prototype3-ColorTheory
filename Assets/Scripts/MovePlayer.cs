using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour {

    //private float xRotation = 0.0f;
    //private float verticalInput = 0.0f;

    enum color { white, blue, red, yellow, orange, purple, green, brown };
    public float speed;
    public Material[] materials;
    public Text output;

    public Renderer rend;
    public GameObject[] ColorPool;

    private Rigidbody rb;
    private Dictionary<string, int> colorCollected = new Dictionary<string, int>();
    // Use this for initialization

    void Start () {
        output.text = "";
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        colorCollected.Add("blue", 0);
        colorCollected.Add("red", 0);
        colorCollected.Add("yellow", 0);
    }

    // Update is called once per frame
    void FixedUpdate() {

        //CharacterController controller = GetComponent<CharacterController>();

        transform.Rotate((transform.up * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Mouse X")).normalized * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("White Pool"))
        {
            rend.sharedMaterial = materials[0];
            for (int i = 0; i < 3; i++)
            {
                ColorPool[i].SetActive(true);
            }
            colorCollected["blue"] = 0;
            colorCollected["red"] = 0;
            colorCollected["yellow"] = 0;
        }
        else if (other.gameObject.CompareTag("Blue Pool"))
        {
            colorCollected["blue"]++;
            if (colorCollected["blue"] == 1 && colorCollected["red"] == 0 && colorCollected["yellow"] == 0)
            {
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
                output.text = "Win";
            }
            else
            {
                output.text = "lose";
            }
        }
    }

  }

