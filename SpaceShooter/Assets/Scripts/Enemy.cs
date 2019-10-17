﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]

    private float _speed = 4f;
    // Update is called once per frame
    void Update()
    {
        // move the enemy down at 4 unites per second4

        //if position on Y is at the bottom of the sceeen, move to the top

        //move the laser down (good :) )
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -7.97f)
        {
            float x = Random.Range(-8.5f, 8.5f); // generate a number between -8.5f and 8.5f
            transform.position = new Vector3(x, 7f, 0);
        }
       
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Hit: " + other.name);

        //if the "other" obejct's tag is Player
        //Damage the player
        //Destroy this gameobject

        //if the "other" object's tag is Laser
        //Destroy the laser
        //Destroy this gameobject

        
    }
}