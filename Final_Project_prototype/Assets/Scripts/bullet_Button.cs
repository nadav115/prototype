using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_Button : MonoBehaviour
{
    public GameObject player1, player2, projectile, projSpot, otherButton, gameStarter;
    public Material onMat, offMat;
    public bool isOn, waiting,standing;
   
    // Start is called before the first frame update
    void Start()
    {
        isOn = false;
        waiting = false;
        standing = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject == player1 || other.gameObject == player2) && waiting)
        {
            standing = true;
            if (otherButton.GetComponent<bullet_Button>().standing)
            {
                GameObject ball = Instantiate(projectile, projSpot.transform.position,projSpot.transform.rotation);

                ball.transform.position = ball.transform.position - projSpot.transform.position.normalized;

                this.GetComponent<MeshRenderer>().material = offMat;
                otherButton.GetComponent<MeshRenderer>().material = offMat;
                otherButton.GetComponent<bullet_Button>().waiting = false;
                waiting = false;
                gameStarter.GetComponent<L2_Game_Starter>().started = true;
            }            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((other.gameObject == player1 || other.gameObject == player2))
        {
            standing = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isOn)
        {
            this.GetComponent<MeshRenderer>().material = onMat;
            waiting = true;
            isOn = false;
        }
    }
}
