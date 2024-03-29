using UnityEngine;
using UnityEngine.UI;

public class RaycastFromCamera : MonoBehaviour
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
    public GameObject Window1;
    public GameObject Window2;

    public Image cursor;

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
                }

                if(orderNumber == 7 && doorClosed == 3)
                {
                    doorClosed -= 1;
                    orderNumber = 1;

                    door1.SetActive(false);
                } else if (orderNumber == 7 && doorClosed == 2)
                {
                    doorClosed -= 1;
                    orderNumber = 1;

                    door2.SetActive(false);
                }
            }

            Debug.Log(orderNumber);

            //ModeSwitch detection
            if (hit.collider.gameObject.tag == "ModeSwitch" && interactHit == true)
            {
                Window1.transform.localRotation = Quaternion.Euler(Window1.transform.localRotation.eulerAngles.x, Window1.transform.localRotation.eulerAngles.y, -Window1.transform.localRotation.eulerAngles.z);
                Window2.transform.localRotation = Quaternion.Euler(Window2.transform.localRotation.eulerAngles.x, Window2.transform.localRotation.eulerAngles.y, -Window2.transform.localRotation.eulerAngles.z);
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