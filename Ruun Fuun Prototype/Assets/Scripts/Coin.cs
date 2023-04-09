using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject anim;

    private void Start()
    {
        anim.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            anim.SetActive(true);
            
            // Destroy gameobject aftger 1 second
            Invoke("DestroyCoin", 1f);
        }
    }

    private void DestroyCoin()
    {
        DestroyImmediate(gameObject);
    }


}
