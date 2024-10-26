using UnityEngine;

public class BouncyPlatform : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            rb.linearVelocity = Vector3.up * 2000;
        }
    }
}
