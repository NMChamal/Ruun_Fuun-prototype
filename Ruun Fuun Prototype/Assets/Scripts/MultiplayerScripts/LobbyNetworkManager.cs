using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyNetworkManager : MonoBehaviourPunCallbacks
{
    public Text tt;
    private int playerCountNeeded = 2; // number of players required to start the game

    private bool levelLoading = false;
    private bool pressedStart;
    void Start()
    {
        tt.text = "Press start";
        pressedStart = false;
        Connect();
    }
    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public void Play()
    {
        pressedStart = true;
        PhotonNetwork.JoinRandomRoom();
    }
    private void Update()
    {



        if (PhotonNetwork.PlayerList.Length < 2)
        {
            int playerInRoom = Convert.ToInt32(PhotonNetwork.PlayerList.Length);
            int playersNeeded = 2 - playerInRoom;
            if (pressedStart)
                tt.text = "Waiting for " + playersNeeded + " players....";
        }
        else
        {
            if (!levelLoading)
            {
                tt.text = "2 players available game starting " + PhotonNetwork.PlayerList.Length + "  " + playerCountNeeded;
                OnJoinedRoom();
            }
        }

    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join a room");
        // create room
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 2, BroadcastPropsChangeToAll = true });
    }

    public override void OnJoinedRoom()
    {
        //PhotonNetwork.AutomaticallySyncScene = true; 
        Debug.Log("Joined a room" + PhotonNetwork.PlayerList.Length + "  " + playerCountNeeded);
        if (PhotonNetwork.PlayerList.Length == playerCountNeeded) // check if enough players have joined and the game hasn't started yet
        {
            Debug.Log("Starting game... OnPlayerEnteredRoom");
            PhotonNetwork.CurrentRoom.IsOpen = false;

            tt.text = "Starting game...";
            //PhotonNetwork.LoadLevel(3);
            if (PhotonNetwork.IsMasterClient)
            {
                tt.text = "Open the  scene";
                levelLoading = true;
                PhotonNetwork.LoadLevel(3);
            }

        }

    }

}
