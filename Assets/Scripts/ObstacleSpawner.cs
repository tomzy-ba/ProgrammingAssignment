using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float startTime;
    public Transform target;

    public float spawnRate = .6f;

    private bool activated = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnObstacles());
    }
    IEnumerator SpawnObstacles()
    {
        // this will constantly loop the coroutine
        while (activated)
        {
            yield return new WaitForSeconds(spawnRate);
            for (int i = 0; i < 2; i++)
            {
                Debug.Log("Spawn obstacle");
                GameObject obstacle = Instantiate(bulletPrefab, transform);
                BulletMovement bulletMovement = obstacle.GetComponent<BulletMovement>();
                bulletMovement.target = target;
            }
            //StartCoroutine(DeleteObstacle(obstacle));
        }
    }
    //IEnumerator DeleteObstacle(GameObject obstacle)
    //{
    //    yield return new WaitForSeconds(10f);
    //    Destroy(obstacle);
    //}
    void SpawnObstacle()
    {

    }
}
