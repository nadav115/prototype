using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetChange : MonoBehaviour
{
    public GameObject otherTarget;
    public GameObject enemy;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == enemy.name && enemy.GetComponent<EnemyController>().currentTarget.name != "Player 1" && enemy.GetComponent<EnemyController>().currentTarget.name != "Player 2")
        {
            if(enemy.name == "SimpleEnemy" || enemy.name == "SimpleEnemy2")
                enemy.GetComponent<EnemyController>().currentTarget = otherTarget;
            else
            {
                if(enemy.name == "BOSS")
                    enemy.GetComponent<bossMovement>().currentTarget = otherTarget;
                else
                    enemy.GetComponent<L2BossMovement>().currentTarget = otherTarget;
            }
                
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
