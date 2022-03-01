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
        if(other.gameObject.name == enemy.name)
        {
            if(enemy.name == "SimpleEnemy")
                enemy.GetComponent<EnemyController>().currentTarget = otherTarget;
            else
                enemy.GetComponent<bossMovement>().currentTarget = otherTarget;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
