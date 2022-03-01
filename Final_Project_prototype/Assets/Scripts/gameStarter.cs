using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameStarter : MonoBehaviour
{
    public GameObject[] topFirstButtons, topSecondButtons, botFirstButtons, botSecondButtons;
    public bool started;
    private int choice, choice2;
    // Start is called before the first frame update
    void Start()
    {
        started = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            choice = Random.Range(0, 2);
            if(choice == 0) // top buttons
            {
                choice = Random.Range(0, 3);
                topFirstButtons[choice].GetComponent<bossPuzzleButtons>().isTurned = true;
                choice2 = Random.Range(0, 3);
                topSecondButtons[choice2].GetComponent<bossPuzzleButtons>().isTurned = true;
                topFirstButtons[choice].GetComponent<bossPuzzleButtons>().otherButton = topSecondButtons[choice];
                topSecondButtons[choice2].GetComponent<bossPuzzleButtons>().otherButton = topFirstButtons[choice];
            }
            else // bottom buttons
            {
                choice = Random.Range(0, 3);
                botFirstButtons[choice].GetComponent<bossPuzzleButtons>().isTurned = true;
                choice2 = Random.Range(0, 3);
                botSecondButtons[choice2].GetComponent<bossPuzzleButtons>().isTurned = true;
                botFirstButtons[choice].GetComponent<bossPuzzleButtons>().otherButton = botSecondButtons[choice];
                botSecondButtons[choice2].GetComponent<bossPuzzleButtons>().otherButton = botFirstButtons[choice];
            }
            started = false;
        }
    }
}
