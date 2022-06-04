using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movment : MonoBehaviour
{
    //public CharacterController controller;
    public float speed = 12f;
    private float gravity = -9.8f;
    public Transform groundCheck;
    public Transform groundCheckTop;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private float jumpHieght = 8f;
    Vector3 velocity;
    bool isGrounded;
    public GameObject player;
    private bool playerNum;
    private float pullforce = -2f;
    private bool gravityChange = true;
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
        if(gravityChange)
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        else
            isGrounded = Physics.CheckSphere(groundCheckTop.position, groundDistance, groundMask);

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
                float num = Mathf.Sqrt(Mathf.Abs(jumpHieght * pullforce * gravity));
                if (!gravityChange)
                    num = -1 * num;
                velocity.y =num;
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
                float num = Mathf.Sqrt(Mathf.Abs(jumpHieght * pullforce * gravity));
                if (!gravityChange)
                    num = -1 * num;
                velocity.y = num;
                player.transform.Translate(velocity * Time.deltaTime);
            }
        }


        if (isGrounded && velocity.y < 0 && gravityChange)
        {
            velocity.y = pullforce;
        }
        else if (isGrounded && velocity.y > 0 && !gravityChange)
        {
            velocity.y = pullforce;
        }
        else if(!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
            player.transform.Translate(velocity * Time.deltaTime);
        }
        
    }


    public void changeGravity()
    {
        Physics.gravity = new Vector3(0, -1 * gravity, 0);
        gravity = -1 * gravity;
        pullforce = -1 * pullforce;
        jumpHieght = -1 * jumpHieght;
        groundCheck.gameObject.SetActive(false);
        groundCheckTop.gameObject.SetActive(true);
        gravityChange = !gravityChange;
    }

    public void changeattribute()
    {
        gravity = -1 * gravity;
        pullforce = -1 * pullforce;
        jumpHieght = -1 * jumpHieght;
        groundCheck.gameObject.SetActive(false);
        groundCheckTop.gameObject.SetActive(true);
        gravityChange = !gravityChange;
    }
}
