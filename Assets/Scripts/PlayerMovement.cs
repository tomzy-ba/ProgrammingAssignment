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


    
    public float moveSpeed = 20;
    public float gameTimer;

    private bool isJumpPressed;
    private bool grounded;
    private int jumpTicks;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GetComponent<Player>();
        playerUI = playerUIGO.GetComponent<PlayerUI>();
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer += Time.deltaTime;
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
            rb.linearVelocity = new Vector3(horizontal, 25, vertical);
            jumpTicks += 1;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log( "Collision tag" + collision.gameObject.tag);
        Debug.Log("Collision name" + collision.gameObject.name);
        if(collision.gameObject.name == "Ground" || collision.gameObject)
        {
            Debug.Log("Grounded");
            grounded = true;
            jumpTicks = 0;
        }
        if (collision.gameObject.name == "Lava")
        {
            Debug.Log("LAVA");
            player.TakeDamage(1000);
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Took a bullet");
            player.TakeDamage(10);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "EndCylinder1")
        {
            // end level 1
            PlayerPrefs.SetFloat("Level1Time", gameTimer);
            SceneManager.LoadScene("MainMenu");
        }
        if (collision.gameObject.name == "EndCylinder2")
        {
            PlayerPrefs.SetFloat("Level2Time", gameTimer);
            SceneManager.LoadScene("MainMenu");
        }
    }

}
