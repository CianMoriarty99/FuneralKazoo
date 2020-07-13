using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyScript : MonoBehaviour
{
    public GameObject gm;

    void Start(){
        gm = GameObject.Find("Main Camera");
    }


    void OnTriggerEnter2D(Collider2D col){
        if (col.tag == "Player")
        {
            SMScript.PlaySound("coin");
            gm.GetComponent<GameManager>().money += 1;
            Destroy(this.gameObject);
        }

    }
}
