using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float rotatingSpeed = 90f; //the speed at which the coins rotate

    //what happens when something (Player) collides with the coins
    private void OnTriggerEnter(Collider other)
    {
        //this ensures that the coins don't spawn inside obsticles
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }
        //this is a "safety net", to prevent the coins from being collected if they collide with something other than player or obstacle
        if (other.gameObject.name != "Player")
        {
            return;
        }
        //increase the score, play the sound and destroy coin
        GameManager.inst.IncrementScore();
        AudioManager.PlaySound("EatBean");
        Destroy(gameObject);
    }

    

    void Update()
    {
        //here we rotate the coins
        transform.Rotate(0, rotatingSpeed * Time.deltaTime, 0);
    }
}
