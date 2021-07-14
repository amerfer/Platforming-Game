using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickup : MonoBehaviour
{
    public int value;
    public GameObject heartEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (FindObjectOfType<HealthManager>().currentHealth < FindObjectOfType<HealthManager>().maxHealth) //Checks if the current health at max 
        {
            if (other.tag == "Player")
            {
                
                FindObjectOfType<HealthManager>().HealPlayer(value); // Finds the "HealthManager" object and does this
                Instantiate(heartEffect, transform.position, transform.rotation); 
                Destroy(gameObject); //removes the heart object
            }
        }
    }
}
