using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPIN : MonoBehaviour
{
    [SerializeField] Animator anime;
    
    // Start is called before the first frame update
    void Start()
    {
        anime.SetBool("isSpinning", true);
    }


}
