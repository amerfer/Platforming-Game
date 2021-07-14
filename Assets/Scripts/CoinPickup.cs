using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int value;
    public GameObject pickupEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //when another collider trigger the object that is attach with this script
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<GameManager>().addCoin(value); // Finds the "GameManger" object and does this function
            Instantiate(pickupEffect, transform.position, transform.rotation);
            Destroy(gameObject); //removes the coin object
        }
    }
}
