using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class DebugMenu : MonoBehaviour
{

    public GameObject menu; // Assign in inspector
    private bool isShowing;
    //Assigned to the RightHand Controller
    public delegate void StateChange(XRController controller);
    InputDevice device;
    bool disVal;
    public InputHelpers.Button button = InputHelpers.Button.SecondaryButton;

    // Start is called before the first frame update
    void Start()
    {
        //device = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
    }

    //public override void HandleState(XRController controller)
    //{
    //    if (controller.inputDevice.IsPressed(button, out disVal, controller.axisToPressThreshold))
    //    {
    //        isShowing = !isShowing;
    //        menu.SetActive(isShowing);
    //    }
    //}

}
