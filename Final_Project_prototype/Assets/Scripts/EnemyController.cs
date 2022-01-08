using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public GameObject currentTarget;
    private GameObject changedTarget;
    public float speed;
    public float forceMulti;
    private Rigidbody rb;
    private Quaternion quaternion;
    private bool changed;
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
        //rb.velocity = currentTarget.transform.position * forceMulti * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player1 || other.gameObject == player2)
        {
            currentTarget = other.gameObject;
            target1.SetActive(false);
            target2.SetActive(false);
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject == player1 || collision.gameObject == player2)
    //    {
    //        Destroy(player1);
    //        Destroy(player2);
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        if (agent.enabled)
        {
            agent.SetDestination(currentTarget.transform.position); // the enemy doesnt respond to gravity changes
            InstantlyTurn(agent.destination);
            transform.position += transform.forward * Time.deltaTime * speed;
        }
        //Vector3 currentPos = transform.position;
        //Vector3 targetPos = currentTarget.transform.position;
        //transform.position = Vector3.MoveTowards(currentPos, new Vector3(targetPos.x, currentPos., targetPos.z), speed * Time.deltaTime);
        //if (!changed)
        //{
        //    transform.LookAt(currentTarget.transform);
        //    //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, transform.rotation.eulerAngles.z);
        //    changed = !changed;
        //}
        //if (currentTarget != changedTarget)
        //{
        //    changedTarget = currentTarget;
        //    changed = !changed;
        //}

        //transform.position += transform.forward * Time.deltaTime * speed;


    }


    private void InstantlyTurn(Vector3 destination)
    {
        //When on target -> dont rotate!
        if ((destination - transform.position).magnitude < 0.1f) return;

        Vector3 direction = (destination - transform.position).normalized;
        Quaternion qDir = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, qDir, Time.deltaTime * rotSpeed);
    }

}
