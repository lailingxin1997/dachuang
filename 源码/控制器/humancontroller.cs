using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace cha_data
{
    [RequireComponent(typeof(CharacterController))]
    public class humancontroller : MonoBehaviour
    {
        public CharacterController character;
        public float speed;
        // Use this for initialization
        void Start()
        {
            character = this.GetComponent<CharacterController>();
            speed = 20f;
        }

        // Update is called once per frame
        void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            float moveY = 0;
            float gravity = -9.8f;
            moveY = gravity * Time.deltaTime;
            character.Move(new Vector3(horizontal, moveY, vertical) * speed * Time.deltaTime);
        }
        void Enter() {
            string message;

        }
    }
}
