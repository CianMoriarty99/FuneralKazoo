using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour
{
    public GameObject gm, barricade;

    void Start(){
        gm = GameObject.Find("Main Camera");
    }


    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Player"){
            SMScript.PlaySound("explode");
            gm.GetComponent<GameManager>().ended = true;
            gm.GetComponent<FollowTarget>().TriggerShake();
        }
    }
}
