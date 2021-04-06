
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    //this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, runDirection, 0), 0.25f); (rotation);
    private CharacterController controller;
    private float speed = 4.0f;
    private Vector3 moveVector;
    private float verticalVelocity = 0.0f;
    private float graavity = 9.8f;
    private float animationDuration = 3.0f;
    private float startTime = 0.0f;


    public bool isAlive = true;
    private AudioSource m_Audio;
    public AudioClip onpickup;
    public int MaxValue = 100;
    public float CurrentEnergy;
    public float CurrentPowerUpValue;
    
    public float bulletCount = 0;
    public Energybar Energybar;
    public Energybar Bulletbar;
    public Healthbar PowerUpBar;
    public Camera activecamera;
    

    //public ParticleSystem particleSystem;

    public GameObject rayeffectObject;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        m_Audio = GetComponent<AudioSource>();
        CurrentEnergy = 30;
        CurrentPowerUpValue = 50;
        Energybar.setMaxEnergy(MaxValue);
        Energybar.SetHEnergy(CurrentEnergy);
        PowerUpBar.setMaxHealth(MaxValue);
        PowerUpBar.setHealth(CurrentPowerUpValue);
        Bulletbar.setMaxEnergy(5);
        Bulletbar.SetHEnergy(0);
        startTime = Time.time;
        bulletCount = 0;

       
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            

            if (Time.time - startTime < animationDuration)
            {
                controller.Move((Vector3.forward * speed) * Time.deltaTime);
                return;
            }

            moveVector = Vector3.zero;
            if (controller.isGrounded)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    verticalVelocity = 5.3f;
                }
                else
                    verticalVelocity = -0.5f;
            }
            else
            {
                verticalVelocity -= graavity * Time.deltaTime;
                //Debug.Log(verticalVelocity);

            }

            if (verticalVelocity <= -11)
            {
                isAlive = false;
            }
            moveVector.x = Input.GetAxis("Horizontal") * speed;
            moveVector.y = verticalVelocity;
            moveVector.z = speed;

            controller.Move(moveVector * Time.deltaTime);

           
            if(Input.GetMouseButtonDown(0))
            {
                shoot();
            }

        }
        else
            return;
          
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Energy")
        {
            other.gameObject.SetActive(false);
            Debug.Log("Energy picked up");
            Debug.Log(CurrentEnergy);
            m_Audio.PlayOneShot(onpickup);
            CurrentEnergy += 20;
            Energybar.SetHEnergy(CurrentEnergy);
        }

        else if(other.gameObject.tag == "PowerUp")
        {
            other.gameObject.SetActive(false);
            Debug.Log("powerUp picked up");
            m_Audio.PlayOneShot(onpickup);
            CurrentPowerUpValue += 15;
            PowerUpBar.setHealth(CurrentPowerUpValue);
        }
        
        if(other.gameObject.tag == "Bullet")
        {
            bulletCount++;
            Bulletbar.SetHEnergy(bulletCount);
        }

        if (other.gameObject.tag == "Obstacle")
        {
            Debug.Log(speed);
            Debug.Log(CurrentPowerUpValue + " ");
            TakeDamage(25);
            Debug.Log(CurrentPowerUpValue);
            if (speed <= 6)
            {
                speed = 4f;
            }
            speed = speed - 2;
        }
        Debug.Log(bulletCount);
    }

   

    public void SetSpeed(int mod)
    {
        speed = 3.0f + mod;
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        /*if(hit.point.z >=  transform.position.z + controller.radius)
        {
            Death();
        }*/

        if(hit.gameObject.tag == "Death")
        {
            Death();
        }
        
    }
    void Death()
    {
        isAlive = false;
        //Debug.Log("Death");
    }

    void TakeDamage(int damage)
    {
        CurrentPowerUpValue -= damage;
        CurrentEnergy -= damage;
        PowerUpBar.setHealth(CurrentPowerUpValue);
        Energybar.SetHEnergy(CurrentEnergy);
    }

    void shoot()
    {
        if(bulletCount>0)
        {
            bulletCount--;
            Bulletbar.SetHEnergy(bulletCount);
        }
       
        //particleSystem.Play();
        Debug.Log("Shot");
        RaycastHit hit;
        //ray = activecamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(activecamera.transform.position,activecamera.transform.forward, out hit))
        {
            Debug.Log(hit.transform.name);
            EnemyFollower target = hit.transform.GetComponent<EnemyFollower>();
            if(target != null)
            {
                target.TakeDamageFromPlayer(20);
            }
            GameObject rayeffect = Instantiate(rayeffectObject, hit.point, Quaternion.LookRotation(hit.normal)) as GameObject;
            //Destroy(rayeffectObject, 5);
        }
    }

}
