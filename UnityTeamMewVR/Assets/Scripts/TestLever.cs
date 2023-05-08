using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

//namespace LevelUP.Lever
//{
    public class TestLever : MonoBehaviour
    {

        [SerializeField] Transform lever;
        [SerializeField] private int snapAmount = 30;
        [SerializeField] private float angleTol;
        [SerializeField] private GameObject rightHand;
        [SerializeField] private GameObject leftHand;
        [SerializeField] bool useDummyHands;

        private XRBaseInteractor interactor;
        private float startAngle;
        private bool requireStartAngle = true;
        private bool getHandRotation = false;

        private XRGrabInteractable grabInteractor => GetComponent<XRGrabInteractable>();

        private void OnEnable()
        {
            grabInteractor.selectEntered.AddListener(GrabbedBy);
            grabInteractor.selectExited.AddListener(GrabEnd);
        }

        private void OnDisable()
        {
            grabInteractor.selectEntered.RemoveListener(GrabbedBy);
            grabInteractor.selectExited.RemoveListener(GrabEnd);
        }

        private void GrabEnd(SelectExitEventArgs arg0)
        {
            getHandRotation = false;
            requireStartAngle = true;
            //HandModelVisibility(false);
        }

        private void GrabbedBy(SelectEnterEventArgs arg0)
        {
            interactor = GetComponent<XRGrabInteractable>().selectingInteractor;
            interactor.GetComponent<XRDirectInteractor>().hideControllerOnSelect = true;

            getHandRotation = true;
            startAngle = interactor.GetComponent<Transform>().position.y; ;

            //HandModelVisibility(true);
        }

        //private void HandModelVisibility(bool visibilityState)
        //{
        //    if (!useDummyHands) { return; }
        //    if (interactor.CompareTag("RightHand")) { rightHand.SetActive(visibilityState); }
        //    else { leftHand.SetActive(visibilityState); }
        //}

        void Update()
        {
            if (getHandRotation)
            {
                var rotationAngle = GetInteractorRotation();
                GetRotationDistance(rotationAngle);
            }
        }

        public float GetInteractorRotation() { return interactor.GetComponent<Transform>().position.y; }

        public void GetRotationDistance(float currentAngle)
        {
            if (!requireStartAngle)
            {
                var angleDifference = Mathf.Abs(startAngle - currentAngle);

                if (angleDifference > angleTol)
                {
                    
                    float angleCheck;
                    if (startAngle < currentAngle)
                    {
                        angleCheck = CheckAngle(currentAngle, startAngle);

                        if (angleCheck < angleTol) { return; }
                        else
                        {
                            //if (interactor.CompareTag("LeftHand"))
                            //    RotateDialClockwise();
                            RotateDialAntiClockwise();
                            startAngle = currentAngle;
                        }
                    }
                    else if (startAngle > currentAngle)
                    {
                        angleCheck = CheckAngle(currentAngle, startAngle);

                        if (angleCheck < angleTol) { return; }
                        else
                        {
                            //if (interactor.CompareTag("LeftHand"))
                            //    RotateDialAntiClockwise();
                            RotateDialClockwise();
                            startAngle = currentAngle;
                        }
                    }
                    
                }
            }
            else
            {
                requireStartAngle = false;
                startAngle = currentAngle;
            }
        }

        private float CheckAngle(float currentAngle, float startAngle) { return ((360f - currentAngle) + startAngle); }


        private void RotateDialClockwise()
        {
            lever.localEulerAngles = new Vector3(lever.localEulerAngles.x + Math.Abs(snapAmount), lever.localEulerAngles.y, lever.localEulerAngles.z);
            Vector3 leverAngles = lever.localEulerAngles;

            if (TryGetComponent<ILever>(out ILever lever1))
            {
                lever1.LeverChanged(leverAngles);
            }
        }


        private void RotateDialAntiClockwise()
        {
            lever.localEulerAngles = new Vector3(lever.localEulerAngles.x - Math.Abs(snapAmount), lever.localEulerAngles.y, lever.localEulerAngles.z);
            Vector3 leverAngles = lever.localEulerAngles;

            if (TryGetComponent<ILever>(out ILever lever1))
            {
                lever1.LeverChanged(leverAngles);
            }
        }




    }
//}
