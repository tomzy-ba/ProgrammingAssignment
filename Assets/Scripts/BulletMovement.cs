using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public Transform target;
    Rigidbody rb;
    MeshRenderer mr;

    private int bulletSpeed = 16;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
        Vector3 targetPosition = target.position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, bulletSpeed * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        //Debug.Log(target);
        //Vector3 direction = (target.position - transform.position).normalized;
        //rb.linearVelocity = direction * 20;
    }
}
