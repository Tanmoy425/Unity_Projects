using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    private CharacterController controller;
    private float speed = 3.0f;
    private Vector3 moveVector;
    private float verticalVelocity = 0.0f;
    float jumpspeed = 12.0f;
    private float graavity = 10;
    float animationDuration = 3.0f;
    public bool ifAlive = true;
    public Text GameOverText;
    AudioSource m_Audio;
    public AudioClip onpickup;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        GameOverText.gameObject.SetActive(false);
        m_Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ifAlive)
        {
            if (Time.time < animationDuration)
            {
                controller.Move(Vector3.forward * speed * Time.deltaTime);
                return;
            }

            moveVector = Vector3.zero;
            if (controller.isGrounded)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    verticalVelocity = 3.0f;
                }
                else
                    verticalVelocity = -0.5f;
            }
            else
            {
                verticalVelocity -= graavity * Time.deltaTime;
                Debug.Log(verticalVelocity);
                
            }

            if (verticalVelocity <= -11)
            {
                ifAlive = false;
                printText();
            }
            moveVector.x = Input.GetAxis("Horizontal") * speed;
            moveVector.y = verticalVelocity;
            moveVector.z = speed;

            if (Input.GetKey(KeyCode.LeftArrow))
            {



            }

            controller.Move(moveVector * speed * Time.deltaTime);
        }
        
        
        
    }
    void printText()
    {
        GameOverText.gameObject.SetActive(true);
        GameOverText.text = "Game Over";
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PowerUp")
        {
            other.gameObject.SetActive(false);
            Debug.Log("powerUp picked up");
            m_Audio.PlayOneShot(onpickup);
        }
    }

    
}
