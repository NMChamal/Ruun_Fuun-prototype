using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUiControl : MonoBehaviour
{
    public string singlePlayerSceneName, lobby;

    public void OpenSinglePlayerGame() {
        SceneManager.LoadScene(singlePlayerSceneName);
    }    
    public void Open1v1Lobby() {
        SceneManager.LoadScene(lobby);
    }
}
