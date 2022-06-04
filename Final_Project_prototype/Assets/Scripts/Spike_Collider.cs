using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike_Collider : MonoBehaviour
{
    public GameObject player1, player2;

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == player1.name ||
            other.gameObject.name == player2.name)
        {
            Destroy(player1);
            Destroy(player2);
            StartCoroutine(lose());
        }
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
