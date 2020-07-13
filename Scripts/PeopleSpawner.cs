using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleSpawner : MonoBehaviour
{

    public GameObject personPrefab;

    public List<Transform> spawns;

    public int numberOfPeople;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfPeople; i++){
            int r = Random.Range(0,spawns.Count);
            Instantiate(personPrefab, spawns[r]);
            spawns.Remove(spawns[r]);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
