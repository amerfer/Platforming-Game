using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    public PlayerController thePlayer;
    //public GameObject respawnObject;

    public float invincibilityLength; //how long the player will be invincible
    private float invincibilityCounter; // how long the player stays invincible

    private bool isRespawing;
    [SerializeField]  private Vector3 respawnPoint;
    public float respawnLength;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 3 ; // Max health start with 5 

        //FindObjectOfType<GameManager>().showHearts(currentHealth);
        //thePlayer = FindObjectOfType<PlayerController

        respawnPoint = thePlayer.transform.position;
        //respawnPoint = respawnObject.transform.position; //this is where the repawn point is
    }

    // Update is called once per frame
    void Update()
    {
        FindObjectOfType<GameManager>().showHearts(currentHealth);// display the current health in the UI

        if (invincibilityCounter >= 0)
        {
            invincibilityCounter -= Time.deltaTime; // counts down how long the player takes damage
        }
    }

    public void HurtPlayer (int damage, Vector3 direction)
    {
        if (invincibilityCounter <= 0) //if the counter for invincibilty is finished
        { 
            currentHealth -= damage; // current healt will decrease if taken damage

            if (currentHealth == 0) //if health is 0, respawn
            {
                Respawn();// call the respawn function
            }

            else
            { 
                thePlayer.Knockback(direction);

                invincibilityCounter = invincibilityLength;

            }
        }
    }

    public void Respawn()
    {
        //currentHealth = maxHealth; //resets the health
        //thePlayer.transform.position = respawnPoint; //resets the player at a positon
        
      
            StartCoroutine("Respawnco");
        
    }

    public IEnumerator Respawnco()
    {

        yield return new WaitForSeconds(respawnLength); // wait for a certain amount of seconds, then do the next step
        

        
        thePlayer.transform.position = respawnPoint; //resets the player at a positon
        currentHealth = maxHealth; //resets the health
        
    }

    public void HealPlayer(int healAmout)
    {
        currentHealth += healAmout; //current amount wull be added  

        //if the current health reaches the max amount, set it at the max amount
        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
