using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MultiplayerSpwnManager : MonoBehaviourPunCallbacks
{
    public Text testPetItem;
    public GameObject []playerSpawnPos;
    public GameObject playerPrefab;
    // public GameObject pet;
    // Start is called before the first frame update
    void Start()
    {
        // Spawn players
        GameObject PlayerToSpawn = playerPrefab;
        if (PhotonNetwork.IsMasterClient)
        {
            GameObject newObject = PhotonNetwork.Instantiate(PlayerToSpawn.name, playerSpawnPos[0].transform.position, Quaternion.identity);
        }
        else
        {
            GameObject newObject = PhotonNetwork.Instantiate(PlayerToSpawn.name, playerSpawnPos[1].transform.position, Quaternion.identity);
        }
    }

/*    public void OpenSceneMethod()
    {
        SceneManager.LoadScene(0);
    }*/

    //if (!photonView.IsMine){}
    //if (PhotonNetwork.IsMasterClient){}

}
