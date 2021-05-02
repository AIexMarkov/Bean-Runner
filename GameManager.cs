using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int score = 0;
    public static GameManager inst; //singleton: insures that there won't be multiple instances of player score or game manager
    [SerializeField] Text scoreText; //Text that will be shown to the player
    [SerializeField] PlayerMove playerMovement; //accessing the PlayerMove script so we can increase the speed based on the score
    
    //this method increases the players score and speed, and calls the increase size method from the player script
    public void IncrementScore()
    {
        score++;
        scoreText.text = "BEANS: " + score;
        playerMovement.forwardSpeed += playerMovement.speedIncreasePerPoint;
        playerMovement.IncreaseSize();
    }
    //this method is setting up a singleton
    private void Awake()
    {
        inst = this;
    }
}
