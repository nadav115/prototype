using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossPuzzleButtons : MonoBehaviour
{
    public bool isTurned, standOn, waiting;
    public Material offMat, onMat;
    public GameObject laserButton, otherButton;
    public GameObject player1, player2;

    // Start is called before the first frame update
    void Start()
    {
        isTurned = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if((other.gameObject == player1 || other.gameObject == player2) && waiting)
        {
            standOn = true;
            if(otherButton.GetComponent<bossPuzzleButtons>().standOn)
            {            
                laserButton.GetComponent<laserButton>().isOn = true;
                this.GetComponent<MeshRenderer>().material = offMat;
                otherButton.GetComponent<MeshRenderer>().material = offMat;
                waiting = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player1 || other.gameObject == player2)
        {
            standOn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isTurned)
        {
            this.GetComponent<MeshRenderer>().material = onMat;
            waiting = true;
            isTurned = false;
        }
    }
}
