using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LeverRotationTest : MonoBehaviour
{
    [SerializeField] private GameObject lever;
    private bool visited = false;
    private Quaternion lockedRotation;
    float minRotation = -5;
    float AmaxRotation = 60;
    float maxRotation = 65;
    Vector3 currentRotation;
    private Rigidbody ridg;
    public Vector3 pos;
    [SerializeField] public GameObject controller = null;

    // Update is called once per frame
    void Update()
    {
        currentRotation = lever.transform.localRotation.eulerAngles;
        currentRotation.y = 180; // manually set it back to this so it prevents any shifting
        currentRotation.z = 0;

        if (currentRotation.x == maxRotation || currentRotation.x == -1)
        {
            currentRotation.x = 0;
            ridg = lever.GetComponent<Rigidbody>();
            ridg.MoveRotation(Quaternion.Euler(currentRotation));
            //transform.localRotation = Quaternion.Euler(currentRotation);
            //controller.GetComponent<XRController>().GetComponent<Hand>().SetGrip(0);
        }
        else
        {
            currentRotation.x = Mathf.Clamp(currentRotation.x, minRotation, maxRotation);
            transform.localRotation = Quaternion.Euler(currentRotation);
        }

        lever.GetComponent<Transform>().position = pos;

    }

    
}
