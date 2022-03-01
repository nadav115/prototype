using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    public GameObject boss, gameStarter;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }
 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == boss)
        {            
            boss.GetComponent<bossMovement>().life -= 1;
            if (boss.GetComponent<bossMovement>().life > 0)
                gameStarter.GetComponent<gameStarter>().started = true;
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
