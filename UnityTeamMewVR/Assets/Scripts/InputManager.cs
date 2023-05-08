using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class InputManager : MonoBehaviour
{
    //public List<DebugMenu> allButtonHandlers = new List<DebugMenu>();
    public variableC vars;

    private XRController controller = null;

    public void set_formula(int form)
    {
        vars.formula = form;
        vars.varIndex = 0;
    }

    public void setVariables(float new_val)
    {
        if(new_val == -69) { new_val = vars.gravity; }
        switch(vars.varIndex)
        {
            case 0: 
                vars.var1 = new_val;
                break;
            case 1:
                vars.var2 = new_val;
                break;
            case 2:
                vars.var3 = new_val;
                break;
            case 3:
                vars.var4 = new_val;
                break;
            case 4:
                vars.var5 = new_val;
                break;
            case 5:
                vars.var6 = new_val;
                break;
            case 6:
                vars.var7 = new_val;
                break;
        }


        
    }

}
