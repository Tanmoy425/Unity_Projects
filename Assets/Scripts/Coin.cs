﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    int spawnpickup = 0;

    public Transform[] SpawnPoints;
    public GameObject[] objects;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
  
        transform.Rotate(0,50*Time.deltaTime,0);
    }
}
