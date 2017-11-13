using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainview : MonoBehaviour
{

    private int type = 1;
    public Transform target;
    public Vector3 offset;
    public Quaternion rotate;
    private bool tag;
    private Quaternion angular;
    private bool ready1, ready2, ready3, ready4;
    private int a;

    public void Start()
    {
        tag = true;
        // type = 1;
        offset = new Vector3(0f, 10f, -30f);
        ready1 = false;
        ready2 = false;
        ready3 = false;
        ready4 = false;
    }
    public void OnGUI()
    {

        if (GUI.Button(new Rect(Screen.width - 165, 110, 70, 30), "摄像方向"))
        {
            switch (type)
            {
                default:
                    break;
                case 1:
                    Debug.Log("step1!" + type);
                    // transform.Rotate(10, 90, -10);
                    offset = new Vector3(-24.6f, 9.8f, -0.5f);
                    ready1 = true;
                    a = 1;
                    type = 2;
                    break;
                case 2:
                    Debug.Log("step2!" + type);
                    // transform.Rotate(10, 90, -10);
                    offset = new Vector3(0.9f, 10f, 35f);
                    ready2 = true;
                    a = 2;
                    type = 3;
                    break;
                case 3:
                    Debug.Log("step3" + type);
                    // transform.Rotate(10, 90, -10);
                    offset = new Vector3(26.6f, 10f, 1.2f);
                    ready3 = true;
                    a = 3;
                    type = 4;
                    break;
                case 4:
                    Debug.Log("step4!" + type);
                    //  transform.Rotate(10, 90, -10);
                    offset = new Vector3(3.6f, 12f, -31.8f);
                    ready4 = true;
                    a = 4;
                    type = 1;
                    break;
            }



        }
    }



    void Update()
    {
        switch (a)
        {
            default:
                break;
            case 0:
                break;
            case 1:
                if (transform.rotation.y == 90)
                {
                    ready1 = false;
                    a = 0;

                    break;
                }
                if (ready1)
                {
                    angular = Quaternion.Euler(10, 90, 0);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angular, 4.0f);
                }

                break;
            case 2:
                if (transform.rotation.y == 180)
                {
                    ready2 = false;
                    a = 0;

                    break;
                }
                if (ready2)
                {
                    angular = Quaternion.Euler(10, 180, 0);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angular, 5.0f);
                }
                break;

            case 3:
                if (transform.rotation.y == 270)
                {
                    ready3 = false;
                    a = 0;

                    break;
                }
                if (ready3)
                {
                    angular = Quaternion.Euler(10, 270, 0);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angular, 5.0f);
                }
                break;
            case 4:
                if (transform.rotation.y == 360)
                {
                    ready4 = false;
                    a = 0;

                    break;
                }
                if (ready4)
                {
                    angular = Quaternion.Euler(10, 360, 0);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angular, 5.0f);
                }
                break;
        }

        // rotate = Quaternion.Euler(15, 0, 0);
        //transform.rotation = rotate;
        transform.position = target.position + offset;
        Rotate();
        Scale();

    }



    // Update is called once per frame
    /* void Update()
    {
         transform.position = target.position + offset;
         Rotate();
         Scale();
     }*/
    private void Scale()
    {
        float dis = offset.magnitude;
        dis += Input.GetAxis("Mouse ScrollWheel") * 5;
        Debug.Log("dis=" + dis);
        if (dis < 20 || dis > 70)
        {
            return;
        }
        offset = offset.normalized * dis;
    }
    //左右上下移动
    private void Rotate()
    {
        if (Input.GetMouseButton(1))
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Vector3 rot = transform.eulerAngles;

            //围绕原点旋转，也可以将Vector3.zero改为 target.position,就是围绕观察对象旋转
            transform.RotateAround(target.position, Vector3.up, Input.GetAxis("Mouse X") * 10);
            transform.RotateAround(target.position, Vector3.left, Input.GetAxis("Mouse Y") * 10);
            float x = transform.eulerAngles.x;
            float y = transform.eulerAngles.y;
            Debug.Log("x=" + x);
            Debug.Log("y=" + y);
            //控制移动范围
            if (x < 20 || x > 45 || y < 0 || y > 40)
            {
                transform.position = pos;
                transform.eulerAngles = rot;
            }
            //  更新相对差值
            offset = transform.position - target.position;
        }
    }
}


