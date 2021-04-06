using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Script : MonoBehaviour
{
    public Player_Controller playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {

        if (playerControllerScript.bulletCount < 5)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
