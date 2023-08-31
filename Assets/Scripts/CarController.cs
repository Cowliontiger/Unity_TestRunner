using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public GameObject car;
    public Vector3 v3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Vector3 GetVector3(String testFlag)
    {
        v3 = new Vector3();
        if (Input.GetKey(KeyCode.D) || testFlag.Equals("forward"))
        {
            //car.transform.Translate(Vector3.forward * Time.deltaTime * 5);
            return Vector3.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            //car.transform.Translate(Vector3.back * Time.deltaTime * 5);
            return Vector3.back;
        }
        if (Input.GetKey(KeyCode.W))
        {
            //car.transform.Translate(Vector3.left * Time.deltaTime);
            return Vector3.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //car.transform.Translate(Vector3.right * Time.deltaTime);
            return Vector3.right;
        }
        else
        {
            return v3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.D))
        //{
        //    car.transform.Translate(Vector3.forward * Time.deltaTime * 5);
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    car.transform.Translate(Vector3.back * Time.deltaTime * 5);
        //}
        //if (Input.GetKey(KeyCode.W))
        //{
        //    car.transform.Translate(Vector3.left * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    car.transform.Translate(Vector3.right * Time.deltaTime);
        //}
        car.transform.Translate(GetVector3("") * Time.deltaTime * 5);
    }
}
