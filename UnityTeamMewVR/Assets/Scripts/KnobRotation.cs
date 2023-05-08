using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace LevelUP.Dial
{
    public class KnobRotation : MonoBehaviour
    {

        [SerializeField] Transform linkedDial;
        [SerializeField] private int snapAmount = 30;
        [SerializeField] private float angleTol;
        [SerializeField] private GameObject rightHand;
        [SerializeField] private GameObject leftHand;
        [SerializeField] bool useDummyHands;
        [SerializeField] public GameObject selector;

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
        }

        private void GrabbedBy(SelectEnterEventArgs arg0)
        {
            interactor = GetComponent<XRGrabInteractable>().selectingInteractor;
            interactor.GetComponent<XRDirectInteractor>().hideControllerOnSelect = true;

            getHandRotation = true;
            startAngle = 0f;

        }

        void Update()
        {
            if (getHandRotation)
            {
                var rotationAngle = GetInteractorRotation();
                GetRotationDistance(rotationAngle);
            }

        }

        public float GetInteractorRotation() { return interactor.GetComponent<Transform>().eulerAngles.x; }

        public void GetRotationDistance(float currentAngle)
        {
            if (!requireStartAngle)
            {
                var angleDifference = Mathf.Abs(startAngle - currentAngle);

                if (angleDifference > angleTol)
                {
                    if (angleDifference > 270f)
                    {
                        float angleCheck;
                        if (startAngle < currentAngle)
                        {
                            angleCheck = CheckAngle(currentAngle, startAngle);

                            if (angleCheck < angleTol) { return; }
                            else
                            {
                                if (linkedDial.eulerAngles.z > 285)
                                {
                                    RotateDialAntiClockwise();
                                    startAngle = currentAngle;
                                }
                            }
                        }
                        else if (startAngle > currentAngle)
                        {
                            angleCheck = CheckAngle(currentAngle, startAngle);

                            if (angleCheck < angleTol) { return; }
                            else
                            {
                                if (linkedDial.eulerAngles.z < 345)
                                {
                                    RotateDialClockwise();
                                    startAngle = currentAngle;
                                }
                            }
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

            linkedDial.localEulerAngles = new Vector3(linkedDial.localEulerAngles.x, linkedDial.localEulerAngles.y, linkedDial.localEulerAngles.z + Math.Abs(snapAmount));

            if (TryGetComponent<IDial>(out IDial dial))
            {

                dial.DialChanged(linkedDial.localEulerAngles.z, 0);

            }

        }


        private void RotateDialAntiClockwise()
        {

            linkedDial.localEulerAngles = new Vector3(linkedDial.localEulerAngles.x, linkedDial.localEulerAngles.y, linkedDial.localEulerAngles.z - Math.Abs(snapAmount));

            if (TryGetComponent<IDial>(out IDial dial))
            {

                dial.DialChanged(linkedDial.localEulerAngles.z, 0);
            }

        }




    }
}

