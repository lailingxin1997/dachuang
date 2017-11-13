using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour {

    private GameObject light1;
    private GameObject light2;
    private GameObject camera1;
    private GameObject camera2;    

	// Use this for initialization
	void Start () {
        light1 = GameObject.Find("light1");
        light2 = GameObject.Find("light2");
        camera1 = GameObject.Find("Camera");
        camera2 = GameObject.Find("camera01");
        light1.SetActive(false);
        light2.SetActive(false);
        camera1.SetActive(true);
        camera2.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.A))
        {
            light1.SetActive(true);
            camera1.SetActive(true);
            light2.SetActive(false);
            camera2.SetActive(false);
        }
        else if (Input.GetKeyUp(KeyCode.B))
        {
            light1.SetActive(false);
            camera1.SetActive(false);
            light2.SetActive(true);
            camera2.SetActive(true);
        }
	}
}
