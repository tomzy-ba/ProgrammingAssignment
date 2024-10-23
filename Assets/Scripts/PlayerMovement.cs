using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class PlayerMovement : MonoBehaviour
{
    public Transform orientation;

    Rigidbody rb;
    Player player;
    public GameObject playerUIGO;
    PlayerUI playerUI;


    
    public float moveSpeed = 20;

    private bool isJumpPressed;
    private bool grounded;
    private int jumpTicks;

    public float sensitivity = 20000f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GetComponent<Player>();
        playerUI = playerUIGO.GetComponent<PlayerUI>();
    }

    // Update is called once per frame
    void Update()
    {
        isJumpPressed = Input.GetButton("Jump");
        playerUI.UpdateUI(player);
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = orientation.forward * vertical + orientation.right * horizontal;
        rb.linearVelocity = moveDirection * 20;

        if(isJumpPressed && grounded)
        {
            if (jumpTicks > 500)
            {
                grounded = false;
                jumpTicks = 0;
                return;
            }
            Debug.Log("JUMP");
            rb.linearVelocity = new Vector3(0, 25, 0);
            jumpTicks += 1;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Ground" || collision.gameObject)
        {
            Debug.Log("Grounded");
            grounded = true;
            jumpTicks = 0;
        }
        //if (collision.gameObject.name == "Lava")
        //{
        //    Debug.Log("LAVA");
        //    player.TakeDamage(10);
        //}
    }
    //private void OnCollisionExit(Collision collision)
    //{
    //    Debug.Log("Not grounded");
    //    grounded = false;
    //}


}
