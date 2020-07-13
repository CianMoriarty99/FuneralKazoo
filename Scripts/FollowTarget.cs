using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public GameObject target;
    public float zOffset, xOffset, yOffset;


    private float shakeDuration = 0f;
    
    private float shakeMagnitude = 0.7f;
    
    private float dampingSpeed = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(target.transform.position.x -xOffset, target.transform.position.y -yOffset, -zOffset);

        if (shakeDuration > 0)
        {
            transform.localPosition = this.transform.position + Random.insideUnitSphere * shakeMagnitude;
            
            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
            
        }
       
    }

    public void TriggerShake() {
        shakeDuration = 0.5f;
    }
}
