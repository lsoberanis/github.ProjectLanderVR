using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class LeverRotationNormal : MonoBehaviour
{
    [SerializeField] private GameObject lever;
    [SerializeField] private GameObject door;
    [SerializeField] public GameObject question1;
    [SerializeField] public GameObject question2;
    [SerializeField] public GameObject question3;
    [SerializeField] public GameObject question4;
    [SerializeField] public GameObject question5;
    [SerializeField] public questionC questionCount;
    [SerializeField] public GameObject selector;
    [SerializeField] private GameObject DragAndDropBase;
    [SerializeField] private GameObject DataBase;
    [SerializeField] bool correct;

    private Quaternion originalRotation;
    float minRotation = -5;
    float AmaxRotation = 60;
    float maxRotation = 65;
    Vector3 currentRotation;
    private Rigidbody ridg;
    public Vector3 pos;
    [SerializeField] public GameObject controller = null;

    void Start()
    {
        //UnityEngine.Debug.Log("Made it to Start LeverRotationNormal");
        //DragAndDropBase.SetActive(false); 
        //DataBase.SetActive(false);
        question2.SetActive(false);
        question3.SetActive(false);
        question4.SetActive(false);
        question5.SetActive(false);
        originalRotation = lever.transform.rotation;
    }
    
    // Update is called once per frame
    void Update()
    {
        currentRotation = lever.transform.localRotation.eulerAngles;
        currentRotation.y = 180; // manually set it back to this so it prevents any shifting
        currentRotation.z = 0;

        if (currentRotation.x == maxRotation /*|| currentRotation.x == 359*/)
        {

            if (currentRotation.x == maxRotation)
            {

                if (questionCount.correctV == questionCount.selectorPos)
                {
                    questionCount.numCorrect++;
                    //if (qCorrect == 3) { DragAndDrop(); }
                    //else { NextQuestion(); }
                }
                //else
                //{
                //flashing red light?
                // no flashing !!!!!!!!!! im gonsa pass out
                //}
                questionCount.question = questionCount.question + 1;
                NextQuestion();
            }

            currentRotation.x = 0;
            ridg = lever.GetComponent<Rigidbody>();
            ridg.MoveRotation(Quaternion.Euler(currentRotation));

            
        }
        else
        {
            currentRotation.x = Mathf.Clamp(currentRotation.x, minRotation, maxRotation);
            transform.localRotation = Quaternion.Euler(currentRotation);
        }

        lever.GetComponent<Transform>().position = pos;
    }

    void NextQuestion()
    {
        if(question1.activeInHierarchy)
        {
            question1.SetActive(false);
            question2.SetActive(true);
        }
        else if(question2.activeInHierarchy)
        {
            question2.SetActive(false);
            question3.SetActive(true);
        }
        else if (question3.activeInHierarchy)
        {
            question3.SetActive(false);
            question4.SetActive(true);
        }
    }

    void DragAndDrop()
    {

        DragAndDropBase.SetActive(true);
        DataBase.SetActive(true);

    }

    void OpenNormalDoor()
    {
        if(door.activeInHierarchy)
        {
            door.SetActive(false);
        }
    }
}
