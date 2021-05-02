using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float forwardSpeed = 5f; //player speed, accessed by the Game Manager script
    public float speedIncreasePerPoint = 0.01f; //the amount which the speed increases, accessed by the Game Manager script
    public Rigidbody rb; //we find the players rigidbody
    [SerializeField] Joystick joystick; //we find the joystick on screen
    [SerializeField] float jumpHeight = 10f; //we set the height/force of the players jump
    [SerializeField] float horizontalMultiplier = 2f; //how much faster will the horizontal movement be compared to vertical
    [SerializeField] float delayAfterDeath = 2f; //how long will we wait for the game to restart upon death
    [SerializeField] float forceOfBoost = 500; //how high will the player be launched when boosted
    [SerializeField] float speedOfBoost = 5; //how much faster will the player be when boosted
    [SerializeField] float increamentOfPlayerSizeIncrease = 0.1f; //how much larger will the player be when he collects a bean
    [SerializeField] int amountOfBeansForBoost = 15; //how many does he need to collect to get the boost
    [SerializeField] AudioSource audioSource; //access the audio source so we can stop sound on death
    public bool alive = true; //whether the character is alive or not. Resets upon death
    bool canJump = true; //whether the player can or can't jump. Resets when the player collides with ground
    bool gotBoost = false; //this is to later check if the player landed from the boost
    int counter = 0; //counter for the boost


    private void FixedUpdate() //fixed update so the movement is smoother
    {
        if (!alive) return; //end the update upon death, preventing movement
        
        rb.velocity = new Vector3(joystick.Horizontal * horizontalMultiplier, rb.velocity.y, forwardSpeed); //move player forward along the Z axis, and move him horizontally if the joystick is moved
        if (joystick.Vertical >= 0.75f && canJump == true) //prevent the player from accidentaly jumping by placing a threshold on the joystick
        {
            canJump = false; //prevent the player from jumping midair
            rb.AddForce(0, jumpHeight, 0, ForceMode.Impulse); //adding force to the player so that he jumps
        }

        if (counter >= amountOfBeansForBoost) //here we check if the amount of beans collected is enough to give player the boost
        {
            counter = 0;
            Boost();
        }

        if (transform.position.y < -10) //if the player falls off of the platform, call the death method
        {
            Die();
        }
    }

    //if the player collides with anything that isn't a trigger collider and that doesn't kill him - so just the ground
    private void OnCollisionEnter(Collision collision) 
    {
        canJump = true; //reset jump
        if (gotBoost == true) //this is to check whether or not the player just landed from the boost, and takes away boost speed
        {
            gotBoost = false;
            forwardSpeed -= speedOfBoost;
        }
    }

    public void IncreaseSize() //called when we pick up a bean, increase the size of the player and the counter variable
    {
        counter++;
        transform.localScale += new Vector3(increamentOfPlayerSizeIncrease, increamentOfPlayerSizeIncrease / 3, increamentOfPlayerSizeIncrease);
    }

    public void Boost() //the boost mechanic. Resets the player size, plays sfx, adds force for the mega jump, boosts player speed, and disables jump until landing
    {
        transform.localScale = new Vector3(1, 1, 1);
        AudioManager.PlaySound("Boost");
        rb.AddForce(0, forceOfBoost, 0);
        forwardSpeed += speedOfBoost;
        gotBoost = true;
        canJump = false;
    }

    public void Die() //player death
    {
        alive = false;
        audioSource.Stop();
        rb.freezeRotation = false;
        int randomX = Random.Range(0, 3);
        int randomY = Random.Range(0, 3);
        int randomZ = Random.Range(0, 3);
        rb.AddForce(randomX, randomY, randomZ, ForceMode.Impulse); //random force is applied to show the player they died
        AudioManager.PlaySound("OhBeans");
        Invoke("Restart", delayAfterDeath);
    }

    void Restart() //restart after player death
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //change the speed in the debugger AFTER the debugger is changed
    public void AdjustSpeedInDebugger (float newSpeed) 
    {
        forwardSpeed = newSpeed;
    }
    public void AdjustSpeedIncreaseInDebugger(float newSpeed)
    {
        speedIncreasePerPoint = newSpeed;
    }
    public void AdjustForceOfBoostInDebugger(float value)
    {
        forceOfBoost = value;
    }
    public void AdjustSpeedOfBoostInDebugger(float value)
    {
        speedOfBoost = value;
    }
    public void AdjustNumberOfCoinsNeededInDebugger(float value)
    {
        amountOfBeansForBoost = Mathf.RoundToInt(value);
    }
}
