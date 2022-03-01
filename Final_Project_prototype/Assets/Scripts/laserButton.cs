using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserButton : MonoBehaviour
{
    public GameObject player1, player2, laser, buttonBase;
    public Material onMat, offMat;
    
    public bool isOn, waiting;

    // Start is called before the first frame update
    void Start()
    {
        isOn = false;
        waiting = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if((other.gameObject == player1 || other.gameObject == player2) && waiting )
        {
            laser.SetActive(true);
            buttonBase.GetComponent<MeshRenderer>().material = offMat;
            waiting = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isOn)
        {
            buttonBase.GetComponent<MeshRenderer>().material = onMat;
            waiting = true;
            isOn = false;
        }
    }

}
