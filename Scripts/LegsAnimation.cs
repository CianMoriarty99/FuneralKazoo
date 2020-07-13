using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegsAnimation : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)){
            animator.SetBool("shooting", true);
        } else {
            animator.SetBool("shooting", false);
        }
        
    }
}
