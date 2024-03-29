using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Interacts : MonoBehaviour
{
    public Camera mainCamera;

    public LayerMask interactions;

    public float interactionRange;

    private int orderNumber = 1;
    private int pressedButton;
    private int doorClosed = 3;

    private bool interactHit = false;

    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    public GameObject Window1;
    public GameObject Window2;
    public GameObject Portal1;
    public GameObject Portal2;
    public GameObject Portal3;
    public GameObject Portal4;
    public GameObject Portal5;
    public GameObject Portal6;

    public Image cursor;

    public AudioSource Click;
    public AudioSource Wrong;
    public AudioSource DoorOpen;


    void Update()
    {
        //interactDetection
        interactHit = false;

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionRange, interactions) && Input.GetMouseButtonDown(0))
        {
            interactHit = true;

            //buttonOrder detection
            if (hit.collider.gameObject.tag == "Button" && interactHit == true)
            {
                pressedButton = int.Parse(hit.collider.gameObject.name);
                if (pressedButton == orderNumber)
                {
                    orderNumber++;
                }
                else
                {
                    orderNumber = 1;
                    Wrong.Play();
                }

                if(orderNumber == 7 && doorClosed == 3)
                {
                    doorClosed -= 1;
                    orderNumber = 1;

                    DoorOpen.Play();

                    door1.SetActive(false);
                } else if (orderNumber == 7 && doorClosed == 2)
                {
                    doorClosed -= 1;
                    orderNumber = 1;

                    DoorOpen.Play();

                    door2.SetActive(false);
                } else if (orderNumber == 7 && doorClosed == 1)
                {
                    doorClosed -= 1;
                    orderNumber = 1;

                    DoorOpen.Play();

                    door3.SetActive(false);
                    SceneManager.LoadScene(0);
                } else
                {
                    Click.Play();
                }
            }

            Debug.Log(orderNumber);

            //ModeSwitch detection
            if (hit.collider.gameObject.tag == "ModeSwitch" && interactHit == true)
            {
                Window1.transform.localRotation = Quaternion.Euler(Window1.transform.localRotation.eulerAngles.x, Window1.transform.localRotation.eulerAngles.y, -Window1.transform.localRotation.eulerAngles.z);
                Window2.transform.localRotation = Quaternion.Euler(Window2.transform.localRotation.eulerAngles.x, Window2.transform.localRotation.eulerAngles.y, -Window2.transform.localRotation.eulerAngles.z);

                Click.Play();
            }

            //PortalSwitch detection
            if (hit.collider.gameObject.tag == "PortalSwitch" && interactHit == true)
            {
                Click.Play();

                if (hit.collider.gameObject.name == "W1")
                {
                    Portal1.gameObject.SetActive(false);

                    Portal2.gameObject.SetActive(true);
                    Portal3.gameObject.SetActive(true);
                } else if (hit.collider.gameObject.name == "W2")
                {
                    Portal2.gameObject.SetActive(false);

                    Portal3.gameObject.SetActive(true);
                    Portal1.gameObject.SetActive(true);
                } else if (hit.collider.gameObject.name == "W3")
                {
                    Portal3.gameObject.SetActive(false);

                    Portal1.gameObject.SetActive(true);
                    Portal2.gameObject.SetActive (true);
                } else if (hit.collider.gameObject.name == "W4")
                {
                    Portal4.gameObject.SetActive(false);

                    Portal5.gameObject.SetActive(true);
                    Portal6.gameObject.SetActive(true);
                } else if (hit.collider.gameObject.name == "W5")
                {
                    Portal5.gameObject.SetActive(false);

                    Portal6.gameObject.SetActive(true);
                    Portal4.gameObject.SetActive(true);
                } else if (hit.collider.gameObject.name == "W6")
                {
                    Portal6.gameObject.SetActive(false);

                    Portal4.gameObject.SetActive(true);
                    Portal5.gameObject.SetActive(true);
                }
            }
        }

        //make cursor bigger on raycast hit
        if (Physics.Raycast(ray, out hit, interactionRange, interactions))
        {
            cursor.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        } else
        {
            cursor.transform.localScale = new Vector3(0.025f, 0.025f, 0.025f);
        }
    }
}