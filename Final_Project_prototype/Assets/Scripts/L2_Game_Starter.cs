using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2_Game_Starter : MonoBehaviour
{
    public GameObject botGunButton, botGunButton2, topGunButton, topGunButton2;
    public bool started,botGun;
    // Start is called before the first frame update
    void Start()
    {
        started = false;
        botGun = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            if (botGun)
            {
                botGunButton.GetComponent<bullet_Button>().isOn = true;
                botGunButton2.GetComponent<bullet_Button>().isOn = true;
                botGun = !botGun;
            }
            else
            {
                topGunButton.GetComponent<bullet_Button>().isOn = true;
                topGunButton2.GetComponent<bullet_Button>().isOn = true;
                botGun = !botGun;
            }
            started = false;
        }
    }
}
