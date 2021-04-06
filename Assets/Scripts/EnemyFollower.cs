using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollower : MonoBehaviour
{
    public GameObject TargetToFollow;
    public Vector3 offset;
    public Healthbar healthbar;
    private float CurrentHealth;

    void Start()
    {
        CurrentHealth = 100f;
        
        healthbar.setMaxHealth(100);

    }
    public void TakeDamageFromPlayer(float amount)
    {
        CurrentHealth -= amount;
        healthbar.setHealth(CurrentHealth);
        if(CurrentHealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        transform.position = TargetToFollow.transform.position + offset;
        transform.rotation = TargetToFollow.transform.rotation;
    }
}
