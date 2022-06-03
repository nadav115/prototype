using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class disableEnemy : MonoBehaviour
{

    public GameObject enemy;
    public GameObject cube;
    public GameObject button;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == enemy.name)
        {
            enemy.GetComponent<EnemyController>().alive = false;
            enemy.GetComponent<EnemyController>().enabled = false;
            enemy.GetComponent<NavMeshAgent>().enabled = false;
            cube.GetComponent<BoxCollider>().isTrigger = true;
            anim.SetInteger("passed", 1);
            button.SetActive(true);
            
        }
        else
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
