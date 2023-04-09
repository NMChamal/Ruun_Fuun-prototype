using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColideBeforeFinish : MonoBehaviour
{
    public GameObject finishLine;

    private FinishLine fl;

    private void Start()
    {
        fl = finishLine.GetComponent<FinishLine>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            MultiplayerPlayerControl mpc = other.GetComponent<MultiplayerPlayerControl>();
            if (mpc.isMine)
                fl.playerCrash = true;
            else
                fl.opponentCrash = true;
        }
    }
}
