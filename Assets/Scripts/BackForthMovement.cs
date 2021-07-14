using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackForthMovement : MonoBehaviour
{
    public float speed; // speed of the enemy

    public float minZ;
    public float maxZ;

    public float minX;
    public float maxX;

    public float length;
    public bool xValueTrue;

    void Start()
    {

        minZ = transform.position.z;
        maxZ = transform.position.z + length;

        minX = transform.position.x;
        maxX = transform.position.x + length;

    }

    // Update is called once per frame
    void Update()
    {
        //if i want the enemey to move at the x axis
        if(xValueTrue == true)
        {
            transform.position = new Vector3(Mathf.PingPong(Time.time * speed, maxX - minX) + minX, transform.position.y, transform.position.z);
        }

        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.PingPong(Time.time * speed, maxZ-minZ) + minZ);
        }
        
    }
}
