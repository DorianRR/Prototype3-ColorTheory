using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Color_Transition : MonoBehaviour
{
    public Material materialA;
    public Material materialB;
    public GameObject player;
    public Color PlayerColor = Color.white;
    public float duration = 1.0f;
    public Renderer rend;
        

	// Use this for initialization
	void Start () {
        
        rend = GetComponent<Renderer>();
        rend.material = materialA;

	}

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("White Pool"))
        {
            PlayerColor = player.GetComponent<Renderer>().material.GetColor("_Color");
            materialA.SetColor("_Color", PlayerColor);
            materialB = Resources.Load("Assets/Materials/Ball/Player_Visible/white.mat", typeof(Material)) as Material;

            var sprite = GetComponent<SpriteRenderer>();
            var lerp = Mathf.PingPong(Time.time, duration) / duration;
            rend.material.Lerp(materialA, materialB, lerp);
        }

        else if (other.gameObject.CompareTag("Red Pool"))
        {
            PlayerColor = player.GetComponent<Renderer>().material.GetColor("_Color");
            materialA.SetColor("_Color", PlayerColor);
            materialB = Resources.Load("Assets/Materials/Ball/Player_Visible/red.mat", typeof(Material)) as Material;

            var sprite = GetComponent<SpriteRenderer>();
            var lerp = Mathf.PingPong(Time.time, duration) / duration;
            rend.material.Lerp(materialA, materialB, lerp);
        }

    }

    // Update is called once per frame
    void Update()
    {
       

    }

}
