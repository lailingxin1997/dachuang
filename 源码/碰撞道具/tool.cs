using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class tool : MonoBehaviour {
    //转换大方向的道具
    private GameObject changewhole;
    //模型
    private GameObject change_model1;
    private GameObject change_model2;
    //模型的transform
    private Transform tool1;
    private Transform tool2;

    private Transform lightchange1;

    private GameObject cameramain;
    private GameObject cameraup;

    private GameObject change1;
    private GameObject change2;
    private GameObject change3;// 道具变幻的摄像机

    private GameObject actor;
    private GameObject box;
    //public Texture2D map;
    public Texture2D blood_red;
    //黑色血条贴图
    public Texture2D blood_black;
    public float blood_width;
    //默认NPC血值
    private int HP = 100;
    public GUISkin theSkin;
    public float bloodValue = 0.0f;
    public float tmpValue;
    private Rect rctBloodBar;
    private Rect rctUpButton;

    private bool onoff;
    private bool ready1,ready2,ready3, ready4, ready5, ready6, ready7, ready8, ready9, ready10, ready11, ready12;
    private bool addForce;
    private bool block;
    private bool end;
    private bool effet;

    private bool fail;

    private float limit1;

    private Quaternion target;
    private Quaternion changelight1;
    private Quaternion changelight2;

    private int type;
    private int tag1;
    private int ctime;
    private int i = 0;

    public GameObject lightone;
    public GameObject lighttwo;

    private GameObject music;

    private Transform light1transform;
    private Transform light2transform;
    private bool control3;
    private GameObject ball;


    // Use this for initialization
    void Start () {
        
        changewhole = GameObject.Find("changewhole");
        //更改的模型
        change_model1 = GameObject.Find("change_model1");
        change_model2 = GameObject.Find("change_model2");
        music = GameObject.Find("music");
        //更改模型的transform
        tool1 = change_model1.transform;
        tool2 = change_model2.transform;

        lightchange1 = changewhole.transform;

        cameramain = GameObject.Find("camera01");
        cameraup = GameObject.Find("Camera0");
        change1 = GameObject.Find("camera_change1");
        change2 = GameObject.Find("camera_change2");
        change3 = GameObject.Find("camera_change3");
      
        control3 = GameObject.Find("control3");
        control3 = false;
        ready2 = false;
        ready1 = false;
        ready3 = false;
        ready4 = false;
        ready5 = false;
        ready6 = false;
        ready7 = false;
        ready8 = false;
        ready9 = false;
        ready10 = false;
        ready11 = false;
        ctime = 0;
        end = false;
        effet = false;
        fail = false;
        addForce = false;
        block = false;
        target = Quaternion.Euler(0, 0, 90);


        type = 0;

        limit1 = 0.0f;

        lightone = GameObject.Find("light1");
        lighttwo = GameObject.Find("light2");

        light1transform = lightone.transform;
        light2transform = lighttwo.transform;


        rctBloodBar = new Rect(20, 20, 20, 200);
        rctUpButton = new Rect(50, 20, 40, 20);

        tag1 = 0;

        ball = GameObject.Find("ball");

        actor = GameObject.Find("unitychan");


    }

// Update is called once per frame
void Update () {
        if(bloodValue==1.0f)
        {
            Debug.Log("failed");
            fail = true;
            Time.timeScale = 0;
        }
        if(effet)
        {
           
            GameObject.Find("effect").GetComponent<AudioSource>().mute = false;
        }
        else
        {
            GameObject.Find("effect").GetComponent<AudioSource>().mute = true;
        }
        switch (type)
        {
            default:
                break;
            case 0: break;
            case 1:
                if (tool1.localRotation.x==limit1)
                {
                    effet = false;
                    ready1 = false;
                    cameramain.SetActive(true);
                    change1.SetActive(false);
                    change2.SetActive(false);
                    change3.SetActive(false);

                    type = 0;
                 }
                 if (ready1 == true)
                {
                   tool1.rotation = Quaternion.RotateTowards(tool1.rotation, target, 0.40f);
                 }
                break;
            case 2:
                if ((54-tool2.localPosition.y)>33)
                    {
                    effet = false;
                    ready2 = false;
                      cameramain.SetActive(true);
                      change2.SetActive(false);
                      change1.SetActive(false);
                      change3.SetActive(false);
                    type = 0;
                   }
                if(ready2==true)
                {
                
                    tool2.localPosition = new Vector3(tool2.localPosition.x, Mathf.Lerp(tool2.localPosition.y, 20, (float)(Time.deltaTime * 0.5)), tool2.localPosition.z); 
                }

                break;
            case 3:
                if((actor.transform.localPosition.z)>439f)
                {
                    effet = false;
                    type = 0;
                    ready3 = false;
                    break;
                }
                if (ready3)
                {
                    actor.transform.localPosition = new Vector3(Mathf.Lerp(actor.transform.localPosition.x, 358.3f, (float)(Time.deltaTime * 2.0)), Mathf.Lerp(actor.transform.localPosition.y, 17.5f, (float)(Time.deltaTime * 2.0)), Mathf.Lerp(actor.transform.localPosition.z, 439.5f, (float)(Time.deltaTime * 2.0)));
                }
                break;

            case 4:
                if ((actor.transform.localPosition.x) > 449f)
                {
                    effet = false;
                    type = 0;
                    ready4 = false;
                    break;
                }
                if (ready4)
                {
                    actor.transform.localPosition = new Vector3(Mathf.Lerp(actor.transform.localPosition.x, 449.7f, (float)(Time.deltaTime * 2.0)), Mathf.Lerp(actor.transform.localPosition.y, 0.0f, (float)(Time.deltaTime * 2.0)), Mathf.Lerp(actor.transform.localPosition.z, 423.1f, (float)(Time.deltaTime * 2.0)));
                }
                break;
            case 5:
                if ((actor.transform.localPosition.x) < 444f)
                {
                    effet = false;
                    type = 0;
                    ready5 = false;
                    break;
                }
                if (ready5)
                {
                    actor.transform.localPosition = new Vector3(Mathf.Lerp(actor.transform.localPosition.x, 443.3f, (float)(Time.deltaTime *2.0)), Mathf.Lerp(actor.transform.localPosition.y,20f, (float)(Time.deltaTime * 2.0)), Mathf.Lerp(actor.transform.localPosition.z, 373.0f, (float)(Time.deltaTime * 2.0)));
                }
                break;

            case 6:
                if ((actor.transform.localPosition.y) < 1.0f)
                {
                    effet = false;
                    type = 0;
                    ready6 = false;
                    break;
                }
                if (ready6)
                {
                    actor.transform.localPosition = new Vector3(Mathf.Lerp(actor.transform.localPosition.x, 466f, (float)(Time.deltaTime * 2.0)), Mathf.Lerp(actor.transform.localPosition.y, 0.0f, (float)(Time.deltaTime * 2.0)), Mathf.Lerp(actor.transform.localPosition.z, 303.0f, (float)(Time.deltaTime * 2.0)));
                }
                break;
            case 7:
                if ((actor.transform.localPosition.x) < 450f)
                {
                    effet = false;
                    type = 0;
                    ready7 = false;
                    break;
                }
                if (ready7)
                {
                    actor.transform.localPosition = new Vector3(Mathf.Lerp(actor.transform.localPosition.x, 449f, (float)(Time.deltaTime * 2.0)), 0.0f, Mathf.Lerp(actor.transform.localPosition.z, 275.0f, (float)(Time.deltaTime * 2.0)));
                }
                break;

            case 8:
                if ((actor.transform.localPosition.x) <439f)
                {
                    effet = false;
                    type = 0;
                    ready8 = false;
                    break;
                }
                if (ready8)
                {
                    actor.transform.localPosition = new Vector3(Mathf.Lerp(actor.transform.localPosition.x, 437f, (float)(Time.deltaTime * 2.0)), Mathf.Lerp(actor.transform.localPosition.y, 4.5f, (float)(Time.deltaTime * 2.0)), Mathf.Lerp(actor.transform.localPosition.z, 317f, (float)(Time.deltaTime * 2.0)));
                }
                break;

            case 9:
                if ((actor.transform.localPosition.y) < 1.0f)
                {
                    effet = false;
                    type = 0;
                    ready9 = false;
                    break;
                }
                if (ready9)
                {
                    actor.transform.localPosition = new Vector3(Mathf.Lerp(actor.transform.localPosition.x, 470f, (float)(Time.deltaTime * 2.0)), Mathf.Lerp(actor.transform.localPosition.y, 0f, (float)(Time.deltaTime * 2.0)), Mathf.Lerp(actor.transform.localPosition.z, 310f, (float)(Time.deltaTime * 2.0)));
                }
                break;

            case 10:
                if ((actor.transform.localPosition.x) < 439f)
                {
                    effet = false;
                    type = 0;
                    ready10 = false;
                    break;
                }
                if (ready10)
                {
                    actor.transform.localPosition = new Vector3(Mathf.Lerp(actor.transform.localPosition.x, 437f, (float)(Time.deltaTime * 2.0)), Mathf.Lerp(actor.transform.localPosition.y, 4.5f, (float)(Time.deltaTime * 2.0)), Mathf.Lerp(actor.transform.localPosition.z, 274f, (float)(Time.deltaTime * 2.0)));
                }
                break;

            case 11:
                if ((actor.transform.localPosition.y) < 1f)
                {
                    effet = false;
                    type = 0;
                    ready11 = false;
                    break;
                }
                if (ready11)
                {
                    actor.transform.localPosition = new Vector3(Mathf.Lerp(actor.transform.localPosition.x, 440f, (float)(Time.deltaTime * 2.0)), Mathf.Lerp(actor.transform.localPosition.y, 0.0f, (float)(Time.deltaTime * 2.0)), Mathf.Lerp(actor.transform.localPosition.z, 245, (float)(Time.deltaTime * 2.0)));
                }
                break;
                
        }
       
    

    }
    private void OnGUI()
    {
       
       
        if (bloodValue > 1.0f) bloodValue = 1.0f;
        if (bloodValue < -1.0f) tmpValue = -1.0f;

        GUI.VerticalScrollbar(rctBloodBar, 1.0f, bloodValue, 0.0f, 1.0f, GUI.skin.GetStyle("verticalScrollbar"));
        GUIStyle bb = new GUIStyle();
        bb.normal.background = null;    //这是设置背景填充的
        bb.normal.textColor = Color.gray;   //设置字体颜色的
        bb.fontSize = 20;       //当然，这是字体颜色
        GUI.skin = theSkin;


        GUIStyle aa = new GUIStyle();
        aa.normal.textColor = Color.white;   //设置字体颜色的
        aa.fontSize = 16;       //当然，这是字体颜色


        if (fail)
        {
            GUI.Box(new Rect((Screen.width/2)-105, (Screen.height/2)-65, 250, 100), "游戏结束");
            GUI.Label(new Rect((Screen.width/2)-90,(Screen.height/2-30), 200, 30), "失败，被阳光给晒融化了",aa);
            if (GUI.Button(new Rect((Screen.width / 2) - 80, (Screen.height / 2), 80, 30), "重新开始"))
            {
                Debug.Log("重新开始");
                SceneManager.LoadScene("scence1");
                bloodValue = 0.0f;
                fail = false;
                //GameObject.Find("end").GetComponent<AudioSource>().mute =true;
               
            }
            if(GUI.Button(new Rect((Screen.width / 2), (Screen.height / 2), 80, 30), "退出游戏"))
            {
                Application.Quit();
            }
        }
    
        if(ready1)
        {
            GUI.Box(new Rect((Screen.width /3-20), (Screen.height/2), 240, 40),"");
            GUI.Label(new Rect((Screen.width/3), (Screen.height/2+8), 230, 30),"物体旋转精灵启动",bb);
        }
        if(ready2)
        {
            GUI.Box(new Rect((Screen.width / 3-20), (Screen.height / 2), 240, 40), "");
            GUI.Label(new Rect((Screen.width / 3), (Screen.height / 2+8), 230, 30), "物体移动精灵启动", bb);
        }
        if (addForce)
        {
            GUI.Box(new Rect((Screen.width / 3-20), (Screen.height / 2), 240, 40), "");
            GUI.Label(new Rect((Screen.width / 3), (Screen.height / 2+8), 230, 30), "物体助力精灵启动", bb);
        }
        if (ready3)
        {
            GUI.Box(new Rect((Screen.width / 3-20), (Screen.height / 2), 240, 40), "");
            GUI.Label(new Rect((Screen.width / 3), (Screen.height / 2+8), 230, 30), "反重力精灵启动", bb);
        }
        if (ready4)
        {
            GUI.Box(new Rect((Screen.width / 3-20), (Screen.height / 2), 240, 40), "");
            GUI.Label(new Rect((Screen.width / 3), (Screen.height / 2+8), 230, 30), "反重力精灵启动", bb);
        }
        if (ready5)
        {
            GUI.Box(new Rect((Screen.width / 3-20), (Screen.height / 2), 240, 40), "");
            GUI.Label(new Rect((Screen.width / 3), (Screen.height / 2+8), 230, 30), "反重力精灵启动", bb);
        }
        if (block)
        {
            if(ctime!=540)
            {   
                GUI.Box(new Rect((Screen.width / 3-40), (Screen.height / 2), 400, 40), "");
                GUI.Label(new Rect((Screen.width / 3), (Screen.height /2+8), 300, 30), "这里穿不过噢，试试其他办法吧", bb);
                ctime++;
            }

        }
        if (end)
        {
            music.GetComponent<AudioSource>().mute = true;
            GUI.Box(new Rect((Screen.width / 2) - 105, (Screen.height / 2) - 65, 250, 100), "游戏结束");
            GUI.Label(new Rect((Screen.width / 2) - 90, (Screen.height / 2 - 30), 200, 30), "你成功的越过了阳光地带", aa);
            if (GUI.Button(new Rect((Screen.width / 2) - 80, (Screen.height / 2), 80, 30), "重新开始"))
            {
                
                Debug.Log("重新开始");
                SceneManager.LoadScene("scence1");
                //GameObject.Find("end").GetComponent<AudioSource>().mute = true;
                bloodValue = 0.0f;
                end = fail;


            }
            if (GUI.Button(new Rect((Screen.width / 2), (Screen.height / 2), 80, 30), "退出游戏"))
            {
                Application.Quit();
            }
        }
       
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "change1")
        {
            effet = true;
            Destroy(GameObject.Find("change1"));
            type = 1;
            cameramain.SetActive(false);
            change1.SetActive(true);
            change2.SetActive(false);
            change3.SetActive(false);
            ready1 = true;
            
       
        
        }
        if(collision.gameObject.name == "change2")
        {
            effet = true;
            Destroy(GameObject.Find("change2"));
            type = 2;
            cameramain.SetActive(false);
            change2.SetActive(true);
            change1.SetActive(false);
            change3.SetActive(false);
            ready2 = true;
        


        }
        if (collision.gameObject.name == "changewhole")
        {
           
            if ((tag1%2)==0) {
                lightchange1.localScale = new Vector3(3, 3, 3);
                tag1++;
                //changelight1 = Quaternion.Euler(15, 140, 0);
                //changelight2 = Quaternion.Euler(15, 20, 0);
                light1transform.rotation = Quaternion.Euler(15, 20, 0);
                light2transform.rotation = Quaternion.Euler(15, 140, 0);
                //light1transform.rotation = Quaternion.RotateTowards(light1transform.rotation, changelight1, 0.1f);
                //light2transform.rotation = Quaternion.RotateTowards(light2transform.rotation, changelight2, 0.1f);
                

            }
            else
            {
                lightchange1.localScale = new Vector3(1, 1, 1);
                tag1++;
                light1transform.rotation = Quaternion.Euler(15, 308, 0);
                light2transform.rotation = Quaternion.Euler(15, 65, 0);
                 }
        }
        if (collision.gameObject.name == "change3")
        {
         
            addForce = true;
            Destroy(GameObject.Find("change3"));
            //type = 3;
            cameramain.SetActive(false);
            change2.SetActive(false);
            change1.SetActive(false);
            change3.SetActive(true);
            Waitturn(2);
            addForce = false;
            ball.GetComponent<Rigidbody>().AddForce(160f, 0.0f, 74f);

           // wait(8);
            // ready3 = true;
            
        }
        if(collision.gameObject.name=="UP")
        {
            effet = true;
            //Destroy(GameObject.Find("UP"));
            type = 3;
            ready3 = true;
        }

        if (collision.gameObject.name == "DOWN")
        {
            effet = true;
            //Destroy(GameObject.Find("DOWN"));
            type = 4;
            ready4 = true;
        }

        if (collision.gameObject.name == "UP1")
        {
            effet = true;
            //Destroy(GameObject.Find("UP1"));
            type = 5;
            ready5 = true;
            
        }

        if (collision.gameObject.name == "DOWN1")
        {
            effet = true;
            //Destroy(GameObject.Find("DOWN1"));
            type = 6;
            ready6 = true;
        }

        if (collision.gameObject.name == "UP2")
        {
            effet = true;
            //Destroy(GameObject.Find("UP2"));
            type = 7;
            ready7 = true;
        }

        if (collision.gameObject.name == "UP3")
        {
            effet = true;
            //Destroy(GameObject.Find("UP3"));
            type = 8;
            ready8 = true;
        }

        if (collision.gameObject.name == "move3")
        {
            effet = true;
            //Destroy(GameObject.Find("move3"));
            type = 9;
            ready9 = true;
        }

        if (collision.gameObject.name == "move2")
        {
            effet = true;
            //Destroy(GameObject.Find("move2"));
            type = 10;
            ready10 = true;
        }

        if (collision.gameObject.name == "right1")
        {
            effet = true;
            // Destroy(GameObject.Find("right1"));
            type = 11;
            ready11 = true;
        }
        if(collision.gameObject.name =="stop")
        {
            ctime = 0;
            Debug.Log("block");
            block = true;
            Debug.Log(block);

        }
        if (collision.gameObject.name == "end")
        {
            // Destroy(GameObject.Find("change_direction"));
           
            GameObject.Find("end").GetComponent<AudioSource>().mute = false;
            end = true;
           
        }
    }
    IEnumerator Waitturn(float waitTime)
    {
       
        yield return new WaitForSeconds(waitTime);
        //等待之后执行的动作  
    }
    IEnumerator Waitcancle(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);
        block = false;
        //等待之后执行的动作  
    }
    IEnumerable wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        change3.SetActive(false);
        cameramain.SetActive(true);
        change2.SetActive(false);
        change1.SetActive(false);
        
    }
    public void enter()
    {
        bloodValue += 0.1f * Time.deltaTime;
       
    }

}
