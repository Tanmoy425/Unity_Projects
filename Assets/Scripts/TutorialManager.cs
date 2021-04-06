using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] PopoUps;
    private int PopUpIndex;
    private float waittime = 2.5f;
    public GameObject demo;

    public CharacterController player;
    private Vector3 movevector;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        for (int i = 0; i < PopoUps.Length; i++)
        {
            if (i == PopUpIndex)
            {
                PopoUps[PopUpIndex].SetActive(true);
            }
            else
            {
                PopoUps[PopUpIndex].SetActive(false);
            }
        }
        if(PopUpIndex == 0)
        {
            if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {

                Debug.Log("A");
                PopUpIndex++;
            }
            else if(PopUpIndex == 1)
            {
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    PopUpIndex++;
                }
            }
            else if(PopUpIndex == 2)
            {
                if(waittime<=0)
                {
                    demo.SetActive(true);
                }
                else
                {
                    waittime -= Time.deltaTime;
                }
            }
        }
    }
}
