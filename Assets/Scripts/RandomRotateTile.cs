using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotateTile : MonoBehaviour
{
    public Transform[] spawnpoints;
    public GameObject tile;
    private int randomspawnpoint;
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {

            randomspawnpoint = Random.Range(0, spawnpoints.Length);
            
            Debug.Log("Player");
            //Debug.Log(randomtile);

            for(int i=0; i< spawnpoints.Length; i++)
            {
                if(i == randomspawnpoint)
                {
                    Instantiate(tile, spawnpoints[i].position, spawnpoints[i].rotation);
                    
                }
            }
        }
    }

    

    private void Update()
    {


    }

    void SpawnTile()
    {

    }
}
