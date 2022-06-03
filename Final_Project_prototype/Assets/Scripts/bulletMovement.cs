using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bulletMovement : MonoBehaviour
{
    public float speed;
    private GameObject player1, player2;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Destroy());
        player1 = GameObject.Find("Player 1");
        player2 = GameObject.Find("Player 2");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * (speed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {        
        if (collision.gameObject == player1 || collision.gameObject == player2)
        {
            this.GetComponent<MeshRenderer>().enabled = false;
            Destroy(player1);
            Destroy(player2);
            StartCoroutine(lose());
        }
        
    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(10);
        Destroy(this.gameObject);
    }

    IEnumerator lose()
    {
        yield return new WaitForSeconds(2);
        if (SceneManager.GetActiveScene().name == "Level 1")
            SceneManager.LoadScene("Level 1");
        else
            SceneManager.LoadScene("Level 2");
    }
}
