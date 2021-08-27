using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movment : MonoBehaviour
{
    //public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.8f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHieght = 3f;
    Vector3 velocity;
    bool isGrounded;
    public GameObject player;
    private bool playerNum;
    // Start is called before the first frame update
    void Start()
    {
        if(player.gameObject.name == "Player 1")
        {
            playerNum = true;
        }
        else
        {
            playerNum = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);       

        if (playerNum)
        {
            if (Input.GetKey("a"))
            {
                float z = -speed;
                player.transform.Translate(0, 0, z * Time.deltaTime);
            }

            if (Input.GetKey("d"))
            {
                float z = speed;
                player.transform.Translate(0, 0, z * Time.deltaTime);
            }

            if (Input.GetKey("w") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHieght * -2f * gravity);
                player.transform.Translate(velocity * Time.deltaTime);
            }
        }
        else
        {
            if (Input.GetKey("left"))
            {
                float z = -speed;
                player.transform.Translate(0, 0, z * Time.deltaTime);
            }

            if (Input.GetKey("right"))
            {
                float z = speed;
                player.transform.Translate(0, 0, z * Time.deltaTime);
            }

            if (Input.GetKey("up") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHieght * -2f * gravity);
                player.transform.Translate(velocity * Time.deltaTime);
            }
        }

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        else if(!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
            player.transform.Translate(velocity * Time.deltaTime);
        }
        
    }
}
