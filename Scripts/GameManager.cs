using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public float timeStart, peopleHappy, money;
    public Text textBox, scoreText;

    public Transform flag;
    public GameObject exitPrefab, player;

    public Transform location;

    public bool start, exits, ended, endScreen;

    public ParticleSystem fireworks1, fireworks2;

    public GameObject panel;



    // Start is called before the first frame update
    void Start()
    {
        start = false;
        exits = false;
        endScreen = false;
        textBox.text = timeStart.ToString();
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (start){
            //Set Screenshake
            timeStart -= Time.deltaTime;
            textBox.text = Mathf.Round(timeStart).ToString();
        }

        if (player.transform.position.y < flag.position.y && !exits)
            MakeExits();

        if(timeStart <= 0){
            start = false;
            Failed();
            
        }

        if(ended){
            start = false;
            if(!fireworks1.isEmitting)
                fireworks1.Play();

            if(!fireworks2.isEmitting)
                fireworks2.Play();
            EndRound();
        }

        if(endScreen){
            if(Input.GetKeyDown("space")){
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
            
        




    }

    void Failed(){
        scoreText.text = "Unlucky, you were caught by the anti fun guards.\n \n At least you cheered "+ peopleHappy +" people up before they could catch you.\n \nPress SPACE to restart";
        StartCoroutine("ActivatePanel");
        player.GetComponent<PlayerController>().enabled = false;
    }


    void EndRound(){
        scoreText.text = "Congratulations, you cheered " +peopleHappy +" people up and collected " + money+ " bucks!\n \nPress SPACE to restart";
        StartCoroutine("ActivatePanel");
        player.GetComponent<PlayerController>().enabled = false;
        
    }

    void MakeExits(){
        exits = true;
        Instantiate(exitPrefab, location);
        
    }

    IEnumerator ActivatePanel(){
        yield return new WaitForSeconds(2);
        panel.SetActive(true);
        endScreen = true;
    }

    
}
