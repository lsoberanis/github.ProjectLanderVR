using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormulasInfo : MonoBehaviour
{
    // Start is called before the first frame update
    public int Formula; // formula selected
    public GameObject selectorForm;
    public int selectorFormPos;
    public GameObject ray;
    public GameObject Formulas;

    void Start()
    {
        Formula = 0; // no formula selected
        selectorFormPos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collisioninfo)
    {
        if (collisioninfo.gameObject.tag == "variable")
        {
            
        }
    }

}
