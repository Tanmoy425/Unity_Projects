using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyScript : MonoBehaviour
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
        if (pc.CurrentEnergy >= pc.MaxValue)
        {
            gameObject.SetActive(false);
        }
        else if (pc.CurrentEnergy <= 30)
        {
            gameObject.SetActive(true);
        }
    }
}
