using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class control : MonoBehaviour {

  

    public GameObject light1;
    private GameObject light2;
    private GameObject cameraWhole;
    private GameObject camera;
   

    private Rect rctstartButton;
    private GameObject startobject;

    public float x = 500.0f;
    public float y = 500.0f;

    private bool start;

    // Use this for initialization
    void Start()
    {
        light1 = GameObject.Find("light1");
        light2 = GameObject.Find("light2");
        cameraWhole = GameObject.Find("Camera");
        camera = GameObject.Find("camera01");
      

        light1.GetComponent<Light>().intensity = 0.0f;
        light2.GetComponent<Light>().intensity = 0.0f;
    
      
        camera.SetActive(true);
        cameraWhole.SetActive(false);
      

        rctstartButton = new Rect((Screen.width / 2)-70 , (Screen.height/2)-50, 140, 100);
        startobject = GameObject.Find("startsign");

        start = true;
    }

    // Update is called once per frame
    void Update()
    {
       
       if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            light1.GetComponent<Light>().intensity = 1.0f;
            light2.GetComponent<Light>().intensity = 0.0f;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha1))
        {

            light1.GetComponent<Light>().intensity = 0.0f;
            light2.GetComponent<Light>().intensity = 1.0f;
        }
    }

    void OnGUI()
    {

        GUI.Box(new Rect(Screen.width - 260, 10, 220, 130), "游戏小贴士");
        GUI.Label(new Rect(Screen.width - 245, 30, 250, 30), "数字键1，0 转换光向");
        GUI.Label(new Rect(Screen.width - 245, 50, 250, 30), "进度条到最顶代表生命结束");
        GUI.Label(new Rect(Screen.width - 245, 70, 250, 30), "阴影中的有隐藏改变阴影的小道具");
        GUI.Label(new Rect(Screen.width - 245, 90, 250, 30), "大蘑菇用于改变整个场景的光向");
        //GUI.Label(new Rect(Screen.width - 245, 110, 250, 30), "Left Control : Front Camera");

        if (GUI.Button(new Rect(20, Screen.height-20, 70, 30), "退出游戏"))
        { 
                Application.Quit(); }
        if (GUI.Button(new Rect(Screen.width - 245, 110, 70, 30), "切换视角"))
        {
            if (camera.activeSelf == true) { 
            Debug.Log("change camera!");
            camera.SetActive(false);
            cameraWhole.SetActive(true);}
            else
            {
                camera.SetActive(true);
                cameraWhole.SetActive(false);
            }
        }

       
        //GUI.BeginGroup(new Rect(Screen.width / 2-50, Screen.height / 2 - 50, x, y));
        if (start) {
            if (GUI.Button(rctstartButton, "   点击进入神奇世界   "))
        {
            x = 0;
            y = 0;
            Destroy(startobject);

            light1.GetComponent<Light>().intensity = 1.0f;
                start = false;
        }
        }
     
       // GUI.EndGroup();

    }
 


}
