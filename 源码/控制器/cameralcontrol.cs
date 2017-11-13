using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameralcontrol : MonoBehaviour {

    private Transform player;
    private Vector3 offsetPosition;
    // Use this for initialization

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Start()
    {
        //摄像机朝向player
        transform.LookAt(player.position);
        //获取摄像机与player的位置偏移
        offsetPosition = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        //摄像机跟随player与player保持相对位置偏移 
        transform.position = offsetPosition + player.position;
    }
}


