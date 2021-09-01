using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{

    private int counter = 0;
    public Canvas text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player 1" || other.gameObject.name == "Player 2")
        {
            counter++;
            if (counter == 2)
                text.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player 1" || other.gameObject.name == "Player 2")
        {
            counter--;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
