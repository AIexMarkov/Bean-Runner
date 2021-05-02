using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject groundTile; //the tile we are gonna spawn
    Vector3 spawnPoint; //the point where we will spawn it

    //the method that spawns said tiles, the bool is checking whether or not items should spawn as well
    public void SpawnTile(bool spawnItems)
    {
        GameObject temp = Instantiate(groundTile, spawnPoint, Quaternion.identity); //we create a tile
        spawnPoint = temp.transform.GetChild(1).transform.position; //we update the position of spawnPoint so the next tile doesn't spawn on top of this one

        //in order to prevent the first few tiles from having obstacles that the player can't dodge, we only spawn items if the bool is true
        if (spawnItems)
        {
            temp.GetComponent<GroundTile>().SpawnObstacle();
            temp.GetComponent<GroundTile>().SpawnCoins();
        }
    }

    //here we spawn a few tiles at the start of the level
    void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            if (i < 3) SpawnTile(false); //the first 3 tiles won't have any items on them
            else SpawnTile(true);
        }
    }
}
