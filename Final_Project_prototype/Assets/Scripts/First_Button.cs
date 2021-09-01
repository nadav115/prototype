using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First_Button : MonoBehaviour
{

    private int counter = 0;
    //private int otherbuttoncounter;
    public GameObject wall;
    public GameObject otherButton;
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        //int otherbuttoncounter =  otherButton.GetComponent<First_Button>().counter;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player 1" || other.gameObject.name == "Player 2")
        {
            counter++;
            if (counter == 2)
            {
                wall.gameObject.SetActive(true);
                this.gameObject.SetActive(false);
                button.SetActive(true);
                otherButton.SetActive(false);
            }
            otherButton.GetComponent<First_Button>().counter++;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player 1" || other.gameObject.name == "Player 2")
        {
            counter--;
            otherButton.GetComponent<First_Button>().counter--;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
