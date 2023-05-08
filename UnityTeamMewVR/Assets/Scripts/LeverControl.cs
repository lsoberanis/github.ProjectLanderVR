using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
//using System.Media;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LeverControl : MonoBehaviour, ILever
{
    [SerializeField] private GameObject lever;
    [SerializeField] private int leverNum;
    [SerializeField] private GameObject easyDoor;
    [SerializeField] private GameObject normalDoor;
    [SerializeField] private GameObject normalDoor2;
    [SerializeField] private GameObject hardDoor;
    [SerializeField] public GameObject easyMode;
    [SerializeField] public GameObject normalMode;
    [SerializeField] public GameObject hardMode;
    [SerializeField] private GameObject question1;
    [SerializeField] private GameObject question2;
    [SerializeField] private GameObject question3;
    [SerializeField] private GameObject question4;
    [SerializeField] private GameObject question5;
    [SerializeField] private GameObject selector;
    [SerializeField] private GameObject selectorB;
    [SerializeField] private GameObject selectorC;
    [SerializeField] private GameObject selectorD;
    //[SerializeField] private GameObject selectorFormulas;
    [SerializeField] private GameObject ray;
    [SerializeField] private questionC questionCount;
    [SerializeField] private GameObject formulaBase;
    [SerializeField] private GameObject formulaA;
    [SerializeField] private GameObject formulaB;
    [SerializeField] private GameObject formulaC;
    [SerializeField] private GameObject taskTitle;
    public TMP_Text taskTitletxt;
    [SerializeField] private GameObject dataBase;
    [SerializeField] public GameObject audioS;
    [SerializeField] public GameObject audioS2;
    [SerializeField] private GameObject launchAnim;
    [SerializeField] private variableC vars;
    public TMP_Text FinalCalctxt;
    [SerializeField] private GameObject FinalCalc2;
    public TMP_Text FinalCalctxt2;
    [SerializeField] private GameObject SkipVar;
    [SerializeField] GameObject crashanim;
    [SerializeField] GameObject landanim;
    [SerializeField] Animator launchanim;
    [SerializeField] private GameObject finalTextC;
    public TMP_Text finaltxtC1;
    [SerializeField] private GameObject correct;
    [SerializeField] private GameObject incorrect;

    [SerializeField] private AudioSource aud0;
    [SerializeField] private AudioSource aud1;
    [SerializeField] private AudioSource aud2;
    [SerializeField] private AudioSource aud3;
    [SerializeField] private AudioSource aud4;
    [SerializeField] private AudioSource aud5;
    [SerializeField] private AudioSource aud6;
    [SerializeField] private AudioSource aud7;
    [SerializeField] private AudioSource aud8;
    [SerializeField] private AudioSource aud9;
    [SerializeField] private AudioSource aud10;
    [SerializeField] private AudioSource aud11;
    [SerializeField] private AudioSource aud12;
    [SerializeField] private AudioSource aud13;
    [SerializeField] private AudioSource aud14;
    [SerializeField] private AudioSource aud15;
    [SerializeField] private AudioSource aud16;
    [SerializeField] private AudioSource aud17;
    [SerializeField] private AudioSource aud18;
    [SerializeField] private AudioSource aud19;
    [SerializeField] private AudioSource aud20;

    [SerializeField] int audioNum = 0;
    bool aud = false;
    float thrust = 0;
    int pull = 0;
    int eq = 0;
    private Animator animator;
    private Animator anim;
    float maxRotation = 80;
    Vector3 currentRotation;
    private Vector3 pos;
    [SerializeField] public GameObject controller = null;

    void Start()
    {
        currentRotation.x = 0;
        currentRotation.y = lever.transform.rotation.eulerAngles.y;
        currentRotation.z = 0;
        pos = lever.transform.position;
        if(leverNum != 3)
        {
            animator = transform.parent.GetComponent<Animator>();
            anim = launchAnim.transform.GetComponent<Animator>();
        }

        if (leverNum == 0)
        {
            //aud0.Play(0);
        }

        //vars = new variableC();

    }

    public void LeverChanged(Vector3 levervalue)
    {
        if (levervalue.x >= maxRotation)
        {
            if (leverNum == 0) { OpenDoor(); }

            else if (leverNum == 1)
            {


                if (questionCount.question < 5)
                {
                    NormalQuestions();
                }

            }

            else if (leverNum == 2)
            {
                if (pull == 0 || pull == 2) Formulas();
                else if (pull == 1 || pull == 3) {
                    if (((vars.formula == 0) && (vars.varIndex >= 5)) || ((vars.formula == 1) && (vars.varIndex >= 7)) || ((vars.formula == 2) && (vars.varIndex >= 6)))
                    {
                        vars.parentList[vars.formula][vars.varIndex - 1].GetComponent<Renderer>().material = vars.oldMaterialRef;
/*                        if (eq == 0)
                        {
                            aud13.Play(0);
                            //audioNum = 13;
                            //StartCoroutine(WaitOnSound());
                        }
                        else
                        {
                            aud15.Play(0);
                            //audioNum = 15;
                            //StartCoroutine(WaitOnSound());
                        }*/
                        Calculate();
                        pull += 1;
                        eq++;
                        vars.varIndex = 0;
                        questionCount.selectorPos = 0;
                        formulaBase.SetActive(true);
                        if (eq == 1)
                        {
                            formulaBase.SetActive(true);
                            SkipVar.SetActive(false);
                            taskTitletxt.text = "TASK: Solve for THRUST";
                            vars.Reset();
                        }
                        if (eq == 2)
                        {
                            formulaBase.SetActive(false);
                            SkipVar.SetActive(false);
                            //taskTitletxt.text = "TASK: Pull the Lever to go to door on the right";
                        }
                        formulaA.SetActive(false);
                        formulaB.SetActive(false);
                        formulaC.SetActive(false);
                        selector.SetActive(true);
                        //FinalCalc2.SetActive(false);
                        selector.transform.position = new Vector3(-18.103f, 8.186f, 1.87f);
                        vars.Reset();
                    }
                    else ForumalsAssign();
                    

                }
                else
                {
                    formulaBase.SetActive(false);
                    formulaA.SetActive(false);
                    formulaB.SetActive(false);
                    formulaC.SetActive(false);
                    selector.SetActive(false);
                    ray.SetActive(false);
                    SkipVar.SetActive(false);
                    //FinalCalc2.SetActive(false);
                    taskTitletxt.text = "TASK: Let us know how you did!";
                    ShootShut();
                    //OpenDoor();
                    //NoAnim();
                }
                
            }

            else if (leverNum == 3)
            {
                LandAnim();
       
            }

            lever.transform.rotation = Quaternion.Slerp(lever.transform.rotation, Quaternion.Euler(currentRotation), 1.0f);
        }

    }


    public void OpenDoor()
    {
        //UnityEngine.Debug.Log("in the fucking function");

        if (easyMode.activeInHierarchy)
        {
            //easyDoor.SetActive(false);

        }
        else if (normalMode.activeInHierarchy)
        {
            //normalDoor.SetActive(false);
            var audioclip = audioS.GetComponent<AudioSource>();
            audioclip.Play(1);

            animator.SetBool("isOpening", true);
            //animator.SetBool("openTheDoor", true);

        }
        else if (hardMode.activeInHierarchy)
        {
            //hardDoor.SetActive(false);
        }
    }

    void NormalQuestions()
    {
        if(!aud)
        {
            if (questionCount.selectorPos == questionCount.correctV)
            {
                questionCount.numCorrect += 1;
                var audioclip = audioS.GetComponent<AudioSource>();
                audioclip.Play(0);
                /*switch (questionCount.question)
                {
                    case 0:
                        aud1.Play(0);
                        //play q1_correct
                        StartCoroutine(WaitOnSound());
                        break;
                    case 1:
                        aud3.Play(0);
                        //play q2_correct
                        StartCoroutine(WaitOnSound());
                        break;
                    case 2:
                        aud5.Play(0);
                        //play q3_correct
                        StartCoroutine(WaitOnSound());
                        break;
                    case 3:
                        aud7.Play(0);
                        //play q4_correct
                        StartCoroutine(WaitOnSound());
                        break;
                    case 4:
                        aud9.Play(0);
                        //play q5_correct
                        StartCoroutine(WaitOnSound());
                        break;
                }*/

            }
            else
            {
                var audioclip = audioS2.GetComponent<AudioSource>();
                audioclip.Play(0);
                audioNum++;
                /*switch (questionCount.question)
                {
                    case 0:
                        aud2.Play(0);
                        //play q1_incorrect
                        StartCoroutine(WaitOnSound());
                        break;
                    case 1:
                        aud4.Play(0);
                        //play q2_incorrect
                        StartCoroutine(WaitOnSound());
                        break;
                    case 2:
                        aud6.Play(0);
                        //play q3_incorrect
                        StartCoroutine(WaitOnSound());
                        break;
                    case 3:
                        aud8.Play(0);
                        //play q4_incorrect
                        StartCoroutine(WaitOnSound());
                        break;
                    case 4:
                        aud10.Play(0);
                        //play q5_incorrect
                        StartCoroutine(WaitOnSound());
                        break;
                }*/
            }

            questionCount.question++;
        }
        
        //if(aud)
        //{
            if (questionCount.question == 1)
            {
                question1.SetActive(false);
                question2.SetActive(true);


                //OpenDoor(); //take out later this is just for demo
            }
            else if (questionCount.question == 2)
            {
                question2.SetActive(false);
                question3.SetActive(true);

            }
            else if (questionCount.question == 3)
            {
                question3.SetActive(false);
                question4.SetActive(true);
            }
            else if (questionCount.question == 4)
            {
                question4.SetActive(false);
                question5.SetActive(true);
            }
            else
            {
                //aud11.Play(0);
                //StartCoroutine(WaitOnSound());

                question5.SetActive(false);
                formulaBase.SetActive(true);
                taskTitle.SetActive(true);
                questionCount.question = 5;
                leverNum += 1;
                selector.SetActive(true);
                selector.transform.position = new Vector3(-18.103f, 8.186f, 1.87f);
                questionCount.selectorPos = 0;
                selectorB.SetActive(false);
                selectorC.SetActive(false);
                selectorD.SetActive(false);
                dataBase.SetActive(true);

            }

            aud = false;
        //}
        
    }

    void Formulas()
    {
        //FinalCalc.SetActive(false);
        formulaBase.SetActive(true);
        formulaA.SetActive(false);
        formulaB.SetActive(false);
        formulaC.SetActive(false);
        selector.SetActive(true);
        selector.transform.position = new Vector3(-18.103f, 8.186f, 1.87f);

        if (eq == 0)
        {
            taskTitletxt.text = "TASK: Solve for GRAVITY";
        }
        else if (eq == 1)
        {
            //aud14.Play(0);
            //audioNum = 14;
            //StartCoroutine(WaitOnSound());
            taskTitletxt.text = "TASK: Solve for THRUST";
        }

        if (questionCount.selectorPos == -1)
        {
            formulaBase.SetActive(true);
        }
        else if ((questionCount.selectorPos >= 0) && (questionCount.selectorPos <= 2))
        {
            
            formulaBase.SetActive(false);
            List<List<GameObject>> formulaMesh = vars.parentList;
            if (questionCount.selectorPos == 0)
            {
                vars.formula = 0;
                formulaA.SetActive(true);
                formulaMesh[vars.formula][0].GetComponent<Renderer>().material = vars.selectMaterialRef;
                
            }
            else if (questionCount.selectorPos == 1)
            {
                vars.formula = 1;
                formulaB.SetActive(true);
                formulaMesh[vars.formula][0].GetComponent<Renderer>().material = vars.selectMaterialRef;
                
            }
            else if (questionCount.selectorPos == 2)
            {
                vars.formula = 2;
                formulaC.SetActive(true);
                formulaMesh[vars.formula][0].GetComponent<Renderer>().material = vars.selectMaterialRef;
                
            }
            selector.SetActive(false);
            ray.SetActive(true);
            SkipVar.SetActive(true);
            //if(eq == 0) { aud12.Play(); }
            //StartCoroutine(WaitOnSound());

        }
        pull++;
 

    }

    void ForumalsAssign() // this is just the material assignment code, it doesn't call calculate of anything
    {
        List<List<GameObject>> formulaMesh = vars.parentList;
        int index = vars.varIndex + 1;
        if (index == 0)
        {
            formulaMesh[vars.formula][0].GetComponent<Renderer>().material = vars.selectMaterialRef;
        }

        else if (index < formulaMesh[vars.formula].Count) {
            formulaMesh[vars.formula][index].GetComponent<Renderer>().material = vars.selectMaterialRef;
            formulaMesh[vars.formula][index - 1].GetComponent<Renderer>().material = vars.oldMaterialRef;
        }


        vars.varIndex += 1;

    }


    void LandAnim()
    {

        Animator newanim;
        if (vars.low)
        {
            //run anim
            newanim = crashanim.GetComponent<Animator>();
            newanim.SetBool("isCrashing", true);
            //aud19.Play(0);
            //StartCoroutine(WaitOnSound());
        }
        else if (vars.correct)
        {
            //play anim
            newanim = landanim.GetComponent<Animator>();
            newanim.SetBool("isLanding", true);
            //aud18.Play(0);
            //StartCoroutine(WaitOnSound());
        }
        else if (vars.high)
        {
            newanim = crashanim.GetComponent<Animator>();
            newanim.SetBool("isCrashing", true);
            //aud20.Play(0);
            //StartCoroutine(WaitOnSound());
        }

        

    }

    void NoAnim()
    {
        if (vars.low)
        {
            aud17.Play(0);
            //StartCoroutine(WaitOnSound());
        }
        else if(vars.correct)
        {
            aud16.Play(0);
            //StartCoroutine(WaitOnSound());
        }
        else if(vars.high)
        {
            aud17.Play(0);
            //StartCoroutine(WaitOnSound());
        }
    }

    public void Calculate()
    {
        if(eq == 0)
        {
            if(vars.formula == 0)
            {
                vars.gravity = (Mathf.Pow(vars.var1, 2) - Mathf.Pow(vars.var2, 2)) / (2 * (vars.var4 * 1000 - vars.var5 * 1000));
                vars.gravity *= -1;
            }
            else if(vars.formula == 1)
            {
                vars.gravity = (2 * vars.var7 * vars.var5 + vars.var6 * Mathf.Pow(vars.var1, 2)) / (2 * (vars.var3 * 1000 + vars.var7 * 1000) * vars.var6);
            }
            else
            {
                vars.gravity = (-2 * vars.var6 * 1000 * vars.var1 - vars.var2 * Mathf.Pow(vars.var3, 2)) / (2 * vars.var5 * 1000 * vars.var2);
            }

            //activate gravity button
            //FinalCalc.SetActive(true);
            //const string txtformat = "Gravity = {1}";
            FinalCalctxt.text = vars.gravity.ToString();
            //pull = 0;

        }
        else
        {
            if(vars.formula == 0)
            {
                thrust = 0;
            }
            else if(vars.formula == 1)
            {
                thrust = (vars.var6 * (2 * vars.var3 * 1000 * vars.var2 + 2 * vars.var7 * 1000 * vars.var2 - Mathf.Pow(vars.var7 * 1000, 2))) / (2 * vars.var7 * 1000);
            }
            else
            {
                thrust = vars.var2 * (0 - ((Mathf.Pow(vars.var3, 2) - 2 * vars.var4 * vars.var5 * 1000) / (2 * vars.var6 * 1000)));
                thrust *= -1;
            }

            FinalCalc2.SetActive(true);
            //const string txtformat = "Thrust = {1}";
            FinalCalctxt2.text = "Thrust = " + thrust.ToString();
            //pull = 3;


            if (thrust + 10 < 17.20112)
            {
                vars.low = true;
                crashanim.SetActive(true);

            }
            else if(thrust - 10 > 17.20112)
            {
                crashanim.SetActive(true);
                vars.high = true;
            }
            else
            {
                landanim.SetActive(true);
                vars.correct = true;
            }
        }

    }

    public void ShootShut()
    {
        launchanim.SetBool("isLaunching", true);
    }

    IEnumerator WaitOnSound()
    {
        switch(audioNum)
        {
            case 0:     //intro
                //while (aud0.isPlaying)
                //{
                //    yield return null;
                //}
                //audioNum++;
                break;
            case 1:     //q1_correct
                while (aud1.isPlaying)
                {
                    yield return null;
                }
                audioNum += 2;
                aud = true;
                NormalQuestions();
                break;
            case 2:     //q1_incorrect
                while (aud2.isPlaying)
                {
                    yield return null;
                }
                audioNum++;
                aud = true;
                NormalQuestions();
                break;
            case 3:     //q2_correct
                while (aud3.isPlaying)
                {
                    yield return null;
                }
                audioNum += 2;
                aud = true;
                NormalQuestions();
                break;
            case 4:     //q2_incorrect
                while (aud4.isPlaying)
                {
                    yield return null;
                }
                audioNum++;
                aud = true;
                NormalQuestions();
                break;
            case 5:     //q3_correct
                while (aud5.isPlaying)
                {
                    yield return null;
                }
                audioNum += 2;
                aud = true;
                NormalQuestions();
                break;
            case 6:     //q3_incorrect
                while (aud6.isPlaying)
                {
                    yield return null;
                }
                audioNum++;
                aud = true;
                NormalQuestions();
                break;
            case 7:     //q4_correct
                while (aud7.isPlaying)
                {
                    yield return null;
                }
                audioNum += 2;
                aud = true;
                NormalQuestions();
                break;
            case 8:     //q4_incorrect
                while (aud8.isPlaying)
                {
                    yield return null;
                }
                aud = true;
                NormalQuestions();
                break;
            case 9:     //q5_correct
                while (aud9.isPlaying)
                {
                    yield return null;
                }
                audioNum += 2;
                aud = true;
                questionCount.question++; 
                NormalQuestions();
                break;
            case 10:    //q5_incorrect
                while (aud10.isPlaying)
                {
                    yield return null;
                }
                audioNum++;
                aud = true;
                questionCount.question++;
                NormalQuestions();
                break;
            case 11:    //pq_1
                while (aud11.isPlaying)
                {
                    yield return null;
                }
                audioNum++;
                break;
            case 12:    //pq_2
                while (aud12.isPlaying)
                {
                    yield return null;
                }
                audioNum++;
                ForumalsAssign();
                break;
            case 13:    //pq_3
                while (aud13.isPlaying)
                {
                    yield return null;
                }
                audioNum++;
                break;
            case 14:    //pq_4
                while (aud14.isPlaying)
                {
                    yield return null;
                }
                audioNum++;
                break;
            case 15:    //pq_5
                while (aud15.isPlaying)
                {
                    yield return null;
                }
                audioNum++;
                break;
            case 16:    //only_correct
                while (aud16.isPlaying)
                {
                    yield return null;
                }
                audioNum++;
                break;
            case 17:    //only_incorrect
                while (aud17.isPlaying)
                {
                    yield return null;
                }
                audioNum++;
                break;
            case 18:    //anim_correct
                while (aud18.isPlaying)
                {
                    yield return null;
                }
                audioNum++;
                break;
            case 19:    //anim_float
                while (aud19.isPlaying)
                {
                    yield return null;
                }
                audioNum++;
                break;
            case 20:    //anim_crash
                while (aud20.isPlaying)
                {
                    yield return null;
                }
                audioNum++;
                break;
           
        }

    }

    void finalText()
    {

        


    }

}

