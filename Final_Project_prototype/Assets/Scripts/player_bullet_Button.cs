using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_bullet_Button : MonoBehaviour
{
    private GameObject boss;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.Find("BOSS2");
        StartCoroutine(Destroy());
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == boss.name)
        {
            boss.GetComponent<L2BossMovement>().life -= 1;
            print(boss.GetComponent<L2BossMovement>().life);
        }
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * (speed * Time.deltaTime);
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(10);
        Destroy(this.gameObject);
    }
}
