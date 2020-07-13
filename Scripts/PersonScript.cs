using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonScript : MonoBehaviour
{

    SpriteRenderer spr;
    public List<Color> colors;

    public ParticleSystem happy;



    public GameObject moneyPrefab, gm;

    void Awake(){
        colors = GameObject.Find("Player").GetComponent<PlayerController>().colors;
        gm = GameObject.Find("Main Camera");
    }
    // Start is called before the first frame update
    void Start()
    {
        
        
        int r = Random.Range(0,colors.Count);
        
        spr = GetComponent<SpriteRenderer>();
        spr.color = colors[r];
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
        
        if(col.tag == "Note"){
            Color check = col.GetComponent<SpriteRenderer>().color;
            if (check == spr.color){

                var projectile = Instantiate(moneyPrefab, this.transform);
                projectile.GetComponent<Rigidbody2D>().AddForce(Random.insideUnitSphere*900f);

                projectile = Instantiate(moneyPrefab, this.transform);
                projectile.GetComponent<Rigidbody2D>().AddForce(Random.insideUnitSphere*900f);

                projectile = Instantiate(moneyPrefab, this.transform);
                projectile.GetComponent<Rigidbody2D>().AddForce(Random.insideUnitSphere*900f);

                SMScript.PlaySound("happy");
                happy.Play();
                gm.GetComponent<GameManager>().peopleHappy += 1;
                spr.color = Color.white;
            }
        }

    }
}
