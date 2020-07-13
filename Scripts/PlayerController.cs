using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sprRend;
    public float speed, slowSpeed, fastSpeed, bulletSpeed, x, y, shootCoolDown, shootTimer, colorChangeTimer, colorChangeCooldown, kazooTimer, kazooCD;

    public GameObject musicNotePrefab;
    public Transform endOfKazoo;

    public List<Color> colors; 
    public Color selectedColor;

    public bool started;

    public ParticleSystem jazz;

    public int kazooChanger;


    public Vector2 dir, faceDir;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprRend = GetComponent<SpriteRenderer>();
        jazz.Stop();
        started = false;
        kazooChanger = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(started){
            
            colorChangeTimer -= Time.deltaTime;
            if(!jazz.isEmitting)
                jazz.Play();
        }
        speed = fastSpeed;
        //GET INPUT
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        dir = new Vector2(x,y);

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        faceDir = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = -faceDir; 

        


        if(colorChangeTimer <= 0){
            ChangeColor();
            kazooChanger += 1;
            colorChangeTimer = colorChangeCooldown;
        }
            

        sprRend.color = selectedColor;

        if(Input.GetMouseButton(0)){

            if(kazooTimer <= 0){
                SMScript.PlaySound(""+kazooChanger);
                kazooTimer = kazooCD;
            }
                

            speed = slowSpeed;

            
            if(shootTimer <= 0){
                Shoot();
                
                shootTimer = shootCoolDown;
            }
        }
        
        shootTimer -= Time.deltaTime;
        kazooTimer -= Time.deltaTime;


            
        
        
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + dir.normalized * speed * Time.fixedDeltaTime);
    }

    void Shoot(){

        
        Vector3 t = new Vector3(endOfKazoo.position.x, endOfKazoo.position.y, endOfKazoo.position.z);
        var projectile = Instantiate(musicNotePrefab, t, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().AddForce(-transform.up * bulletSpeed);
    }

    void ChangeColor(){

        SMScript.PlaySound("color");
        if(colors.Count != 0){

            int r = Random.Range(0,colors.Count);
            
            if(selectedColor != colors[r]){
                selectedColor = colors[r];
                colors.Remove(colors[r]);
            }
            else if (r != 0){
                selectedColor = colors[r-1];
                colors.Remove(colors[r-1]);
            }
            else {
                selectedColor = colors[r+1];
                colors.Remove(colors[r+1]);
            }

        }

            
    }





}
