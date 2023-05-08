using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnorePlayer : MonoBehaviour
{
    public void ignore()
    {
        GameObject player = GameObject.FindWithTag("Player");
        Collider collOther = player.GetComponent<Collider>();
        Collider collThis = GetComponent<Collider>();
        Physics.IgnoreCollision(collOther, collThis);
    }
}
