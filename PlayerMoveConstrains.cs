using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveConstrains : MonoBehaviour
{
    //here we constrain the player movement so that he can't go outside the camera bounds
    [SerializeField] GameObject player;
    [SerializeField] Transform playerPosition; //we get the player and his position
    
    void Update()
    {
        if (playerPosition.position.x > 5.5f) //every frame, we push the player back if he goes too far off one side of the map
        {
            player.transform.position = new Vector3(5.5f, playerPosition.position.y, playerPosition.position.z);
        }
        if (playerPosition.position.x < -5.5f)
        {
            player.transform.position = new Vector3(-5.5f, playerPosition.position.y, playerPosition.position.z);
        }
    }
}
