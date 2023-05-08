using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerAnimation : MonoBehaviour, ShootShuttle
{
    Animator anim;
    
    void Start()
    {
        anim = transform.GetComponent<Animator>();
    }

    public void ShootShut()
    {
        UnityEngine.Debug.Log("made it");
        anim.SetBool("isLaunching", true);
    }
    
}
