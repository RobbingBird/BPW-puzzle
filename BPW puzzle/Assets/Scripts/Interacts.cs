using UnityEngine;

public class RaycastFromCamera : MonoBehaviour
{
    public Camera mainCamera;

    public LayerMask interactions;

    public float interactionRange;

    private int orderNumber = 1;
    private int pressedButton;

    private bool interactHit = false; 

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
            }

            Debug.Log(orderNumber);
        }
    }
}