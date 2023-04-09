using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOtherPlayerScripts : MonoBehaviourPunCallbacks
{
    public GameObject mainCamera, canvas;
    private void Start()
    {
        // Disable other players control scripts
        if (!photonView.IsMine) {
            //print("Player object not mine");
            mainCamera.SetActive(false);
            canvas.SetActive(false);
            GetComponent<MultiplayerPlayerControl>().enabled = false;
            GetComponent<PlayerControllerLeftRight>().enabled = false;
        }
        else
        {
            mainCamera.SetActive(true);
            canvas.SetActive(true);
            GetComponent<MultiplayerPlayerControl>().enabled = true;
            GetComponent<PlayerControllerLeftRight>().enabled = true;

        }
    
    }

}
