using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleGizmo : MonoBehaviour
{
    Gizmo helper;
    [SerializeField] private char eje; 
    [SerializeField] GameObject seleccionado;
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
                seleccionado.transform.localScale += Vector3.right * 5 * mouseX * Time.deltaTime;
                break;
            default:
                break;
        }
    }
}
