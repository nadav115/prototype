using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserButtonSwitch : MonoBehaviour
{
    public GameObject player1, player2, laser;
    public Material onMat, offMat;
    public bool turnedOn;
    // Start is called before the first frame update
    void Start()
    {
        turnedOn = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if((other.gameObject == player1 || other.gameObject == player2) && turnedOn)
        {
            laser.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
