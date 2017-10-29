using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplatCollision : MonoBehaviour
{
    public GameObject SplatPrefab = null;
    public Material SplatMat = null;
    public Material PlayerMat = null;
    //public Color SplatColor = Color.blue;
    public Color PlayerColor = Color.white;

    int nextSplatNumber = 0;



    private void Start()
    {

    }

    private void Update()
    {
        //Query Player material.
        //PlayerMat = GameObject.Find("Player").GetComponent<Renderer>().material;

        //Query Splat material.
        //SplatMat = GameObject.Find("Prefabs/decal_splat").GetComponent<Renderer>().material;

        //Query color of player's material.
        //PlayerColor = GameObject.Find("Player").GetComponent<Renderer>().material.GetColor("_Color");

        //Query color of splat material.
        //SplatColor = GameObject.Find("Prefabs/decal_splat").GetComponent<Renderer>().material.GetColor("_Color");

        //Sets color of splat to match color of player.
        //GameObject.Find("decal_splat(Clone)").GetComponent<Renderer>().material.SetColor("_Color", PlayerColor);
    }

    private void OnCollisionEnter(Collision collision)
    {

        //Query color of player's material.
        PlayerColor = GameObject.Find("Player").GetComponent<Renderer>().material.GetColor("_Color");


        if (collision.gameObject.tag == "Wall")
        {
            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            SplatPrefab = Instantiate(Resources.Load("Prefabs/decal_splat"), pos, rot) as GameObject;
            SplatPrefab.name = "Splat" + nextSplatNumber;
            GameObject.Find("Splat"+nextSplatNumber).GetComponent<Renderer>().material.SetColor("_Color", PlayerColor);

            nextSplatNumber++;
        }

        //if (collision.gameObject.tag == "Floor")
        //{
        //    ContactPoint contact = collision.contacts[0];
        //    Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        //    Vector3 pos = contact.point;
        //    SplatPrefab = Instantiate(Resources.Load("Prefabs/decal_splat"), pos, rot) as GameObject;
        //}
    }
}
    