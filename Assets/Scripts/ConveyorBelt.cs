using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    private float conveyorForce = 40000f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("on conveyor");
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * conveyorForce);
    }
}
