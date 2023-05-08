using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class MainDisplayControl : MonoBehaviour, IDial
{
    [SerializeField] public GameObject currentMode;
    [SerializeField] public GameObject easyMode;
    [SerializeField] public GameObject normalMode;
    [SerializeField] public GameObject hardMode;
    [SerializeField] public GameObject selector;
    [SerializeField] public GameObject selectorB;
    [SerializeField] public GameObject selectorC;
    [SerializeField] public GameObject selectorD;
    [SerializeField] public questionC questionCount;

    private Vector3 currentRotation;


    void Start()
    {
        //GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 200f, 200f), "start");
        easyMode.SetActive(false);
        hardMode.SetActive(false);
        selector.SetActive(false);
        //currentRotation = selector.transform.localRotation.eulerAngles;

    }

    public void DialChanged(float dialvalue, int condition)
    {
        var perc = (dialvalue / 360f) * 100;

        if (condition == 0)
        {

            if (perc <= 100 && perc > 90)
            {
                currentMode.SetActive(false);
                currentMode = easyMode;
                currentMode.SetActive(true);
            }
            else if (perc <= 90 && perc > 80)
            {
                currentMode.SetActive(false);
                currentMode = normalMode;
                currentMode.SetActive(true);
            }
            else if (perc <= 80 && perc >= 70)
            {
                currentMode.SetActive(false);
                currentMode = hardMode;
                currentMode.SetActive(true);
            }

        }
        else
        {
            if (questionCount.question >= 5) // for the formulas
            {
                if (perc <= 100 && perc > 90) // a dial is 97.2
                { // pos 1
                    selector.SetActive(true);
                    selector.transform.position = new Vector3(-18.103f, 8.186f, 1.87f);
                    questionCount.selectorPos = 0;
                }
                else if (perc <= 90 && perc > 82) // b dial is 88.8
                { // pos 2
                    selector.SetActive(true);
                    selector.transform.position = new Vector3(-18.123f, 8.007f, 1.904f);
                    questionCount.selectorPos = 1;
                }
                else if (perc <= 82 && perc >= 73) // c dial is 80.5
                { // pos 3
                    selector.SetActive(true);
                    selector.transform.position = new Vector3(-18.148f, 7.837f, 1.948f);
                    questionCount.selectorPos = 2;
                }
                else
                {
                    selector.SetActive(true);
                    selector.transform.position = new Vector3(-18.148f, 7.837f, 1.948f);
                    questionCount.selectorPos = -1;
                }
            }
            else
            {
               
                if (perc <= 100 && perc > 90) // a dial is 97.2
                { // pos 1
                    selector.SetActive(true);
                    selectorB.SetActive(false);
                    selectorC.SetActive(false);
                    selectorD.SetActive(false);
                    //selector.transform.position = new Vector3(-25.0240002f, 8.27700043f, -4.97100019f);
                    questionCount.selectorPos = 0;
                }
                else if (perc <= 90 && perc > 82) // b dial is 88.8
                { // pos 2
                    selector.SetActive(false);
                    selectorB.SetActive(true);
                    selectorC.SetActive(false);
                    selectorD.SetActive(false);
                    //selector.transform.position = new Vector3(-25.0459995f, 8.20100021f, -4.96990013f);
                    questionCount.selectorPos = 1;
                }
                else if (perc <= 82 && perc >= 73) // c dial is 80.5
                { // pos 3
                    selector.SetActive(false);
                    selectorB.SetActive(false);
                    selectorC.SetActive(true);
                    selectorD.SetActive(false);
                    //selector.transform.position = new Vector3(-25.066f, 8.131f, -4.9699f);
                    questionCount.selectorPos = 2;
                }
                else if (perc <= 73 && perc >= 64) // d dial is 72.2
                { // pos 4
                    selector.SetActive(false);
                    selectorB.SetActive(false);
                    selectorC.SetActive(false);
                    selectorD.SetActive(true);
                    //selector.transform.position = new Vector3(-25.087f, 8.057f, -4.9699f);
                    questionCount.selectorPos = 3;
                }
                //else if(perc < 64 && perc >= 32)
                //{
                //    //selector.transform.position = new Vector3(-25.0240002f, 8.27700043f, -4.97100019f);
                //    //selector.SetActive(false);
                //    //questionCount.selectorPos = -1;
                //    currentRotation.z = -115;
                //    selector.transform.localRotation = Quaternion.Slerp(selector.transform.rotation, Quaternion.Euler(currentRotation), 1.0f);

                //}
                //else
                //{
                //    currentRotation.z = -10;
                //    selector.transform.localRotation = Quaternion.Slerp(selector.transform.rotation, Quaternion.Euler(currentRotation), 1.0f);
                //}
            }
        }
        
    }
}
