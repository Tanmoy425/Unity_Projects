using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Motor : MonoBehaviour
{
    private Transform lookAt;
    private Vector3 startoffset;
    private Vector3 moveVector;
    float transition = 0.0f;
    float animationDuration = 3.0f;
    Vector3 animationOffset = new Vector3(0, 5, 5);
    public Camera cam1,cam2;

    // Start is called before the first frame update
    void Start()
    {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        startoffset = transform.position - lookAt.position;
        cam1.enabled = true;
        cam2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = lookAt.position + startoffset;

        moveVector.x = 0;

        moveVector.y = Mathf.Clamp(moveVector.y, 3, 5); 

        if(transition>1.0f)
        {
            transform.position = moveVector;
        }
        else
        {
            //Animation at the start of the game
            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
            transition += Time.deltaTime * 1 / animationDuration;
            transform.LookAt(lookAt.position + Vector3.up);
        }

        if(transform.position.z >= 4)
        {
            //transform.position = Vector3.Lerp(cam2.transform.position, moveVector, 3.0f);
            cam2.enabled = true;
            cam1.enabled = false;
        }
        
    }
}
