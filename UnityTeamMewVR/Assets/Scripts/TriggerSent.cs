using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSent : MonoBehaviour
{
    [SerializeField] public Animator sent = null;

    private void Update()
    {
        OnAnimTrigger();
    }

    public void OnAnimTrigger()
    {
        sent.Play("Take 001", 0, 0.0f);

    }
}
