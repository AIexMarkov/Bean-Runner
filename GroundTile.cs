using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    private GroundSpawner groundSpawner;  //access the ground spawner script so the level can continue indefinitely
    [SerializeField] GameObject coinLinePrefab; //get the coin prefab
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject obstaclePrefab2; //get all the obstacles
    [SerializeField] GameObject obstaclePrefab3;
    [SerializeField] GameObject obstaclePrefab4;
    [SerializeField] float lowerLimitOfObstacleRotation = 0f;
    [SerializeField] float upperLimitOfObstacleRotation = 45f; //these are the limits of rotation for the spawned obstacles

    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>(); //we find the script that spawns these tiles
        
    }
    
    //when the player leaves a tile, we create a new tile at the end of the chain and destroy the tile he left after a brief delay
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name != "Player")
        {
            return;
        }
        groundSpawner.SpawnTile(true);
        Destroy(gameObject, 2);
    }

    public void SpawnObstacle()
    {
        int obstacleSpawnIndex = Random.Range(2, 5); //we choose a random point to spawn the obstacle there
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform; //we access the randomly chosen point based on it's index in the child array
        int randomObstactle = Random.Range(1, 5); //we randomly select which obstacle will spawn
        Vector3 rotationOfTheObstacle = new Vector3(0, Random.Range(lowerLimitOfObstacleRotation, upperLimitOfObstacleRotation), 0); //we determine the rotation of the obstacle on the y axxis
        //we randomly spawn an obstacle based on the random number generated above
        if (randomObstactle == 1) Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.Euler(rotationOfTheObstacle), transform);
        else if (randomObstactle == 2) Instantiate(obstaclePrefab2, spawnPoint.position, Quaternion.Euler(rotationOfTheObstacle), transform);
        else if (randomObstactle == 3) Instantiate(obstaclePrefab3, spawnPoint.position, Quaternion.identity, transform);
        else Instantiate(obstaclePrefab4, spawnPoint.position, Quaternion.identity, transform);
    }

    //identical method to the obstacle spawner
    public void SpawnCoins ()
    {
        int coinSpawnIndex = Random.Range(5, 8); //randomly determine position
        Transform coinSpawnPoint = transform.GetChild(coinSpawnIndex).transform; //access the position
        Instantiate(coinLinePrefab, coinSpawnPoint.position, Quaternion.identity, transform); //spawn the collectibles
    }
}
