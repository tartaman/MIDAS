using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GizmoRotacion : MonoBehaviour
{
    public GameObject gizmo;
    public char eje;
    public byte parte;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDrag()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        switch (eje)
        {
            case 'x':
                if (Camera.main.transform.rotation.eulerAngles.y < 315 && Camera.main.transform.rotation.eulerAngles.y >= 225)
                {
                    if (parte == 1)
                    {
                        gizmo.transform.Rotate(Vector3.right * 70 * Time.deltaTime * mouseY);
                    }
                    else
                    {
                        gizmo.transform.Rotate(Vector3.right * 70 * Time.deltaTime * -mouseY);
                    }
                }
                else if (Camera.main.transform.rotation.eulerAngles.y < 225 && Camera.main.transform.rotation.eulerAngles.y >= 135)
                {
                    gizmo.transform.Rotate(Vector3.right * 70 * Time.deltaTime * -mouseY);
                }
                else if (Camera.main.transform.rotation.eulerAngles.y < 135 && Camera.main.transform.rotation.eulerAngles.y >= 45)
                {
                    if (parte == 1)
                    {
                        gizmo.transform.Rotate(Vector3.right * 70 * Time.deltaTime * mouseY);
                    }
                    else
                    {
                        gizmo.transform.Rotate(Vector3.right * 70 * Time.deltaTime * -mouseY);
                    }
                }
                else
                {
                    gizmo.transform.Rotate(Vector3.right * 70 * Time.deltaTime * mouseY);
                }
                break;
                

            case 'z':
                if (Camera.main.transform.rotation.eulerAngles.y < 315 && Camera.main.transform.rotation.eulerAngles.y >= 225)
                {
                    Debug.Log("2");
                    gizmo.transform.Rotate(Vector3.forward * 70  * Time.deltaTime * mouseY);
                }
                else if (Camera.main.transform.rotation.eulerAngles.y < 225 && Camera.main.transform.rotation.eulerAngles.y >= 135)
                {
                    if (parte == 1)
                    {
                        gizmo.transform.Rotate(Vector3.forward * -mouseY * Time.deltaTime * 70);
                    }
                    else
                    {
                        gizmo.transform.Rotate(Vector3.forward * mouseY * Time.deltaTime * 70);
                    }
                        Debug.Log("3");
                    
                }
                else if (Camera.main.transform.rotation.eulerAngles.y < 135 && Camera.main.transform.rotation.eulerAngles.y >= 45)
                {
                    Debug.Log("4");
                    gizmo.transform.Rotate(Vector3.forward * -mouseY * Time.deltaTime * 70);
                }
                else
                {
                    if (parte == 1)
                    {
                        gizmo.transform.Rotate(Vector3.forward * -mouseY * Time.deltaTime * 70);
                    }
                    else
                    {
                        gizmo.transform.Rotate(Vector3.forward * mouseY * Time.deltaTime * 70);
                    }
                    Debug.Log("1");
                    
                }
                Debug.Log(Camera.main.transform.rotation.eulerAngles.y);
                break;

            case 'y':
                /*
                if (Camera.main.transform.rotation.eulerAngles.y < 315 && Camera.main.transform.rotation.eulerAngles.y >= 225)
                {
                    
                    gizmo.transform.Rotate(Vector3.up * -mouseX * Time.deltaTime * 70);
                    Debug.Log("2");
                    
                }
                else if (Camera.main.transform.rotation.eulerAngles.y < 225 && Camera.main.transform.rotation.eulerAngles.y >= 135)
                {
                    Debug.Log("3");
                    gizmo.transform.Rotate(Vector3.up * -mouseX * Time.deltaTime * 70);
                  
                }
                else if (Camera.main.transform.rotation.eulerAngles.y < 135 && Camera.main.transform.rotation.eulerAngles.y >= 45)
                {

                    gizmo.transform.Rotate(Vector3.up * mouseX * Time.deltaTime * 3);
                }
                else
                {

                    gizmo.transform.Rotate(Vector3.up * -mouseX * Time.deltaTime * 70);


                }
                Debug.Log(Camera.main.transform.rotation.eulerAngles.y);
                
                */

                gizmo.transform.Rotate(Vector3.up * -mouseX * Time.deltaTime * 70); 
                break;

            default:
                break;
        }
    }
}
    
