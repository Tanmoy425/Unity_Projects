using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Movement : MonoBehaviour
{
    public float speed;
    private Vector3 moveVector = Vector3.zero;
    public CharacterController controller;
    private float verticalvelocity;
    private float gravity = 9.8f;
    public bool isAlive = true;
    private float rotateangle = 90f;
    
    public bool swipe = false;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
        moveVector = transform.forward;
        moveVector = transform.TransformDirection(moveVector);
        moveVector *= speed;

       
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(swipe);

        if (isAlive)
        {
            if (controller.isGrounded)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    verticalvelocity = 5.3f;
                }
                else
                    verticalvelocity = -0.5f;
            }
            else
            {
                verticalvelocity -= gravity * Time.deltaTime;
                //Debug.Log(verticalVelocity);

            }

            if (verticalvelocity <= -11)
            {
                isAlive = false;
            }
            //moveVector.x = Input.GetAxis("Horizontal")*speed;

            moveVector.y = verticalvelocity;
            if (swipe)
            {
                if (Input.GetKeyUp(KeyCode.LeftArrow))
                {
                    RotateLeftDirection();
                    swipe = false;
                }

                else if (Input.GetKeyUp(KeyCode.RightArrow))
                {
                    RotateRightDirection();
                    swipe = false;
                }
            }

            controller.Move(moveVector * Time.deltaTime);
        }

        else
            isAlive = false;
            return;   
    }

    void RotateLeftDirection()
    {  
        transform.Rotate(0, -90, 0);
        moveVector = Quaternion.AngleAxis(-90, Vector3.up) * moveVector;     
    }

    void RotateRightDirection()
    {    
        transform.Rotate(0, 90, 0);
        moveVector = Quaternion.AngleAxis(90, Vector3.up) * moveVector;   
    }
}
