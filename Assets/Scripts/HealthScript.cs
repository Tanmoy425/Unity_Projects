using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    private Player_Controller pc;
    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pc.CurrentPowerUpValue >= pc.MaxValue)
        {
            gameObject.SetActive(false);
        }
        else if (pc.CurrentPowerUpValue <= 40)
        {
            gameObject.SetActive(true);
        }
    }
}
