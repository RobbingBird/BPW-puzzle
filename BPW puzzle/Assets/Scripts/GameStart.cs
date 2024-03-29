using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public GameObject Player;
    public GameObject Camera;

    private void Start()
    {
        Player.GetComponent<PlayerMovement>().enabled = false;
        Camera.GetComponent<PlayerCam>().enabled = false;
    }
}
