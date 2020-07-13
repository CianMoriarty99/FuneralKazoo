using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{   
    public float aliveTime;
    public Color noteColor;
    // Start is called before the first frame update
    void Awake()
    {
        SpriteRenderer spr = GetComponent<SpriteRenderer>();
        GameObject player = GameObject.Find("Player");
        spr.color = player.GetComponent<PlayerController>().selectedColor;

    }

    // Update is called once per frame
    void Update()
    {
        aliveTime -= Time.deltaTime;

        if (aliveTime <= 0){
            Destroy(this.gameObject);
        }
    }
}
