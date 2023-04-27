using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleGizmo : MonoBehaviour
{
    Gizmo helper;
    [SerializeField] private char eje; 
    [SerializeField] GameObject seleccionado;
    bool check;
    Vector2 inicial;
    Vector2 final;
    Vector2 direccion;
    void Start()
    {
        helper = GameObject.FindGameObjectWithTag("helper").GetComponent<Gizmo>();
    }

    public void SetSeleccionado(GameObject objeto)
    {
        seleccionado = objeto;
    }
        


    private void OnMouseDrag()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        switch (eje)
        {
            case 'X':
                if (Camera.main.transform.rotation.eulerAngles.y < 315 && Camera.main.transform.rotation.eulerAngles.y >= 225)
                {
                    seleccionado.transform.localScale += Vector3.right * -mouseY * Time.deltaTime * 5;
                }
                else if (Camera.main.transform.rotation.eulerAngles.y < 225 && Camera.main.transform.rotation.eulerAngles.y >= 135)
                {
                    seleccionado.transform.localScale += Vector3.right * -mouseX * Time.deltaTime * 5;
                }
                else if (Camera.main.transform.rotation.eulerAngles.y < 135 && Camera.main.transform.rotation.eulerAngles.y >= 45)
                {
                    seleccionado.transform.localScale += Vector3.right * mouseY * Time.deltaTime * 5;
                }
                else
                {
                    seleccionado.transform.localScale += Vector3.right * mouseX * Time.deltaTime * 5;
                }
                break;

            case 'Y':
                seleccionado.transform.localScale += Vector3.up * mouseY * Time.deltaTime * 5;
                break;

            case 'Z':
                if (Camera.main.transform.rotation.eulerAngles.y < 315 && Camera.main.transform.rotation.eulerAngles.y >= 225)
                {
                    seleccionado.transform.localScale += Vector3.forward * mouseX * Time.deltaTime * 5;
                }
                else if (Camera.main.transform.rotation.eulerAngles.y < 225 && Camera.main.transform.rotation.eulerAngles.y >= 135)
                {
                    seleccionado.transform.localScale += Vector3.forward * -mouseY * Time.deltaTime * 5;
                }
                else if (Camera.main.transform.rotation.eulerAngles.y < 135 && Camera.main.transform.rotation.eulerAngles.y >= 45)
                {
                    seleccionado.transform.localScale += Vector3.forward * -mouseX * Time.deltaTime * 5;
                }
                else
                {
                    seleccionado.transform.localScale += Vector3.forward * mouseY * Time.deltaTime * 5;
                }
                break;
            case 'G':
                
                if (check)
                {
                    final = (Vector2)Input.mousePosition;
                    
                    final = Camera.main.ScreenToViewportPoint(final);
                    Debug.Log(final);
                    //direccion = final - inicial;

                    Debug.Log(inicial);
                    /*
                    if ((final.x > inicial.x || final.y > inicial.y) && !(final.y > inicial.y && final.x < inicial.x))
                        seleccionado.transform.localScale += Vector3.one * Time.deltaTime;
                    else if ((final.x < inicial.x || final.y < inicial.y) && !(final.y < inicial.y && final.x > inicial.x))
                        seleccionado.transform.localScale -= Vector3.one * Time.deltaTime;
                    */
                    (float, char) aComparar = (final.x > final.y) ? (final.x, 'x') : (final.y, 'y');
                    if (aComparar.Item2 == 'x' && aComparar.Item1 > inicial.x || aComparar.Item2 == 'y' && aComparar.Item1 > inicial.y)
                        seleccionado.transform.localScale += Vector3.one * Time.deltaTime;
                    else if (aComparar.Item2 == 'x' && aComparar.Item1 < inicial.x || aComparar.Item2 == 'y' && aComparar.Item1 < inicial.y)
                        seleccionado.transform.localScale -= Vector3.one * Time.deltaTime;
                    break;
                    
                   
                }
                else
                {
                    inicial = (Vector2)Input.mousePosition;
                    inicial = Camera.main.ScreenToViewportPoint(inicial);
                    check = true;

                }
                break;
                
                
            default:
                break;
        }
    }
}
