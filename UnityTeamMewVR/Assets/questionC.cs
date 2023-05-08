using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questionC : MonoBehaviour
{
    public int question; // which question we on
    public int correctV; // the correct value of the question
    public int numCorrect; // number correct that the player has gotten
    public GameObject selector;
    public int selectorPos;
    // Start is called before the first frame update
    void Start()
    {
        question = 0;
        correctV = 0;
        numCorrect = 0;
        selectorPos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(question == 1)
        {
            correctV = 1;
        }
        else if(question == 2)
        {
            correctV = 0;
        }
        else if (question == 3)
        {
            correctV = 2;
        }
        else if (question == 4)
        {
            correctV = 1;
        }

    }
}
