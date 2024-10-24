using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float startTime;
    public Transform target;

    private float spawnRate = .75f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnObstacle());
    }
    IEnumerator SpawnObstacle()
    {
        // this will constantly loop the coroutine, then start a new one that deletes the obstacles after a certain amount of time
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            Debug.Log("Spawn obstacle");
            GameObject obstacle = Instantiate(bulletPrefab, transform);
            BulletMovement bulletMovement = obstacle.GetComponent<BulletMovement>();
            bulletMovement.target = target;
            StartCoroutine(DeleteObstacle(obstacle));
        }
    }
    IEnumerator DeleteObstacle(GameObject obstacle)
    {
        yield return new WaitForSeconds(10f);
        Destroy(obstacle);
    }
}
