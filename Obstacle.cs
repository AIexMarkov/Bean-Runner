using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle: MonoBehaviour
{
    PlayerMove playerMovement; //we access the player script so that we can kill him


    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMove>(); //we find the script here since playerMovement is a private variable
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player" && playerMovement.alive == true) //on collision with the player exclusively, he dies
        {
            playerMovement.Die();
        }
    }
}
