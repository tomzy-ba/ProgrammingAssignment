using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Transform orientation;

    Rigidbody rb;
    Player player;
    public GameObject playerUIGO;
    PlayerUI playerUI;



    private float moveSpeed;
    private float oldSpeed;
    public float gameTimer;

    private bool isJumpPressed;
    private bool isSprinting;
    private bool grounded;
    private int jumpTicks;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GetComponent<Player>();
        playerUI = playerUIGO.GetComponent<PlayerUI>();

        moveSpeed = player.GetMoveSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer += Time.deltaTime;
        isJumpPressed = Input.GetButton("Jump");
        isSprinting = Input.GetKey(KeyCode.LeftShift);
        playerUI.UpdateUI(player);
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = orientation.forward * vertical + orientation.right * horizontal;
        rb.linearVelocity = moveDirection * moveSpeed;

        if(isJumpPressed && grounded)
        {
            if (jumpTicks > 500)
            {
                grounded = false;
                jumpTicks = 0;
                return;
            }
            Debug.Log("JUMP");
            rb.linearVelocity = new Vector3(horizontal, 25, vertical);
            jumpTicks += 1;
        }
        if (isSprinting)
        {
            moveSpeed = player.GetMoveSpeed() * 1.75f;
        }
        else
        {
            moveSpeed = player.GetMoveSpeed();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log( "Collision tag" + collision.gameObject.tag);
        //Debug.Log("Collision name" + collision.gameObject.name);
        if(collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Grounded");
            grounded = true;
            jumpTicks = 0;
        }
        else if (collision.gameObject.name == "Lava")
        {
            Debug.Log("LAVA");
            player.TakeDamage(1000);
        }
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Took a bullet");
            player.TakeDamage(10);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.name == "EndCylinder1")
        {
            // end level 1
            PlayerPrefs.SetFloat("Level1Time", gameTimer);
            SceneManager.LoadScene("MainMenu");
        }
        else if (collision.gameObject.name == "EndCylinder2")
        {
            PlayerPrefs.SetFloat("Level2Time", gameTimer);
            SceneManager.LoadScene("MainMenu");
        }
        else if (collision.gameObject.name == "EndCylinder3")
        {
            PlayerPrefs.SetFloat("Level3Time", gameTimer);
            SceneManager.LoadScene("MainMenu");
        }
    }

}
