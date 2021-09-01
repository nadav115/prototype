using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open_door_Button : MonoBehaviour
{
    public GameObject first_button;
    public Material basicMaterial;
    public Material nextMaterial;
    public GameObject[] allButtons;
    public GameObject wall;
    public bool isactive = false;
    private Animator anim; 
    // Start is called before the first frame update
    void Start()
    {
        anim = wall.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player 1" || other.gameObject.name == "Player 2")
        {
            if(isactive)
            {
                anim.SetBool("toPlay", true); 
                for(int i = 0; i < allButtons.Length; i++)
                {
                    allButtons[i].GetComponent<BoxCollider>().enabled = false;
                }
            }
            else
            {
                this.GetComponent<MeshRenderer>().material = basicMaterial;
                first_button.GetComponent<MeshRenderer>().material = nextMaterial;
                first_button.GetComponent<Press_Button>().isactive = true;
                isactive = false;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
