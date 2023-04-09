using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Animator animator;
    public Text scoreText;
    public GameObject MatchEndPanal;
    public bool isGameEnd = false;

    private int coinCount = 0;
    /*    private bool isMobile = false;
        private bool isMovingLeft = false;
        private bool isMovingRight = false;*/


    private Vector2 movementInput;
    void Awake()
    {
        /*        // Check is mobile platform
                if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer
                    || Application.platform == RuntimePlatform.WebGLPlayer)
                {
                    isMobile = true;
                }*/
        MatchEndPanal.SetActive(false);
        scoreText.text = "Your Score : " + coinCount;
        animator = gameObject.GetComponent<Animator>();
        animator.SetInteger("AnimInt", 1);
        coinCount = 0;

    }

    void Update()
    {
        /*        if (isMobile)
                {
                    // Do nothing, handle touch input in the event handlers
                }
                else
                {
                    // Handle keyboard input
                    HandleKeyboardInput();
                }*/

        // Move the player based on input
        if (!isGameEnd)
        {
            MovePlayer();
        }
    }

    /*    private void HandleKeyboardInput()
        {
            // Check for keyboard input
            isMovingLeft = Input.GetKey(KeyCode.A);
            isMovingRight = Input.GetKey(KeyCode.D);
        }*/

    /*private void HandleTouchInput()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.position.x < Screen.width / 2)
            {
                // Move left if the touch is on the left side of the screen
                isMovingLeft = true;
                isMovingRight = false;
            }
            else if (touch.position.x > Screen.width / 2)
            {
                // Move right if the touch is on the right side of the screen
                isMovingLeft = false;
                isMovingRight = true;
            }
        }
        else
        {
            // Stop moving if there is no touch input
            isMovingLeft = false;
            isMovingRight = false;
        }
    }*/

    private void MovePlayer()
    {
        animator.SetInteger("AnimInt", 1);
        Vector3 movement = Vector3.zero;
        movement.z = 2f;
        /*if (isMovingLeft)
        {
            movement.x = -1f;
        }
        else if (isMovingRight)
        {
            movement.x = 1f;
        }
        else
        {
            // If the player is not moving left or right??
        }*/

        // Move the player with delta time
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        // speed up
        if (other.gameObject.tag == "SpeedStrip")
        {
            moveSpeed = 10f;
            animator.speed = 2;
            Invoke("SpeedReduse", 3f);
        }

        // Game end trigger
        if (other.gameObject.tag == "TrackEnd")
        {
            isGameEnd = true;
            animator.SetInteger("AnimInt", 2);
            MatchEndPanal.SetActive(true);

        }

        // coin count up

        if (other.gameObject.tag == "Coin")
        {
            coinCount++;
            scoreText.text = "Your Score : " + coinCount;

        }


    }

    private void SpeedReduse()
    {
        // reduse speed
        moveSpeed = 2f;
        animator.speed = 1;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("SinglePlayer");
    }
    public void HomeButton()
    {
        SceneManager.LoadScene("MainUI");
    }
}
