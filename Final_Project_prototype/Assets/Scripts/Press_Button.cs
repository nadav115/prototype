using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Press_Button : MonoBehaviour
{
    public GameObject first_button;
    public GameObject next_Button;
    public GameObject[] buttons;
    public Material basicMaterial;
    public Material nextMaterial;
    public bool isactive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player 1" || other.gameObject.name == "Player 2")
        {
            if (isactive)
            {
                next_Button.GetComponent<MeshRenderer>().material = nextMaterial;
                this.GetComponent<MeshRenderer>().material = basicMaterial; 
                if(next_Button.name == "Puzzle_Button 4")
                    next_Button.GetComponent<open_door_Button>().isactive = true;
                else
                    next_Button.GetComponent<Press_Button>().isactive = true;
                isactive = false;
            }
            else
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    if(i == 3)                    
                        buttons[i].GetComponent<open_door_Button>().isactive = false;                    
                    else                                          
                        buttons[i].GetComponent<Press_Button>().isactive = false;                    
                    buttons[i].GetComponent<MeshRenderer>().material = basicMaterial;
                }
                first_button.GetComponent<MeshRenderer>().material = nextMaterial;
                first_button.GetComponent<Press_Button>().isactive = true;
            }

            
        }          
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
