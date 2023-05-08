using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{
    [SerializeField] public Animator myDoor = null;

    [SerializeField] public bool openTrigger = false;

    public void OnAnimTrigger()
    {
        myDoor.Play("doorAnim", 0, 0.0f);
        
    }

}
