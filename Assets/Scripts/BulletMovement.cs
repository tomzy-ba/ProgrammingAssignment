using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public Transform target;
    Rigidbody rb;
    MeshRenderer mr;

    private int bulletSpeed = 22;
    private Vector3 targetPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetPosition = target.position + new Vector3(Random.Range(15f, -15f), 0, 0);
        rb = GetComponent<Rigidbody>();
        mr = GetComponent<MeshRenderer>();
        Vector3 targetDirection = target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(targetDirection);

        mr.material.SetColor("_BaseColor", Color.red);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, bulletSpeed * Time.deltaTime);
        float dist = Vector3.Distance(transform.position, targetPosition);
        if (dist < 0.1)
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        //Debug.Log(target);
        //Vector3 direction = (target.position - transform.position).normalized;
        //rb.linearVelocity = direction * 20;
    }
}
