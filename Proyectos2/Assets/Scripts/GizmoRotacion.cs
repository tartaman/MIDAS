using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GizmoRotacion : MonoBehaviour
{
    public GameObject gizmo;
    public char eje;
    public byte parte;
    private Gizmo helper;
    void Start()
    {
        helper = GameObject.FindGameObjectWithTag("helper").GetComponent<Gizmo>();
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
                        gizmo.transform.Rotate(Vector3.right * 70 * Time.deltaTime * -mouseY);
                    }
                    else
                    {
                        gizmo.transform.Rotate(Vector3.right * 70 * Time.deltaTime * mouseY);
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
                helper.setRotando(true,'x');
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
                helper.setRotando(true, 'z');
                break;

            case 'y':
             
                gizmo.transform.Rotate(Vector3.up * -mouseX * Time.deltaTime * 70);
                helper.setRotando(true,'y');
                break;

            default:
                break;
        }
        
    }
    private void OnMouseUp()
    {
        gizmo.transform.rotation = Quaternion.Euler(Vector3.zero);
        helper.setRotando(false, 'q');
    }

    
    
}
    
