using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // IMPORTANT!!!!!!!!
using TMPro;

public class DebugText : MonoBehaviour
{
    public int scoreCounter;
    public int counter = 1;
    //public GameObject UITextElement;
    public GameObject variables;
    //public Text myText;
    public TMP_Text txt;
    public GameObject lever;
    public GameObject lever2;
    public GameObject dial;
    public questionC qC;
    public variableC vC;
    private const string format = "{0}\n{1}";
    private const string format2 = "Question Count:\n{0}\nCorrect:\n{1}";
    private const string format3 = "Start Position:\nEnd Position:\nThrusters Active:\n\nStart Velocity:\nEnd Velocity:\n\nMass:\nGravity:";
    private const string format4 = "var1: {0}\nvar2: {1}\nvar3: {2}\nvar4: {3}\nvar5: {4}\nvar6: {5}\nvar7: {6}\n var index: {7}";
    private const string format5 = "vf: {0}\nvi: {1}\ng: {2}\nxf: {3}\nxi: {4}";
    private const string format6 = "vf: {0}\ng: {1}\nd1: {2}\ng: {3}\nFt: {4}\nm: {5}\nd2: {6}\n";
    private const string format7 = "Ft: {0}\nm: {1}\nvf: {2}\ng: {3}\ndi: {4}\nd2: {5}";
    public int DebugSetting;


    void Start()
    {

        //UITextElement.GetComponent<Text>().text = scoreCounter.ToString();
    }

    void Update()
    {
        //UITextElement.GetComponent<Text>().text = scoreCounter.ToString();
        //myText.text = scoreCounter.ToString();
        if (DebugSetting == 0)
        {
            string temp1 = lever.transform.rotation.eulerAngles.ToString();
            string temp2 = lever2.transform.rotation.eulerAngles.ToString();
            txt.text = string.Format(format, temp1, temp2);
        }
        else if (DebugSetting == 1)
        {
            var dialn = dial.transform.rotation.eulerAngles.z;
            dialn = (dialn / 360f) * 100;
            string dialnum = dialn.ToString();
            txt.text = dialnum;
        }
        else if (DebugSetting == 2)
        {
            string temp1 = qC.question.ToString();
            string temp2 = qC.numCorrect.ToString();
            txt.text = string.Format(format2, temp1, temp2);
            if (qC.question >= 5)
            {
                DebugSetting += 1;
            }
        }
        else if (DebugSetting == 3)
        {
            txt.text = string.Format(format3);
            variables.SetActive(true);
        }
        else if (DebugSetting == 4)
        {
            string temp1 = vC.var1.ToString();
            string temp2 = vC.var2.ToString();
            string temp3 = vC.var3.ToString();
            string temp4 = vC.var4.ToString();
            string temp5 = vC.var5.ToString();
            string temp6 = vC.var6.ToString();
            string temp7 = vC.var7.ToString();
            string temp8 = vC.varIndex.ToString();

            
            if (vC.formula == 0)
            {
                //txt.text = string.Format(format4, temp1, temp2, temp3, temp4, temp5, temp6, temp7, temp8);
                txt.text = string.Format(format5, temp1, temp2, temp3, temp4, temp5);
            }
            if (vC.formula == 1)
            {
                txt.text = string.Format(format6, temp1, temp2, temp3, temp4, temp5, temp6, temp7);
            }
            if (vC.formula == 2)
            {
                txt.text = string.Format(format7, temp1, temp2, temp3, temp4, temp5, temp6);
            }

        }
            //counter += 1;
            //if ((counter % 650) == 0)
            //{
            //    scoreCounter += 1;
            //    counter = 1;
            //}
        }
}
