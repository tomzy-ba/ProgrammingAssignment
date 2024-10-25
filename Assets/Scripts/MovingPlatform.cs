using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    float timer;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("TIMER: " + timer);
            if (timer > .5)
            {
                transform.position += transform.forward * 8 * Time.deltaTime;
            } else
            {
                timer += Time.deltaTime;
            }
        }
    }
}
