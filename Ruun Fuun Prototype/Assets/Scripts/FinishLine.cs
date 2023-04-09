using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class FinishLine : MonoBehaviour
{
    public GameObject inPlayUi, gameEndUi;
    public Text playeScore, opponentScore, EndScoreboard;

    public bool playerCrash, opponentCrash;

    private bool playerEnd, opponentEnd, firstToFinish;
    private int playerEndScore, opponentEndScore;


    // Start is called before the first frame update
    void Start()
    {
        playerEnd = false;
        opponentEnd = false;
        firstToFinish = false;

        playerCrash = false;
        opponentCrash = false;

        inPlayUi.SetActive(true);
        gameEndUi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerEnd && opponentEnd)
        {
            if(playerEndScore > opponentEndScore)
                EndScoreboard.text = "You WIN \n\n\nYour score : " + playerEndScore + "\n\n Opponent score : " + opponentEndScore;
            else
                EndScoreboard.text = "You LOST \n\n\nOpponent score : " + opponentEndScore + "\n\nYour score : " + playerEndScore;

            if(playerEndScore == opponentEndScore)
            {
                EndScoreboard.text = "You DRAW \n\n\nYour score : " + playerEndScore + "\n\nOpponent score : " + opponentEndScore;
            }
        }
        else
        {
            EndScoreboard.text = "Your score : " + playerEndScore + "\n Opponent score : " + opponentEndScore;
        }

        if (playerCrash)
        {
            inPlayUi.SetActive(false);
            gameEndUi.SetActive(true);
            playerEnd = true;
            string ss = playeScore.text;
            ss = ss.Replace("Your Score : ", "");
            playerEndScore = Convert.ToInt32(ss);
        }
        if (opponentCrash) {
            opponentEnd = true;
            string ss = opponentScore.text;
            ss = ss.Replace("Opponent Score : ", "");
            opponentEndScore = Convert.ToInt32(ss);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            MultiplayerPlayerControl mpc = other.GetComponent<MultiplayerPlayerControl>();
            if (mpc.isMine && !playerEnd)
            {
                inPlayUi.SetActive(false);
                gameEndUi.SetActive(true);
                playerEnd = true;
                string ss = playeScore.text;
                ss = ss.Replace("Your Score : ", "");
                playerEndScore = Convert.ToInt32(ss);
            }
            if (!mpc.isMine && !opponentEnd)
            {
                opponentEnd = true;
                string ss = opponentScore.text;
                ss = ss.Replace("Opponent Score : ", "");
                opponentEndScore = Convert.ToInt32(ss);               
            }
        }
    }


}
