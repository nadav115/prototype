using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingDoor : MonoBehaviour
{

    private int counter = 0;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player 1" || collision.gameObject.name == "Player 2")
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player 1" || other.gameObject.name == "Player 2")
        {
            counter++;
            if (counter == 2)
            {
                anim.SetInteger("passed", 1);
                this.enabled= false;
            }
                
                
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
