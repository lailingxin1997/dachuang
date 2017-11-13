using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maincamera : MonoBehaviour {

        public Transform target;
        public Vector3 offset = new Vector3(0f, 10f, -30f);
        public Quaternion rotate;



        private void LateUpdate()
        {
            rotate = Quaternion.Euler(15, 0, 0);
            transform.rotation = rotate;
            transform.position = target.position + offset;
        }
    }

    // Update is called once per frame
   /* void Update()*/
  /*  {
        transform.position = target.position + offset;
        Rotate();
        Scale();
    }
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
        }*/


