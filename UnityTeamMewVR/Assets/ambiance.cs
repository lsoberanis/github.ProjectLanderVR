using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ambiance : MonoBehaviour
{
    [SerializeField] GameObject audio;

    // Start is called before the first frame update
    void Start()
    {
        var audioclip = audio.GetComponent<AudioSource>();
        audioclip.Play(0);
    }
}
