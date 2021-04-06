using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScene : MonoBehaviour
{
    public GameObject tile;
    private int numberoftiles;
    private int jumpcount = 0;

    // Start is called before the first frame update
    void Start()
    {
        numberoftiles = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if(jumpcount<=3)
        {
            Instantiate(tile, transform.position, Quaternion.identity);
            jumpcount++;
        }       
    }
}
