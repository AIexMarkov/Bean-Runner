using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinLineLength : MonoBehaviour
{
    public int numberOfCoinsInLine = 7; //how many coins will spawn in a line
    [SerializeField] GameObject coinPrefab; //the collectable we want to spawn
    [SerializeField] GameObject spawnPoint; //where it will spawn it
    float spawnPointPositionZ = 0f; //the Z variable we will be updating
    
    void Start()
    {
        spawnPointPositionZ = spawnPoint.transform.position.z; //set the starting position of the variable (neccessary because of the procedural generation)
        for (int i = 0; i < numberOfCoinsInLine; i++) //loop where we spawn the collectibles
        {
            int spawnIndex = 0;
            Transform coinSpawnPoint = transform.GetChild(spawnIndex).transform; //we access the coin spawn point coordinates
            Instantiate(coinPrefab, coinSpawnPoint.position, Quaternion.identity, transform); //we spawn a collectible
            spawnPointPositionZ += 2; //we increase the variable
            spawnPoint.transform.position = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPointPositionZ); //we move the spawn point forward
        }
    }

    //method for the debugger
    public void ChangeCoinsPerLine(float value)
    {
        numberOfCoinsInLine = Mathf.RoundToInt(value);
    }
}
