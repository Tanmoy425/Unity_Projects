using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Controller : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] obstacles;
    public float spawntime;
    Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        
    }

   void spawnObstacles()
    {
        int coinscount = 0;
        
    }



    
}
