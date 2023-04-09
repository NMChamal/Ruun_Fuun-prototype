using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class MultiplayerPlayerControl : MonoBehaviourPunCallbacks
{
    public float moveSpeed = 2f;
    public Animator animator;
    public Text scoreText;
    public GameObject MatchEndPanal;
    public bool isGameEnd = false;
    public bool isMine;

    private int coinCount = 0;
    
    private Vector2 movementInput;
    void Awake()
    {
        if (photonView.IsMine)
        {
            GameObject[] ob = GameObject.FindGameObjectsWithTag("PlayerScore");
            scoreText = ob[0].GetComponent<Text>();
            isMine = true;
        }
        else
        {
            GameObject[] ob = GameObject.FindGameObjectsWithTag("opponentScore");
            scoreText = ob[0].GetComponent<Text>();
            isMine = false;
        }

        MatchEndPanal.SetActive(false);
        scoreText.text = "Your Score : " + coinCount;
        animator = gameObject.GetComponent<Animator>();
        animator.SetInteger("AnimInt", 1);
        coinCount = 0;

    }

    void Update()
    {
        if (!isGameEnd)
        {
            MovePlayer();
        }
    }

   

    private void MovePlayer()
    {
        animator.SetInteger("AnimInt", 1);
        Vector3 movement = Vector3.zero;
        movement.z = 2f;
        
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

            if(isMine)
                scoreText.text = "Your Score : " + coinCount;
            else
                scoreText.text = "Opponent Score : " + coinCount;
        }


    }

    private void SpeedReduse()
    {
        // reduse speed
        moveSpeed = 2f;
        animator.speed = 1;
    }

    public void HomeButton()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("MainUI");
    }

}
