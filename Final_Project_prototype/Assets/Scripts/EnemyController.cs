using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public GameObject currentTarget;
    private GameObject changedTarget;
    public float speed;
    public float forceMulti;
    private Rigidbody rb;
    public bool changed,alive;
    private NavMeshAgent agent;
    private const float rotSpeed = 50f;
    public GameObject player1;
    public GameObject player2;
    public GameObject target1;
    public GameObject target2;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updatePosition = false;
        agent.updateRotation = false;
        rb = GetComponent<Rigidbody>();
        speed = 5f;
        forceMulti = 5f;
        changedTarget = currentTarget;
        changed = false;
        alive = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player1 || other.gameObject == player2)
        {
            currentTarget = other.gameObject;
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (alive)
        {
            if (collision.gameObject == player1 || collision.gameObject == player2)
            {
                Destroy(player1);
                Destroy(player2);
                StartCoroutine(lose());
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.enabled)
        {
            agent.SetDestination(currentTarget.transform.position); 
            InstantlyTurn(agent.destination);
            transform.position += transform.forward * Time.deltaTime * speed;
        }



    }


    private void InstantlyTurn(Vector3 destination)
    {
        //When on target -> dont rotate!
        if ((destination - transform.position).magnitude < 0.1f) return;

        Vector3 direction = (destination - transform.position).normalized;
        Quaternion qDir = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, qDir, Time.deltaTime * rotSpeed);
    }

    IEnumerator lose()
    {
        yield return new WaitForSeconds(2);
        Physics.gravity = new Vector3(0, -9.8f, 0);
        if (SceneManager.GetActiveScene().name == "Level 1")
            SceneManager.LoadScene("Level 1");
        else
            SceneManager.LoadScene("Level 2");
    }

}
