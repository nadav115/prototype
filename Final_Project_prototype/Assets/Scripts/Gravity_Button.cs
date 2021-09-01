using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity_Button : MonoBehaviour
{

    public GameObject Player1;
    public GameObject Player2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player 1" || other.gameObject.name == "Player 2")
        {
            Player1.GetComponent<Player_Movment>().changeGravity();
            Player2.GetComponent<Player_Movment>().changeattribute();
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
