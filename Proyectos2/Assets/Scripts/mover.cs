using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour
{
    public char eje;
    public GameObject gizmo;
    // Start is called before the first frame update
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

                if(Camera.main.transform.rotation.eulerAngles.y < 315 && Camera.main.transform.rotation.eulerAngles.y >= 225)
                {
                    Debug.Log("2");
                    gizmo.transform.Translate(Vector3.right * -mouseY * Time.deltaTime * 3);
                }
                else if (Camera.main.transform.rotation.eulerAngles.y < 225 && Camera.main.transform.rotation.eulerAngles.y >= 135)
                {
                    Debug.Log("3");
                    gizmo.transform.Translate(Vector3.right * -mouseX * Time.deltaTime * 3);
                }
                else if(Camera.main.transform.rotation.eulerAngles.y < 135 && Camera.main.transform.rotation.eulerAngles.y >= 45)
                {
                    Debug.Log("4");
                    gizmo.transform.Translate(Vector3.right * mouseY * Time.deltaTime * 3);
                }
                else
                {
                    Debug.Log("1");
                    gizmo.transform.Translate(Vector3.right * mouseX * Time.deltaTime * 3);
                }
                Debug.Log( Camera.main.transform.rotation.eulerAngles.y);
                break;

            case 'z':
                if (Camera.main.transform.rotation.eulerAngles.y < 315 && Camera.main.transform.rotation.eulerAngles.y >= 225)
                {
                    Debug.Log("2");
                    gizmo.transform.Translate(Vector3.forward * mouseX * Time.deltaTime * 3);
                }
                else if (Camera.main.transform.rotation.eulerAngles.y < 225 && Camera.main.transform.rotation.eulerAngles.y >= 135)
                {
                    Debug.Log("3");
                    gizmo.transform.Translate(Vector3.forward * -mouseY * Time.deltaTime * 3);
                }
                else if (Camera.main.transform.rotation.eulerAngles.y < 135 && Camera.main.transform.rotation.eulerAngles.y >= 45)
                {
                    Debug.Log("4");
                    gizmo.transform.Translate(Vector3.forward * -mouseX * Time.deltaTime * 3);
                }
                else
                {
                    Debug.Log("1");
                    gizmo.transform.Translate(Vector3.forward * mouseY * Time.deltaTime * 3);
                }
                Debug.Log(Camera.main.transform.rotation.eulerAngles.y);
                break;
            case 'y':
                gizmo.transform.Translate(Vector3.up * mouseY * Time.deltaTime * 3);
                break;
            default:
                break;
        }
    }

   
}
