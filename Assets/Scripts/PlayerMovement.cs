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

        player.SetName(PlayerPrefs.GetString("PlayerName"));
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
            rb.linearVelocity = Vector3.up * player.GetJumpForce();
            //rb.AddForce(Vector3.up * 20000);
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
            if (gameTimer < PlayerPrefs.GetFloat("Level1Time"))
            {
                PlayerPrefs.SetString("Level1Player", player.GetName());
                PlayerPrefs.SetFloat("Level1Time", gameTimer);
            }
            SceneManager.LoadScene("MainMenu");
        }
        else if (collision.gameObject.name == "EndCylinder2")
        {
            if (gameTimer < PlayerPrefs.GetFloat("Level2Time"))
            {
                PlayerPrefs.SetString("Level2Player", player.GetName());
                PlayerPrefs.SetFloat("Level2Time", gameTimer);
            }
            SceneManager.LoadScene("MainMenu");
        }
        else if (collision.gameObject.name == "EndCylinder3")
        {
            if (gameTimer < PlayerPrefs.GetFloat("Level3Time"))
            {
                PlayerPrefs.SetString("Level3Player", player.GetName());
                PlayerPrefs.SetFloat("Level3Time", gameTimer);
            }
            SceneManager.LoadScene("MainMenu");
        }
    }

}
