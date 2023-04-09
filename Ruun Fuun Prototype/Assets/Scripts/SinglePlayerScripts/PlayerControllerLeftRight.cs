using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class PlayerControllerLeftRight : MonoBehaviour
{
    // Start is called before the first frame update

    private Touch touch;
    private float speedModifier;
    private bool isMine;

    private PlayerController playerController;
    void Start()
    {
        speedModifier = 0.01f;

        playerController = gameObject.GetComponent<PlayerController>();

    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (!playerController.isGameEnd)
            {
                touch = Input.GetTouch(0);
                Vector3 movement = Vector3.zero;
                if (touch.phase == TouchPhase.Moved)
                {
                    transform.position = new Vector3(
                            transform.position.x - touch.deltaPosition.x * speedModifier,
                            transform.position.y,
                            transform.position.z);

                }
            }
        }
    }
}
