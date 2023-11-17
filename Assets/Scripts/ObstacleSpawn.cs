using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // an array of obstacle prefab
    public GameObject colorchangespawn;
    public Transform playerTransform; // the transform of the player
    public float spawnY = 10f; // the initial y-position to spawn obstacles
    public float spawnDistance = 5f; // the distance between each obstacle

    private void Update()
    {
        // if the player is close to the spawn position, spawn a new obstacle
        if (playerTransform.position.y + 15 > spawnY)
        {
            SpawnObstacle();
        }
    }

    private void SpawnObstacle()
    {
        // choose a random obstacle prefab from the array
        GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];



        // instantiate the obstacle prefab at the position and rotation
        Instantiate(obstaclePrefab, new Vector3(0, spawnY, 0), Quaternion.identity);
        Instantiate(colorchangespawn, new Vector3(0, spawnY + 3f, 0), Quaternion.identity);

        // update the spawn position for the next obstacle
        spawnY += spawnDistance;
    }
}