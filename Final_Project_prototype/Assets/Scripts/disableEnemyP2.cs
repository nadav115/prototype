using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class disableEnemyP2 : MonoBehaviour
{
    public GameObject enemy, enemy2;
    public GameObject enemyTarget, enemyTarget2;
    public GameObject cube;
    public Animator anim;
    //public GameObject button;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == enemy.name)
        {
            enemy.GetComponent<EnemyController>().enabled = false;
            enemy.GetComponent<NavMeshAgent>().enabled = false;
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
            enemy2.SetActive(true);
            enemyTarget.GetComponent<targetChange>().enemy = enemy2;
            enemyTarget2.GetComponent<targetChange>().enemy = enemy2;
            //enemy2.GetComponent<EnemyController>()
        }
        else
        {
            if (collision.gameObject.name == enemy2.name)
            {
                enemy2.GetComponent<EnemyController>().enabled = false;
                enemy2.GetComponent<NavMeshAgent>().enabled = false;
                cube.GetComponent<BoxCollider>().isTrigger = true;
                anim.SetInteger("passed", 2);
                //button.SetActive(true);
            }
            else
            {
                Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
            }

        }
            
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
