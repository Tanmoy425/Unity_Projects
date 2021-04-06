using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe_collider : MonoBehaviour
{
    public bool canrotate = false;
    public Level2Movement playermovement;

    private void Start()
    {
        playermovement = GameObject.FindGameObjectWithTag("Player").GetComponent<Level2Movement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playermovement.swipe = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playermovement.swipe = false;
            //Debug.Log(canrotate+"Exit");
        }
    }
}
