using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] pieces;
    [SerializeField] float timeBetweenSpawns = 4.0f;
    float timeSinceLastSpawn = 0f;
    bool readyToSpawn = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeSinceLastSpawn >= timeBetweenSpawns)
        {
            readyToSpawn = true;
        }

        if (readyToSpawn)
        {
            Spawn();
        }
        else
        {
            //increment timer
            timeSinceLastSpawn += Time.deltaTime;
        }
    }

    void Spawn()
    {
        //pick a random number and then instantiate an object from the array.
        int index = Random.Range(0, pieces.Length);
        Debug.Log("Index for spawning is " + index);

        Instantiate(pieces[index],Vector3.zero,Quaternion.identity);

        readyToSpawn = false;
        timeSinceLastSpawn = 0f;
    }
}
