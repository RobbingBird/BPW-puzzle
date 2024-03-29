using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    public GameObject door;

    private AudioSource doorClose;

    private void OnTriggerEnter(Collider other)
    {
        door.SetActive(true); 

        doorClose = gameObject.GetComponent<AudioSource>();
        doorClose.Play();

        gameObject.GetComponent<BoxCollider>().enabled = false;
    }
}
