using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorExplode : MonoBehaviour
{
    public GameObject camera, player;
    public float shakeSpeed;

    public GameObject[] fragments;


    void Update(){

            if(Input.GetKeyDown("space")) { 
                Explode();
            }
    }
    
    void Explode(){
        //Screenshake
        camera.GetComponent<FollowTarget>().TriggerShake();

        SMScript.PlaySound("explode");
        SMScript.PlaySound("song");
        //Change position
        transform.position = new Vector3 (transform.position.x, transform.position.y  - 1, 0);
        //Instantiate prefabs
        for (int i = 0; i < fragments.Length; i++){
            int x = Random.Range(-5,5);
            int y = Random.Range(-1,-10);
            Vector3 randomPos = new Vector3 (transform.position.x + x ,transform.position.y + y , 0);

            Instantiate(fragments[i], randomPos, Quaternion.identity);
        }

        camera.GetComponent<GameManager>().start = true;
        player.GetComponent<PlayerController>().started = true;

        //Instantiate Leave Arrows
        
        //Delete door
        Destroy(this.gameObject);
    }


}
