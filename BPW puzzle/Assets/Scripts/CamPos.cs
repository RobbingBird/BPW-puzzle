using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPos : MonoBehaviour
{
    public GameObject cameraPos; 
    public void Update()
    {
        transform.position =  cameraPos.transform.position;
    }
}
