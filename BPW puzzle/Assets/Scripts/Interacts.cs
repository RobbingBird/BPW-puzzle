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

    public Image cursor;

    void Update()
    {
        //interactDetection
        interactHit = false;

        if (mainCamera == null)
        {
            Debug.LogError("Main camera reference not set!");
            return;
        }

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
                }
            }

            Debug.Log(orderNumber);
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