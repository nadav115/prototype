using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike_Collider : MonoBehaviour
{
    public GameObject player1, player2;

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == player1.name ||
            other.gameObject.name == player2.name)
        {
            Destroy(player1);
            Destroy(player2);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
