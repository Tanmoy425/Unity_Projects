using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public float score = 0f;
    private int Speedlevel = 1;
    private int maxSpeedLevel = 10;
    private int scoreToNextLevel = 10;
    private float slowMoTime = 0.1f;
    private float normalTime = 1.0f;
    private GameObject player;
   
    private Player_Controller playerControllerScript;
    private Level2Movement playerlevel2;

    private bool slowMoActive = false;
    bool rotate = false;

    public Text scoreText;
    public DeathMenu deathmenu;
    public GameObject gun;
    public GameObject powerup;
    public GameObject energy;

    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        //audio = GetComponent<AudioSource>();
            
        player = GameObject.FindGameObjectWithTag("Player");
        playerControllerScript = player.GetComponent<Player_Controller>();
        playerlevel2 = player.GetComponent<Level2Movement>();

       
    }

    // Update is called once per frame
    void Update()
    {
        
        if(playerControllerScript.bulletCount >= 5)
        {
            gun.SetActive(true);
        }
        if (playerControllerScript.isAlive)
        {
            if (score >= scoreToNextLevel)
            {
                levleUp();
            }
            score += Time.deltaTime * Speedlevel;
            scoreText.text = ((int)score).ToString();

            if (Input.GetKey(KeyCode.C))
            {
                if (playerControllerScript.bulletCount >= 5)
                {
                    Debug.Log(playerControllerScript.bulletCount);

                    if (playerControllerScript.CurrentEnergy > 50)
                    {
                        Debug.Log(playerControllerScript.CurrentEnergy);

                        if (!slowMoActive)
                        {
                            Time.timeScale = slowMoTime;
                            Time.fixedDeltaTime = 0.02f * Time.timeScale;

                            Debug.Log("active");
                            rotate = true;
                            player.GetComponent<CapsuleCollider>().enabled = !player.GetComponent<CapsuleCollider>().enabled;
                            //RotateAndShoot();

                        }
                    }
                }
            }

            if (rotate)
            {
                player.transform.Rotate(Vector3.up * Time.deltaTime * 90);

                if (player.transform.rotation.y < 0)
                {
                    rotate = false;
                    player.GetComponent<CapsuleCollider>().enabled = !player.GetComponent<CapsuleCollider>().enabled;
                    Time.timeScale = normalTime;
                    Time.fixedDeltaTime = 0.02f * Time.timeScale;
                    slowMoActive = false;

                    Debug.Log("Not active");
                }
                else
                {
                    playerControllerScript.CurrentEnergy -= 3 * Time.deltaTime;
                    playerControllerScript.Energybar.SetHEnergy(playerControllerScript.CurrentEnergy);
                    Debug.Log(playerControllerScript.CurrentEnergy);
                }
            }
        }
        else
        {
            onDeath();
        }
    }

    void levleUp()
    {
        if(Speedlevel == maxSpeedLevel)
        {
            return;
        }
        scoreToNextLevel *= 2;
        Speedlevel++;

        playerControllerScript.SetSpeed(Speedlevel);
    }

    void onDeath()
    {
        if(PlayerPrefs.GetFloat("HighScore") < score)
        {
            PlayerPrefs.SetFloat("HighScore", score);
        }
        deathmenu.ToggleEndMenu(score);
    }
}
