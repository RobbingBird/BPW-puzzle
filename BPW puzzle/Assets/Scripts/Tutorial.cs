using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorial;
    public GameObject tutorial1;
    public GameObject tutorial2;
    public GameObject tutorial3;
    public GameObject tutorial4;
    public GameObject Camera;
    public GameObject Player;

    private void Update()
    {
        if (gameObject.name == "Tutorial" && Input.anyKey)
        {
            tutorial1.SetActive(true);
            tutorial.SetActive(false);

            Camera.GetComponent<PlayerCam>().enabled = true;
        }
        else if (gameObject.name == "Tutorial (1)" && Mathf.Abs(Camera.transform.rotation.eulerAngles.x) > 40f)
        {
            tutorial2.SetActive(true);
            tutorial1.SetActive(false);

            Player.GetComponent<PlayerMovement>().enabled = true;
        }
        else if (gameObject.name == "Tutorial (2)" && Player.GetComponent<Rigidbody>().velocity.magnitude > 0.1f)
        {
            tutorial2.SetActive(false);
        } else if (gameObject.name == "Tutorial (3)" && Input.GetMouseButtonDown(0))
        {
            tutorial3.SetActive(false);
            tutorial4.SetActive(true);
        } else if (gameObject.name == "Tutorial (4)" && Input.GetMouseButtonDown(0))
        {
            tutorial4.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.name == "Trigger")
        {
            tutorial3.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
