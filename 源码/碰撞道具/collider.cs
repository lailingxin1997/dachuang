using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider : MonoBehaviour {
    public GameObject wall;
	// Use this for initialization
	void Start () {
        wall = GameObject.Find("change_model4");
    
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "canvas")
        {
            Destroy(GameObject.Find("canvas1"));
            Destroy(GameObject.Find("canvas2"));
            Destroy(GameObject.Find("canvas"));
            
            wall.GetComponent<MeshRenderer>().shadowCastingMode=UnityEngine.Rendering.ShadowCastingMode.On;

        }
    }
}
