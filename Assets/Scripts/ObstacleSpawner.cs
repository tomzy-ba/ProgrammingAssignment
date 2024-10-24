using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float startTime;
    public Transform target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnObstacle());
    }
    IEnumerator SpawnObstacle()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            Debug.Log("Spawn obstacle");
            GameObject obstacle = Instantiate(bulletPrefab, transform);
            BulletMovement bulletMovement = obstacle.GetComponent<BulletMovement>();
            bulletMovement.target = target;
            yield return new WaitForSeconds(8f);
            Destroy(obstacle);
        }
    }
}
